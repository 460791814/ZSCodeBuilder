using System;
namespace Model
{
	/// <summary>
	/// 会议室配套设备设施
	/// </summary>
	[Serializable]
	public partial class tb_meetingroomdevice:BaseModel
	{
		public tb_meetingroomdevice()
		{}
		#region Model
		private string _id;
		private string _meetingroomid;
		private string _name;
		private string _intro;
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
		/// 会议室ID
		/// </summary>
		public string meetingroomid
		{
			set{ _meetingroomid=value;}
			get{return _meetingroomid;}
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
		/// 说明
		/// </summary>
		public string intro
		{
			set{ _intro=value;}
			get{return _intro;}
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

