using System;
namespace Model
{
	/// <summary>
	/// 餐饮美食
	/// </summary>
	[Serializable]
	public partial class tb_restaurant:BaseModel
	{
		public tb_restaurant()
		{}
		#region Model
		private string _id;
		private string _buildingid;
		private string _name;
		private string _address;
		private string _hold;
		private string _phone;
		private string _dinnertime;
		private int? _isopen;
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
		/// 餐厅名称
		/// </summary>
		public string name
		{
			set{ _name=value;}
			get{return _name;}
		}
		/// <summary>
		/// 餐厅位置
		/// </summary>
		public string address
		{
			set{ _address=value;}
			get{return _address;}
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
		/// 联系电话
		/// </summary>
		public string phone
		{
			set{ _phone=value;}
			get{return _phone;}
		}
		/// <summary>
		/// 就餐时间
		/// </summary>
		public string dinnertime
		{
			set{ _dinnertime=value;}
			get{return _dinnertime;}
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
		public DateTime? addtime
		{
			set{ _addtime=value;}
			get{return _addtime;}
		}
		#endregion Model

	}
}

