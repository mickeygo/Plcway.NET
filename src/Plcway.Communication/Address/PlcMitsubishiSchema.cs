namespace Plcway.Communication.Address
{
    /// <summary>
    /// 三菱的数据地址表示形式
    /// </summary>
    public class PlcMitsubishiSchema : PlcSchema
    {
		/// <summary>
		/// 类型的代号值
		/// </summary>
		public byte DataCode { get; private set; } = 0;

		/// <summary>
		/// 数据的类型，0代表按字，1代表按位
		/// </summary>
		public byte DataType { get; private set; } = 0;

		/// <summary>
		/// 当以ASCII格式通讯时的类型描述
		/// </summary>
		public string AsciiCode { get; private set; }

		/// <summary>
		/// 指示地址是10进制，还是16进制的
		/// </summary>
		public int FromBase { get; private set; } = 10;
	}
}
