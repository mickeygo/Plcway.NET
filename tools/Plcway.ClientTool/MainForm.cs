using Plcway.Communication.Ethernet.Profinet.Siemens;

namespace Plcway.ClientTool
{
    public partial class MainForm : Form
    {
        private readonly List<Client> _s7Clients = new();

        private bool _isRuning = false;

        private readonly string _cacheFile;

        public MainForm()
        {
            InitializeComponent();

            _cacheFile = Path.Combine(AppContext.BaseDirectory, "_cacheFile.txt");
            LoadData();
        }

        private void btn_add_Click(object sender, EventArgs e)
        {
            var ip = this.txt_ip.Text.Trim();
            var args = this.txt_args.Text;
            if (!string.IsNullOrEmpty(ip))
            {
                var item = $"{ip}:{args}";
                this.listBox_ip.Items.Add(item);
                AppendLastData(item);
            }
        }

        private void btn_remove_Click(object sender, EventArgs e)
        {
            int count = this.listBox_ip.Items.Count;
            if (count == 0)
            {
                return;
            }

            this.listBox_ip.Items.RemoveAt(count - 1);
            RemoveLastData();
        }

        private void btn_run_Click(object sender, EventArgs e)
        {
            if (this.listBox_ip.Items.Count == 0)
            {
                return;
            }

            S7Close();

            var btn = (Button)sender;
            btn.Enabled = false;

            var plcType = SiemensPLCS.S1200;
            if (radio_1500.Checked)
            {
                plcType = SiemensPLCS.S1500;
            }

            foreach (string item in this.listBox_ip.Items)
            {
                var arr = item.Split(':');
                var s7 = new SiemensS7Net(plcType, arr[0]);
                s7.ConnectServer();
                _s7Clients.Add(new Client { S7 = s7, Args = arr[1]});
            }

            this.btn_stop.Enabled = true;
            _isRuning = true;

            Run();
        }

        private void btn_stop_Click(object sender, EventArgs e)
        {
            var btn = (Button)sender;
            btn.Enabled = false;

            S7Close();

            this.btn_run.Enabled = true;
            _isRuning = false;
        }

        private void btn_msg_clear_Click(object sender, EventArgs e)
        {
            this.list_msg.Items.Clear();
            this.listBox_error.Items.Clear();
        }

        protected override void OnClosed(EventArgs e)
        {
            base.OnClosed(e);
        }

        private void S7Close()
        {
            _s7Clients.ForEach(s =>
            {
                s.S7.Dispose();
            });

            _s7Clients.Clear();
        }

        private void Run(int interval = 50)
        {
            foreach (var client in _s7Clients)
            {
                _ = Task.Run(async () =>
                {
                    while (true)
                    {
                        await Task.Delay(interval);
                        if (!_isRuning)
                        {
                            break;
                        }

                        this.list_msg.Items.Add($"[{DateTime.Now:yyyyMMdd HH:mm:ss:fff}] {client.S7.IpAddress} Send: {client.Args}");
                        var ret = client.S7.ReadInt16(client.Args, 9);
                        if (!ret.IsSuccess)
                        {
                            this.listBox_error.Items.Add($"[{DateTime.Now:yyyyMMdd HH:mm:ss:fff}] {client.S7.IpAddress}: {ret.Message}");
                        }
                        else
                        {
                            this.list_msg.Items.Add($"[{DateTime.Now:yyyyMMdd HH:mm:ss:fff}] {client.S7.IpAddress} Rec: {string.Join(" ", ret.Content)}");
                        }
                    }
                });
            }
        }

        private void LoadData()
        {
            string v = "";
            if (File.Exists(_cacheFile))
            {
                v = File.ReadAllText(_cacheFile) ?? "";
            }

            foreach (var item in v.Split(';', StringSplitOptions.RemoveEmptyEntries))
            {
                this.listBox_ip.Items.Add(item);
            }
        }

        private void AppendLastData(string val)
        {
            string v = "";
            if (File.Exists(_cacheFile))
            {
                v = File.ReadAllText(_cacheFile) ?? "";
            }
           
            File.WriteAllText(_cacheFile, $"{v};{val}");
        }

        private void RemoveLastData()
        {
            string v = "";
            if (File.Exists(_cacheFile))
            {
                v = File.ReadAllText(_cacheFile) ?? "";
            }

            var arr = v.Split(';', StringSplitOptions.RemoveEmptyEntries);
            if (arr.Length > 0)
            {
                File.WriteAllText(_cacheFile, string.Join(";", arr[0..(arr.Length - 1)]));
            }
        }
    }

    class Client
    {
        public SiemensS7Net S7 { get; set; }

        public string Args { get; set; }
    }
}