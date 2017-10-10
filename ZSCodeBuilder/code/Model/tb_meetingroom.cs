using System;
namespace Model
{
	/// <summary>
	/// 会议室管理
	/// </summary>
	[Serializable]
	public partial class tb_meetingroom:BaseModel
	{
		public tb_meetingroom()
		{}
		#region Model
		private string _id;
		private string _buildingid;
		private string _intro;
		private string _phone;
		private string _floor;
		private string _roomnumber;
		private int? _desktype;
		private string _hold;
		private string _fee;
		private int? _isopen;
		private int? _roomtype;
		private string _package;
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
		/// 楼宇
		/// </summary>
		public string buildingid
		{
			set{ _buildingid=value;}
			get{return _buildingid;}
		}
		/// <summary>
		/// 会议服务介绍
		/// </summary>
		public string intro
		{
			set{ _intro=value;}
			get{return _intro;}
		}
		/// <summary>
		/// 客服电话
		/// </summary>
		public string phone
		{
			set{ _phone=value;}
			get{return _phone;}
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
		/// 桌型
		/// </summary>
		public int? desktype
		{
			set{ _desktype=value;}
			get{return _desktype;}
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
		/// 收费标准
		/// </summary>
		public string fee
		{
			set{ _fee=value;}
			get{return _fee;}
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
		/// 会议室类型
		/// </summary>
		public int? roomtype
		{
			set{ _roomtype=value;}
			get{return _roomtype;}
		}
		/// <summary>
		/// 会议室套餐
		/// </summary>
		public string package
		{
			set{ _package=value;}
			get{return _package;}
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

