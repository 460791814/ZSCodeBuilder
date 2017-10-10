using System;
namespace Model
{
	/// <summary>
	/// 省市区县
	/// </summary>
	[Serializable]
	public partial class tb_pcctv:BaseModel
	{
		public tb_pcctv()
		{}
		#region Model
		private string _pid;
		private string _id;
		private int? _pcctvlevel;
		private string _pcctvname;
		private string _classification;
		private string _remark;
		/// <summary>
		/// 
		/// </summary>
		public string pid
		{
			set{ _pid=value;}
			get{return _pid;}
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
		public int? pcctvlevel
		{
			set{ _pcctvlevel=value;}
			get{return _pcctvlevel;}
		}
		/// <summary>
		/// 名称
		/// </summary>
		public string pcctvname
		{
			set{ _pcctvname=value;}
			get{return _pcctvname;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string classification
		{
			set{ _classification=value;}
			get{return _classification;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string remark
		{
			set{ _remark=value;}
			get{return _remark;}
		}
		#endregion Model

	}
}

