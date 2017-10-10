using System;
namespace Model
{
	/// <summary>
	/// 操作日志
	/// </summary>
	[Serializable]
	public partial class tb_operationlog:BaseModel
	{
		public tb_operationlog()
		{}
		#region Model
		private string _id;
		private string _username;
		private string _ip;
		private string _target;
		private string _action;
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
		/// 操作对象
		/// </summary>
		public string target
		{
			set{ _target=value;}
			get{return _target;}
		}
		/// <summary>
		/// 动作
		/// </summary>
		public string action
		{
			set{ _action=value;}
			get{return _action;}
		}
		/// <summary>
		/// 操作时间
		/// </summary>
		public DateTime? addtime
		{
			set{ _addtime=value;}
			get{return _addtime;}
		}
		#endregion Model

	}
}

