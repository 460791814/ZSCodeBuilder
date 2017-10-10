using System;
namespace Model
{
	/// <summary>
	/// 楼宇
	/// </summary>
	[Serializable]
	public partial class tb_building:BaseModel
	{
		public tb_building()
		{}
		#region Model
		private string _id;
		private string _buildingname;
		private string _administrative;
		private string _provinceid;
		private string _cityid;
		private string _countyid;
		private string _address;
		private string _propertycompany;
		private string _propertycompanyintro;
		private string _traffic;
		private string _customer;
		private decimal? _longitude;
		private decimal? _latitude;
		private bool _isdel;
		private int? _sortnum;
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
		/// 楼宇名称
		/// </summary>
		public string buildingname
		{
			set{ _buildingname=value;}
			get{return _buildingname;}
		}
		/// <summary>
		/// 行政区域
		/// </summary>
		public string administrative
		{
			set{ _administrative=value;}
			get{return _administrative;}
		}
		/// <summary>
		/// 省
		/// </summary>
		public string provinceid
		{
			set{ _provinceid=value;}
			get{return _provinceid;}
		}
		/// <summary>
		/// 市
		/// </summary>
		public string cityid
		{
			set{ _cityid=value;}
			get{return _cityid;}
		}
		/// <summary>
		/// 县
		/// </summary>
		public string countyid
		{
			set{ _countyid=value;}
			get{return _countyid;}
		}
		/// <summary>
		/// 详细地址
		/// </summary>
		public string address
		{
			set{ _address=value;}
			get{return _address;}
		}
		/// <summary>
		/// 物业公司
		/// </summary>
		public string propertycompany
		{
			set{ _propertycompany=value;}
			get{return _propertycompany;}
		}
		/// <summary>
		/// 物业公司简介
		/// </summary>
		public string propertycompanyintro
		{
			set{ _propertycompanyintro=value;}
			get{return _propertycompanyintro;}
		}
		/// <summary>
		/// 交通信息
		/// </summary>
		public string traffic
		{
			set{ _traffic=value;}
			get{return _traffic;}
		}
		/// <summary>
		/// 客服电话
		/// </summary>
		public string customer
		{
			set{ _customer=value;}
			get{return _customer;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? longitude
		{
			set{ _longitude=value;}
			get{return _longitude;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? latitude
		{
			set{ _latitude=value;}
			get{return _latitude;}
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

