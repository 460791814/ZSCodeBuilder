using System;
namespace Model
{
	/// <summary>
	/// 车位信息
	/// </summary>
	[Serializable]
	public partial class tb_park:BaseModel
	{
		public tb_park()
		{}
		#region Model
		private string _id;
		private int? _buildingid;
		private string _parkname;
		private string _address;
		private int? _parknumber;
		private string _fee;
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
		public int? buildingid
		{
			set{ _buildingid=value;}
			get{return _buildingid;}
		}
		/// <summary>
		/// 停车场名称
		/// </summary>
		public string parkname
		{
			set{ _parkname=value;}
			get{return _parkname;}
		}
		/// <summary>
		/// 停车场位置
		/// </summary>
		public string address
		{
			set{ _address=value;}
			get{return _address;}
		}
		/// <summary>
		/// 总车位数量
		/// </summary>
		public int? parknumber
		{
			set{ _parknumber=value;}
			get{return _parknumber;}
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

