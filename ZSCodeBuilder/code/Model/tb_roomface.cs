using System;
namespace Model
{
	/// <summary>
	/// 楼层展示图
	/// </summary>
	[Serializable]
	public partial class tb_roomface:BaseModel
	{
		public tb_roomface()
		{}
		#region Model
		private string _id;
		private int? _roomid;
		private string _name;
		private string _intro;
		private string _pic;
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
		/// 房间ID
		/// </summary>
		public int? roomid
		{
			set{ _roomid=value;}
			get{return _roomid;}
		}
		/// <summary>
		/// 文件名
		/// </summary>
		public string name
		{
			set{ _name=value;}
			get{return _name;}
		}
		/// <summary>
		/// 文件简介
		/// </summary>
		public string intro
		{
			set{ _intro=value;}
			get{return _intro;}
		}
		/// <summary>
		/// 图片地址
		/// </summary>
		public string pic
		{
			set{ _pic=value;}
			get{return _pic;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? addtime
		{
			set{ _addtime=value;}
			get{return _addtime;}
		}
		#endregion Model

	}
}

