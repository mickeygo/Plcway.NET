using System;
using System.Net.Mail;
using System.Text;

namespace Plcway.Communication.Basic
{
	/// <summary>
	/// 软件的邮箱类，用于发送邮箱数据
	/// </summary>
	/// <remarks>
	/// 如果您想实现自己的邮件发送中心，就可以去对应的邮件服务器注册，如果是想快速实现邮件的发送，本系统提供了2个静态的已经注册好了的邮箱发送器。
	/// </remarks>
	public class SoftMail
	{
		/// <summary>
		/// 系统连续发送失败的次数，为了不影响系统，连续三次失败就禁止发送
		/// </summary>
		private static long SoftMailSendFailedCount = 0L;
		private readonly SmtpClient _smtpClient;

		/// <summary>
		/// 实例化一个邮箱发送类，需要指定初始化信息
		/// </summary>
		/// <param name="mailIni">初始化的方法</param>
		/// <remarks>
		/// 初始化的方法比较复杂，需要参照示例代码。
		/// </remarks>
		public SoftMail(Action<SmtpClient> mailIni)
		{
			_smtpClient = new SmtpClient();
			mailIni(_smtpClient);
		}

		/// <summary>
		/// 发送邮件的方法，需要提供完整的参数信息
		/// </summary>
		/// <param name="addr_from">发送地址</param>
		/// <param name="name">发送别名</param>
		/// <param name="addr_to">接收地址</param>
		/// <param name="subject">邮件主题</param>
		/// <param name="body">邮件内容</param>
		/// <param name="priority">优先级</param>
		/// <param name="isHtml">邮件内容是否是HTML语言</param>
		/// <returns>发生是否成功，内容不正确会被视为垃圾邮件</returns>
		public bool SendMail(string addr_from, string name, string[] addr_to, string subject, string body, MailPriority priority, bool isHtml)
		{
			if (SoftMailSendFailedCount > 10)
			{
				SoftMailSendFailedCount++;
				return true;
			}

			using var mailMessage = new MailMessage();
			try
			{
				mailMessage.From = new MailAddress(addr_from, name, Encoding.UTF8);
				foreach (string addresses in addr_to)
				{
					mailMessage.To.Add(addresses);
				}
				mailMessage.Subject = subject;
				mailMessage.Body = body;
				mailMessage.SubjectEncoding = Encoding.UTF8;
				mailMessage.BodyEncoding = Encoding.UTF8;
				mailMessage.Priority = priority;
				mailMessage.IsBodyHtml = isHtml;
				_smtpClient.Send(mailMessage);
				SoftMailSendFailedCount = 0L;
				return true;
			}
			catch
			{
				SoftMailSendFailedCount++;
				return false;
			}
		}
	}
}
