using System;
namespace Model
{
	/// <summary>
	/// 服务类别
	/// </summary>
	[Serializable]
	public partial class tb_copyroomservice:BaseModel
	{
		public tb_copyroomservice()
		{}
		#region Model
		private string _id;
		private string _copyroomid;
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
		/// 文印室id
		/// </summary>
		public string copyroomid
		{
			set{ _copyroomid=value;}
			get{return _copyroomid;}
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

