using System;
namespace Model
{
	/// <summary>
	/// 套餐
	/// </summary>
	[Serializable]
	public partial class tb_combo:BaseModel
	{
		public tb_combo()
		{}
		#region Model
		private string _id;
		private string _name;
		private string _fee;
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
		/// 套餐名称
		/// </summary>
		public string name
		{
			set{ _name=value;}
			get{return _name;}
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

