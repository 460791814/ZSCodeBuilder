using System;
namespace Model
{
	/// <summary>
	/// 意见反馈
	/// </summary>
	[Serializable]
	public partial class tb_opinion:BaseModel
	{
		public tb_opinion()
		{}
		#region Model
		private string _id;
		private string _username;
		private string _content;
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
		/// 意见建议
		/// </summary>
		public string content
		{
			set{ _content=value;}
			get{return _content;}
		}
		/// <summary>
		/// 添加时间
		/// </summary>
		public DateTime? addtime
		{
			set{ _addtime=value;}
			get{return _addtime;}
		}
		#endregion Model

	}
}

