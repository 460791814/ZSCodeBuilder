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
		public JsonResult role_moduleSave(tb_role_module model)
		{
			if (model == null)
			{
				return ResultTool.jsonResult(false, "参数错误！");
			}
			if(!String.IsNullOrEmpty(model.roleid))
			{
				bool boolResult = drole_module.Update(model);
				return ResultTool.jsonResult(boolResult, boolResult ? "成功！" : "更新失败！");
			}
			else
			{
				model.roleid = Guid.NewGuid().ToString("N");
				bool boolResult = drole_module.Add(model);
				return ResultTool.jsonResult(boolResult, boolResult ? "成功！" : "添加失败！");
			}
		}

		/// <summary>
		/// 权限模块关系表 删除
		/// </summary>
		public JsonResult role_moduleDelete(tb_role_module model)
		{
			bool boolResult = drole_module.Delete(model);
			return ResultTool.jsonResult(boolResult, boolResult ? "成功！" : "删除失败！");
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

