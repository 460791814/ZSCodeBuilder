using System;
namespace Model
{
	/// <summary>
	/// 系统用户
	/// </summary>
	[Serializable]
	public partial class tb_sysuser:BaseModel
	{
		public tb_sysuser()
		{}
		#region Model
		private string _id;
		private string _username;
		private string _password;
		/// <summary>
		/// 
		/// </summary>
		public string id
		{
			set{ _id=value;}
			get{return _id;}
		}
		/// <summary>
		/// 登陆用户名
		/// </summary>
		public string username
		{
			set{ _username=value;}
			get{return _username;}
		}
		/// <summary>
		/// 密码
		/// </summary>
		public string password
		{
			set{ _password=value;}
			get{return _password;}
		}
		#endregion Model

	}
}

