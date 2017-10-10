using System;
namespace Model
{
	/// <summary>
	/// 文件表
	/// </summary>
	[Serializable]
	public partial class tb_file:BaseModel
	{
		public tb_file()
		{}
		#region Model
		private string _id;
		private int? _typeid;
		private int? _filetypeid;
		private string _infoid;
		private string _name;
		private string _intro;
		private string _address;
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
		/// 1、楼宇外貌展示图，2、楼宇详细展示图，3、楼层展示图，4、房屋展示图，5、会议室展示图，6、餐厅展示图，7、文印室展示图
		/// </summary>
		public int? typeid
		{
			set{ _typeid=value;}
			get{return _typeid;}
		}
		/// <summary>
		/// 1：图片、2：Word、3：PPT...
		/// </summary>
		public int? filetypeid
		{
			set{ _filetypeid=value;}
			get{return _filetypeid;}
		}
		/// <summary>
		/// 楼宇ID、会议室ID、文印ID....
		/// </summary>
		public string infoid
		{
			set{ _infoid=value;}
			get{return _infoid;}
		}
		/// <summary>
		/// 文件名称
		/// </summary>
		public string name
		{
			set{ _name=value;}
			get{return _name;}
		}
		/// <summary>
		/// 文件简介
		/// </summary>
		public string intro
		{
			set{ _intro=value;}
			get{return _intro;}
		}
		/// <summary>
		/// 文件地址
		/// </summary>
		public string address
		{
			set{ _address=value;}
			get{return _address;}
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

