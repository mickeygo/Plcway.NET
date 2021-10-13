namespace Plcway.Communication.Ethernet.Profinet.AllenBradley
{
	/// <summary>
	/// AB PLC的cip通信实现类，适用Micro800系列控制系统<br />
	/// AB PLC's cip communication implementation class, suitable for Micro800 series control system
	/// </summary>
	public class AllenBradleyMicroCip : AllenBradleyNet
	{
		public AllenBradleyMicroCip()
		{
		}

		public AllenBradleyMicroCip(string ipAddress, int port = 44818)
			: base(ipAddress, port)
		{
		}

		protected override byte[] PackCommandService(byte[] portSlot, params byte[][] cips)
		{
			return AllenBradleyHelper.PackCleanCommandService(portSlot, cips);
		}

		public override string ToString()
		{
			return $"AllenBradleyMicroCip[{IpAddress}:{Port}]";
		}
	}
}
