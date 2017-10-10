using System;
namespace Model
{
	/// <summary>
	/// 角色
	/// </summary>
	[Serializable]
	public partial class tb_role:BaseModel
	{
		public tb_role()
		{}
		#region Model
		private string _id;
		private string _name;
		/// <summary>
		/// 
		/// </summary>
		public string id
		{
			set{ _id=value;}
			get{return _id;}
		}
		/// <summary>
		/// 角色名称
		/// </summary>
		public string name
		{
			set{ _name=value;}
			get{return _name;}
		}
		#endregion Model

	}
}

