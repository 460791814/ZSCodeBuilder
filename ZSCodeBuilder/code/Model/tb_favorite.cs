using System;
namespace Model
{
	/// <summary>
	/// 我的收藏
	/// </summary>
	[Serializable]
	public partial class tb_favorite:BaseModel
	{
		public tb_favorite()
		{}
		#region Model
		private string _id;
		private string _favoritetype= "NULL";
		private string _favoriteid= "NULL";
		private DateTime? _favoritedate;
		private bool _isdel= false;
		private string _favoriteintro= "NULL";
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
		/// 
		/// </summary>
		public string favoritetype
		{
			set{ _favoritetype=value;}
			get{return _favoritetype;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string favoriteid
		{
			set{ _favoriteid=value;}
			get{return _favoriteid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? favoritedate
		{
			set{ _favoritedate=value;}
			get{return _favoritedate;}
		}
		/// <summary>
		/// 
		/// </summary>
		public bool isdel
		{
			set{ _isdel=value;}
			get{return _isdel;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string favoriteintro
		{
			set{ _favoriteintro=value;}
			get{return _favoriteintro;}
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

