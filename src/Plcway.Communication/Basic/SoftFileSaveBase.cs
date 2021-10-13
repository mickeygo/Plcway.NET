using System;
using System.IO;
using System.Text;
using Microsoft.Extensions.Logging;
using Plcway.Communication.Core;

namespace Plcway.Communication.Basic
{
	/// <summary>
	/// 文件存储功能的基类，包含了文件存储路径，存储方法等
	/// </summary>
	/// <remarks>
	/// 需要继承才能实现你想存储的数据，比较经典的例子就是存储你的应用程序的配置信息，通常的格式就是xml文件或是json文件。
	/// </remarks>
	public class SoftFileSaveBase : ISoftFileSaveBase
	{
		private readonly SimpleHybirdLock HybirdLock;

		/// <summary>
		/// 在日志保存时的标记当前调用类的信息
		/// </summary>
		protected string LogHeaderText { get; set; }

		/// <summary>
		/// 文件存储的路径
		/// </summary>
		public string FileSavePath { get; set; }

		/// <summary>
		/// 日志记录类
		/// </summary>
		public ILogger Logger { get; set; }

		/// <summary>
		/// 实例化一个文件存储的基类
		/// </summary>
		public SoftFileSaveBase()
		{
			HybirdLock = new SimpleHybirdLock();
		}

		public virtual string ToSaveString()
		{
			return string.Empty;
		}

		public virtual void LoadByString(string content)
		{
		}

		public virtual void LoadByFile()
		{
			LoadByFile((string m) => m);
		}

		/// <summary>
		/// 使用用户自定义的解密方法从文件读取数据
		/// </summary>
		/// <param name="decrypt">用户自定义的解密方法</param>
		public void LoadByFile(Converter<string, string> decrypt)
		{
			if (!(FileSavePath != "") || !File.Exists(FileSavePath))
			{
				return;
			}

			HybirdLock.Enter();
			try
			{
				using var streamReader = new StreamReader(FileSavePath, Encoding.Default);
				LoadByString(decrypt(streamReader.ReadToEnd()));
			}
			catch (Exception ex)
			{
				Logger?.LogError(ex, LogHeaderText);
			}
			finally
			{
				HybirdLock.Leave();
			}
		}

		public virtual void SaveToFile()
		{
			SaveToFile((string m) => m);
		}

		/// <summary>
		/// 使用用户自定义的加密方法保存数据到文件
		/// </summary>
		/// <param name="encrypt">用户自定义的加密方法</param>
		public void SaveToFile(Converter<string, string> encrypt)
		{
			if (!(FileSavePath != ""))
			{
				return;
			}

			HybirdLock.Enter();
			try
			{
				using var streamWriter = new StreamWriter(FileSavePath, append: false, Encoding.Default);
				streamWriter.Write(encrypt(ToSaveString()));
				streamWriter.Flush();
			}
			catch (Exception ex)
			{
				Logger?.LogError(ex, LogHeaderText);
			}
			finally
			{
				HybirdLock.Leave();
			}
		}
	}
}
