using System;
namespace Model
{
	/// <summary>
	/// 家具
	/// </summary>
	[Serializable]
	public partial class tb_roomfurniture:BaseModel
	{
		public tb_roomfurniture()
		{}
		#region Model
		private string _id;
		private string _roomid;
		private string _name;
		private string _intro;
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
		public string roomid
		{
			set{ _roomid=value;}
			get{return _roomid;}
		}
		/// <summary>
		/// 名称
		/// </summary>
		public string name
		{
			set{ _name=value;}
			get{return _name;}
		}
		/// <summary>
		/// 说明
		/// </summary>
		public string intro
		{
			set{ _intro=value;}
			get{return _intro;}
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

