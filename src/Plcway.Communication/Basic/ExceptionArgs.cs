using System;

namespace Plcway.Communication.Basic
{
	/// <summary>
	/// 异常消息基类
	/// </summary>
	[Serializable]
	public abstract class ExceptionArgs
	{
		public virtual string Message => string.Empty;
	}
}
