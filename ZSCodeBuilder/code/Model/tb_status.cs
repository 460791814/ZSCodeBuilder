using System;
namespace Model
{
	/// <summary>
	/// 基础数据
	/// </summary>
	[Serializable]
	public partial class tb_status:BaseModel
	{
		public tb_status()
		{}
		#region Model
		private string _name;
		private string _code;
		private string _remark;
		private string _id;
		private int? _sortnum;
		/// <summary>
		/// 名称
		/// </summary>
		public string name
		{
			set{ _name=value;}
			get{return _name;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string code
		{
			set{ _code=value;}
			get{return _code;}
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
		public string id
		{
			set{ _id=value;}
			get{return _id;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? sortnum
		{
			set{ _sortnum=value;}
			get{return _sortnum;}
		}
		#endregion Model

	}
}

