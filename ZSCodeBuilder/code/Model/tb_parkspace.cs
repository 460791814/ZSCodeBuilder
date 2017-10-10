using System;
namespace Model
{
	/// <summary>
	/// 各类车型车位数量
	/// </summary>
	[Serializable]
	public partial class tb_parkspace:BaseModel
	{
		public tb_parkspace()
		{}
		#region Model
		private string _id;
		private string _parkid;
		private string _name;
		private int? _number;
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
		/// 停车场ID
		/// </summary>
		public string parkid
		{
			set{ _parkid=value;}
			get{return _parkid;}
		}
		/// <summary>
		/// 车型名称
		/// </summary>
		public string name
		{
			set{ _name=value;}
			get{return _name;}
		}
		/// <summary>
		/// 数量
		/// </summary>
		public int? number
		{
			set{ _number=value;}
			get{return _number;}
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

