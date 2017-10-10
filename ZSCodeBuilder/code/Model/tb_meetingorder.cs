using System;
namespace Model
{
	/// <summary>
	/// 会议服务 会议预定管理
	/// </summary>
	[Serializable]
	public partial class tb_meetingorder:BaseModel
	{
		public tb_meetingorder()
		{}
		#region Model
		private string _id;
		private string _orderno;
		private string _buildingid;
		private string _buildingname;
		private string _meetingroomid;
		private string _meetingroomname;
		private string _comboid;
		private string _comboname;
		private string _userid;
		private string _username;
		private string _userphone;
		private int? _meetingpersonnum;
		private DateTime? _meetingdate;
		private string _meetingamorpm;
		private string _status;
		private string _linkman;
		private string _linktel;
		private int? _meetingnum;
		private string _remark;
		private string _otherservice;
		private bool _isdel;
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
		/// 订单编号
		/// </summary>
		public string orderno
		{
			set{ _orderno=value;}
			get{return _orderno;}
		}
		/// <summary>
		/// 楼宇外键
		/// </summary>
		public string buildingid
		{
			set{ _buildingid=value;}
			get{return _buildingid;}
		}
		/// <summary>
		/// 楼宇名称
		/// </summary>
		public string buildingname
		{
			set{ _buildingname=value;}
			get{return _buildingname;}
		}
		/// <summary>
		/// 会议室表外键
		/// </summary>
		public string meetingroomid
		{
			set{ _meetingroomid=value;}
			get{return _meetingroomid;}
		}
		/// <summary>
		/// 会议室名称
		/// </summary>
		public string meetingroomname
		{
			set{ _meetingroomname=value;}
			get{return _meetingroomname;}
		}
		/// <summary>
		/// 套餐表外键
		/// </summary>
		public string comboid
		{
			set{ _comboid=value;}
			get{return _comboid;}
		}
		/// <summary>
		/// 套餐名称
		/// </summary>
		public string comboname
		{
			set{ _comboname=value;}
			get{return _comboname;}
		}
		/// <summary>
		/// 下单用户
		/// </summary>
		public string userid
		{
			set{ _userid=value;}
			get{return _userid;}
		}
		/// <summary>
		/// 下单用户姓名
		/// </summary>
		public string username
		{
			set{ _username=value;}
			get{return _username;}
		}
		/// <summary>
		/// 用户联系电话
		/// </summary>
		public string userphone
		{
			set{ _userphone=value;}
			get{return _userphone;}
		}
		/// <summary>
		/// 会议人数
		/// </summary>
		public int? meetingpersonnum
		{
			set{ _meetingpersonnum=value;}
			get{return _meetingpersonnum;}
		}
		/// <summary>
		/// 会议时间
		/// </summary>
		public DateTime? meetingdate
		{
			set{ _meetingdate=value;}
			get{return _meetingdate;}
		}
		/// <summary>
		/// 上午或下午
		/// </summary>
		public string meetingAMorPM
		{
			set{ _meetingamorpm=value;}
			get{return _meetingamorpm;}
		}
		/// <summary>
		/// 订单状态
		/// </summary>
		public string status
		{
			set{ _status=value;}
			get{return _status;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string linkman
		{
			set{ _linkman=value;}
			get{return _linkman;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string linktel
		{
			set{ _linktel=value;}
			get{return _linktel;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? meetingnum
		{
			set{ _meetingnum=value;}
			get{return _meetingnum;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string remark
		{
			set{ _remark=value;}
			get{return _remark;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string otherservice
		{
			set{ _otherservice=value;}
			get{return _otherservice;}
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
		public DateTime? addtime
		{
			set{ _addtime=value;}
			get{return _addtime;}
		}
		#endregion Model

	}
}

