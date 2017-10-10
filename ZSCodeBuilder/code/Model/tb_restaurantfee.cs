using System;
namespace Model
{
	/// <summary>
	/// 收费标准
	/// </summary>
	[Serializable]
	public partial class tb_restaurantfee:BaseModel
	{
		public tb_restaurantfee()
		{}
		#region Model
		private string _id;
		private string _restaurantid;
		private string _name;
		private string _intro;
		private decimal? _price;
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
		/// 餐厅id
		/// </summary>
		public string restaurantid
		{
			set{ _restaurantid=value;}
			get{return _restaurantid;}
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
		/// 介绍
		/// </summary>
		public string intro
		{
			set{ _intro=value;}
			get{return _intro;}
		}
		/// <summary>
		/// 价格
		/// </summary>
		public decimal? price
		{
			set{ _price=value;}
			get{return _price;}
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

