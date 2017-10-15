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
	/// 角色
	/// </summary>
	public  class roleController:Controller
	{
		D_role drole = new D_role();
		/// <summary>
		/// 角色 列表
		/// </summary>
		public ActionResult roleList(tb_role model)
		{
			int count = 0;
			ViewBag.roleList = drole.GetList(model, ref count);
			ViewBag.page = Utils.ShowPage(count, model.PageSize, model.PageIndex, 5);
			return View();
		}

		/// <summary>
		/// 角色 保存
		/// </summary>
		public JsonResult roleSave(tb_role model)
		{
			if (model == null)
			{
				return ResultTool.jsonResult(false, "参数错误！");
			}
			if(!String.IsNullOrEmpty(model.id))
			{
				bool boolResult = drole.Update(model);
				return ResultTool.jsonResult(boolResult, boolResult ? "成功！" : "更新失败！");
			}
			else
			{
				model.id = Guid.NewGuid().ToString("N");
				bool boolResult = drole.Add(model);
				return ResultTool.jsonResult(boolResult, boolResult ? "成功！" : "添加失败！");
			}
		}

		/// <summary>
		/// 角色 删除
		/// </summary>
		public JsonResult roleDelete(tb_role model)
		{
			bool boolResult = drole.Delete(model);
			return ResultTool.jsonResult(boolResult, boolResult ? "成功！" : "删除失败！");
		}

		/// <summary>
		/// 角色 详情
		/// </summary>
		public ActionResult roleInfo(tb_role model)
		{
			model = drole.GetInfo(model);
			return View(model??new tb_role());
		}

	}
}

