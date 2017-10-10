using System;
namespace Model
{
	/// <summary>
	/// 套餐服务内容
	/// </summary>
	[Serializable]
	public partial class tb_comboservice:BaseModel
	{
		public tb_comboservice()
		{}
		#region Model
		private string _comboid;
		private string _name;
		private string _intro;
		private string _id;
		private DateTime? _addtime;
		/// <summary>
		/// 套餐ID
		/// </summary>
		public string comboid
		{
			set{ _comboid=value;}
			get{return _comboid;}
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
		public string id
		{
			set{ _id=value;}
			get{return _id;}
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

