using System;

namespace Plcway.Communication.Core.Message
{
	/// <summary>
	/// 用于和 AllenBradley PLC 交互的消息协议类
	/// </summary>
	public class AllenBradleyMessage : INetMessage
	{
		/// <inheritdoc cref="P:HslCommunication.Core.IMessage.INetMessage.ProtocolHeadBytesLength" />
		public int ProtocolHeadBytesLength => 24;

		/// <inheritdoc cref="P:HslCommunication.Core.IMessage.INetMessage.HeadBytes" />
		public byte[] HeadBytes { get; set; }

		/// <inheritdoc cref="P:HslCommunication.Core.IMessage.INetMessage.ContentBytes" />
		public byte[] ContentBytes { get; set; }

		/// <inheritdoc cref="P:HslCommunication.Core.IMessage.INetMessage.SendBytes" />
		public byte[] SendBytes { get; set; }

		/// <inheritdoc cref="M:HslCommunication.Core.IMessage.INetMessage.GetContentLengthByHeadBytes" />
		public int GetContentLengthByHeadBytes()
		{
			return BitConverter.ToUInt16(HeadBytes, 2);
		}

		/// <inheritdoc cref="M:HslCommunication.Core.IMessage.INetMessage.CheckHeadBytesLegal(System.Byte[])" />
		public bool CheckHeadBytesLegal(byte[] token)
		{
			return true;
		}

		/// <inheritdoc cref="M:HslCommunication.Core.IMessage.INetMessage.GetHeadBytesIdentity" />
		public int GetHeadBytesIdentity()
		{
			return 0;
		}
	}
}