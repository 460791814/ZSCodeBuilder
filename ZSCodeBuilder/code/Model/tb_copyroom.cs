using System;
namespace Model
{
	/// <summary>
	/// 文印设计
	/// </summary>
	[Serializable]
	public partial class tb_copyroom:BaseModel
	{
		public tb_copyroom()
		{}
		#region Model
		private string _buildingid;
		private string _name;
		private string _address;
		private string _phone;
		private int? _isopen;
		private string _intro;
		private string _id;
		private DateTime? _addtime;
		/// <summary>
		/// 楼宇
		/// </summary>
		public string buildingid
		{
			set{ _buildingid=value;}
			get{return _buildingid;}
		}
		/// <summary>
		/// 文印室名称
		/// </summary>
		public string name
		{
			set{ _name=value;}
			get{return _name;}
		}
		/// <summary>
		/// 文印室位置
		/// </summary>
		public string address
		{
			set{ _address=value;}
			get{return _address;}
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
		/// 是否开放
		/// </summary>
		public int? isopen
		{
			set{ _isopen=value;}
			get{return _isopen;}
		}
		/// <summary>
		/// 服务介绍
		/// </summary>
		public string intro
		{
			set{ _intro=value;}
			get{return _intro;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string id
		{
			set{ _id=value;}
			get{return _id;}
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

