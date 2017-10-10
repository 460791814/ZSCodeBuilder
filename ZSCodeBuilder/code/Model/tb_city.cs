using System;
namespace Model
{
	/// <summary>
	/// 市
	/// </summary>
	[Serializable]
	public partial class tb_city:BaseModel
	{
		public tb_city()
		{}
		#region Model
		private string _cityname;
		private string _id;
		/// <summary>
		/// 市名称
		/// </summary>
		public string cityname
		{
			set{ _cityname=value;}
			get{return _cityname;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string id
		{
			set{ _id=value;}
			get{return _id;}
		}
		#endregion Model

	}
}

