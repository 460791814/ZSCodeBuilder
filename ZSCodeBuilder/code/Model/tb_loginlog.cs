using System;
namespace Model
{
	/// <summary>
	/// 登陆日志
	/// </summary>
	[Serializable]
	public partial class tb_loginlog:BaseModel
	{
		public tb_loginlog()
		{}
		#region Model
		private string _id;
		private string _username;
		private string _ip;
		private DateTime? _addtime;
		/// <summary>
		/// 
		/// </summary>
		public string id
		{
			set{ _id=value;}
			get{return _id;}
		}
		/// <summary>
		/// 用户名
		/// </summary>
		public string username
		{
			set{ _username=value;}
			get{return _username;}
		}
		/// <summary>
		/// 来访IP
		/// </summary>
		public string ip
		{
			set{ _ip=value;}
			get{return _ip;}
		}
		/// <summary>
		/// 登陆时间
		/// </summary>
		public DateTime? addtime
		{
			set{ _addtime=value;}
			get{return _addtime;}
		}
		#endregion Model

	}
}

