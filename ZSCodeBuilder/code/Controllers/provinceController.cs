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
	/// 省
	/// </summary>
	public  class provinceController:Controller
	{
		D_province dprovince = new D_province();
		/// <summary>
		/// 省 列表
		/// </summary>
		public ActionResult provinceList(tb_province model)
		{
			int count = 0;
			ViewBag.provinceList = dprovince.GetList(model, ref count);
			ViewBag.page = Utils.ShowPage(count, model.PageSize, model.PageIndex, 5);
			return View();
		}

		/// <summary>
		/// 省 保存
		/// </summary>
		public JsonResult provinceSave(tb_province model)
		{
			if (model == null)
			{
				return ResultTool.jsonResult(false, "参数错误！");
			}
			if(!String.IsNullOrEmpty(model.id))
			{
				bool boolResult = dprovince.Update(model);
				return ResultTool.jsonResult(boolResult, boolResult ? "成功！" : "更新失败！");
			}
			else
			{
				model.id = Guid.NewGuid().ToString("N");
				bool boolResult = dprovince.Add(model);
				return ResultTool.jsonResult(boolResult, boolResult ? "成功！" : "添加失败！");
			}
		}

		/// <summary>
		/// 省 删除
		/// </summary>
		public JsonResult provinceDelete(tb_province model)
		{
			bool boolResult = dprovince.Delete(model);
			return ResultTool.jsonResult(boolResult, boolResult ? "成功！" : "删除失败！");
		}

		/// <summary>
		/// 省 详情
		/// </summary>
		public ActionResult provinceInfo(tb_province model)
		{
			model = dprovince.GetInfo(model);
			return View(model??new tb_province());
		}

	}
}

