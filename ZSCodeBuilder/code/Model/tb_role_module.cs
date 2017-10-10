using System;
namespace Model
{
	/// <summary>
	/// 权限模块关系表
	/// </summary>
	[Serializable]
	public partial class tb_role_module:BaseModel
	{
		public tb_role_module()
		{}
		#region Model
		private string _roleid;
		private string _moduleid;
		/// <summary>
		/// 身份id
		/// </summary>
		public string roleid
		{
			set{ _roleid=value;}
			get{return _roleid;}
		}
		/// <summary>
		/// 模块id
		/// </summary>
		public string moduleid
		{
			set{ _moduleid=value;}
			get{return _moduleid;}
		}
		#endregion Model

	}
}

