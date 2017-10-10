using System;
namespace Model
{
	/// <summary>
	/// 会议室评价
	/// </summary>
	[Serializable]
	public partial class tb_meetingroomcomment:BaseModel
	{
		public tb_meetingroomcomment()
		{}
		#region Model
		private string _id;
		private int? _star;
		private string _content;
		private DateTime? _addtime;
		private string _orderid;
		/// <summary>
		/// 
		/// </summary>
		public string id
		{
			set{ _id=value;}
			get{return _id;}
		}
		/// <summary>
		/// 星级
		/// </summary>
		public int? star
		{
			set{ _star=value;}
			get{return _star;}
		}
		/// <summary>
		/// 评价内容
		/// </summary>
		public string content
		{
			set{ _content=value;}
			get{return _content;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? addtime
		{
			set{ _addtime=value;}
			get{return _addtime;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string orderid
		{
			set{ _orderid=value;}
			get{return _orderid;}
		}
		#endregion Model

	}
}

