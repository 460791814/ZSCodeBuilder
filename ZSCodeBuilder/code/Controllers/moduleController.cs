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
	/// 权限模块
	/// </summary>
	public  class moduleController:Controller
	{
		D_module dmodule = new D_module();
		/// <summary>
		/// 权限模块 列表
		/// </summary>
		public ActionResult moduleList(tb_module model)
		{
			int count = 0;
			ViewBag.moduleList = dmodule.GetList(model, ref count);
			ViewBag.page = Utils.ShowPage(count, model.PageSize, model.PageIndex, 5);
			return View();
		}

		/// <summary>
		/// 权限模块 保存
		/// </summary>
		public JsonResult moduleSave(tb_module model)
		{
			if (model == null)
			{
				return ResultTool.jsonResult(false, "参数错误！");
			}
			if(!String.IsNullOrEmpty(model.id))
			{
				bool boolResult = dmodule.Update(model);
				return ResultTool.jsonResult(boolResult, boolResult ? "成功！" : "更新失败！");
			}
			else
			{
				model.id = Guid.NewGuid().ToString("N");
				bool boolResult = dmodule.Add(model);
				return ResultTool.jsonResult(boolResult, boolResult ? "成功！" : "添加失败！");
			}
		}

		/// <summary>
		/// 权限模块 删除
		/// </summary>
		public JsonResult moduleDelete(tb_module model)
		{
			bool boolResult = dmodule.Delete(model);
			return ResultTool.jsonResult(boolResult, boolResult ? "成功！" : "删除失败！");
		}

		/// <summary>
		/// 权限模块 详情
		/// </summary>
		public ActionResult moduleInfo(tb_module model)
		{
			model = dmodule.GetInfo(model);
			return View(model??new tb_module());
		}

	}
}

