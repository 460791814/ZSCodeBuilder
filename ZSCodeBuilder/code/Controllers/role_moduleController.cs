using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DAL;
using Model;
using Comp;
namespace cnooc.property.manage.Controllers
{
	/// <summary>
	/// 权限模块关系表
	/// </summary>
	public  class role_moduleController:Controller
	{
		D_role_module drole_module = new D_role_module();
		/// <summary>
		/// 权限模块关系表 列表
		/// </summary>
		public ActionResult role_moduleList(tb_role_module model)
		{
			int count = 0;
			ViewBag.role_moduleList = drole_module.GetList(model, ref count);
			ViewBag.page = Utils.ShowPage(count, model.PageSize, model.PageIndex, 5);
			return View();
		}

		/// <summary>
		/// 权限模块关系表 保存
		/// </summary>
		public bool role_moduleSave(tb_role_module model)
		{
			if (model == null)
			{
				return false;
			}
			if(!String.IsNullOrEmpty(model.roleid))
			{
				 return drole_module.Update(model);
			}
			model.roleid = Guid.NewGuid().ToString("N");
			return drole_module.Add(model);
		}

		/// <summary>
		/// 权限模块关系表 删除
		/// </summary>
		public bool role_moduleDelete(tb_role_module model)
		{
			return drole_module.Delete(model);
		}

		/// <summary>
		/// 权限模块关系表 详情
		/// </summary>
		public ActionResult role_moduleInfo(tb_role_module model)
		{
			model = drole_module.GetInfo(model);
			return View(model??new tb_role_module());
		}

	}
}

