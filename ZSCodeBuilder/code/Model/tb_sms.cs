using System;
namespace Model
{
	/// <summary>
	/// 手机短信验证码
	/// </summary>
	[Serializable]
	public partial class tb_sms:BaseModel
	{
		public tb_sms()
		{}
		#region Model
		private string _id;
		private string _phonenum;
		private string _verificationcode;
		private DateTime? _senddate;
		private int? _sendtype;
		/// <summary>
		/// 
		/// </summary>
		public string id
		{
			set{ _id=value;}
			get{return _id;}
		}
		/// <summary>
		/// 手机号
		/// </summary>
		public string phonenum
		{
			set{ _phonenum=value;}
			get{return _phonenum;}
		}
		/// <summary>
		/// 验证码
		/// </summary>
		public string verificationcode
		{
			set{ _verificationcode=value;}
			get{return _verificationcode;}
		}
		/// <summary>
		/// 发送时间
		/// </summary>
		public DateTime? senddate
		{
			set{ _senddate=value;}
			get{return _senddate;}
		}
		/// <summary>
		/// 发送短信类型
		/// </summary>
		public int? sendtype
		{
			set{ _sendtype=value;}
			get{return _sendtype;}
		}
		#endregion Model

	}
}

