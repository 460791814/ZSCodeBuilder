using System;
namespace Model
{
	/// <summary>
	/// 房屋租赁
	/// </summary>
	[Serializable]
	public partial class tb_room:BaseModel
	{
		public tb_room()
		{}
		#region Model
		private string _id;
		private string _buildingid;
		private string _floor;
		private string _roomnumber;
		private int? _roomtype;
		private string _hold;
		private string _housetype;
		private string _direction;
		private string _space;
		private string _fee;
		private int? _status;
		private int? _isopen;
		private bool _isdel;
		private int? _sortnum;
		private DateTime? _addtime;
		/// <summary>
		/// 出租的屋子
		/// </summary>
		public string id
		{
			set{ _id=value;}
			get{return _id;}
		}
		/// <summary>
		/// 楼宇
		/// </summary>
		public string buildingid
		{
			set{ _buildingid=value;}
			get{return _buildingid;}
		}
		/// <summary>
		/// 楼层
		/// </summary>
		public string floor
		{
			set{ _floor=value;}
			get{return _floor;}
		}
		/// <summary>
		/// 房间号
		/// </summary>
		public string roomnumber
		{
			set{ _roomnumber=value;}
			get{return _roomnumber;}
		}
		/// <summary>
		/// 类型
		/// </summary>
		public int? roomtype
		{
			set{ _roomtype=value;}
			get{return _roomtype;}
		}
		/// <summary>
		/// 可容纳人数
		/// </summary>
		public string hold
		{
			set{ _hold=value;}
			get{return _hold;}
		}
		/// <summary>
		/// 房型
		/// </summary>
		public string housetype
		{
			set{ _housetype=value;}
			get{return _housetype;}
		}
		/// <summary>
		/// 朝向
		/// </summary>
		public string direction
		{
			set{ _direction=value;}
			get{return _direction;}
		}
		/// <summary>
		/// 面积
		/// </summary>
		public string space
		{
			set{ _space=value;}
			get{return _space;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string fee
		{
			set{ _fee=value;}
			get{return _fee;}
		}
		/// <summary>
		/// 租赁状态
		/// </summary>
		public int? status
		{
			set{ _status=value;}
			get{return _status;}
		}
		/// <summary>
		/// 是否开放
		/// </summary>
		public int? isopen
		{
			set{ _isopen=value;}
			get{return _isopen;}
		}
		/// <summary>
		/// 
		/// </summary>
		public bool isdel
		{
			set{ _isdel=value;}
			get{return _isdel;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? sortnum
		{
			set{ _sortnum=value;}
			get{return _sortnum;}
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

