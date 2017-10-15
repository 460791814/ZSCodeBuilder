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
	/// 套餐
	/// </summary>
	public  class comboController:Controller
	{
		D_combo dcombo = new D_combo();
		/// <summary>
		/// 套餐 列表
		/// </summary>
		public ActionResult comboList(tb_combo model)
		{
			int count = 0;
			ViewBag.comboList = dcombo.GetList(model, ref count);
			ViewBag.page = Utils.ShowPage(count, model.PageSize, model.PageIndex, 5);
			return View();
		}

		/// <summary>
		/// 套餐 保存
		/// </summary>
		public JsonResult comboSave(tb_combo model)
		{
			if (model == null)
			{
				return ResultTool.jsonResult(false, "参数错误！");
			}
			if(!String.IsNullOrEmpty(model.id))
			{
				bool boolResult = dcombo.Update(model);
				return ResultTool.jsonResult(boolResult, boolResult ? "成功！" : "更新失败！");
			}
			else
			{
				model.id = Guid.NewGuid().ToString("N");
				bool boolResult = dcombo.Add(model);
				return ResultTool.jsonResult(boolResult, boolResult ? "成功！" : "添加失败！");
			}
		}

		/// <summary>
		/// 套餐 删除
		/// </summary>
		public JsonResult comboDelete(tb_combo model)
		{
			bool boolResult = dcombo.Delete(model);
			return ResultTool.jsonResult(boolResult, boolResult ? "成功！" : "删除失败！");
		}

		/// <summary>
		/// 套餐 详情
		/// </summary>
		public ActionResult comboInfo(tb_combo model)
		{
			model = dcombo.GetInfo(model);
			return View(model??new tb_combo());
		}

	}
}

