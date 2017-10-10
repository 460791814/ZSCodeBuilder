using System;
namespace Model
{
	/// <summary>
	/// 楼宇配套服务
	/// </summary>
	[Serializable]
	public partial class tb_buildingservice:BaseModel
	{
		public tb_buildingservice()
		{}
		#region Model
		private string _id;
		private string _buildingid;
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
		/// 楼宇
		/// </summary>
		public string buildingid
		{
			set{ _buildingid=value;}
			get{return _buildingid;}
		}
		/// <summary>
		/// 服务名称
		/// </summary>
		public string name
		{
			set{ _name=value;}
			get{return _name;}
		}
		/// <summary>
		/// 服务说明
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

