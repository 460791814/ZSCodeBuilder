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
	/// 市
	/// </summary>
	public  class cityController:Controller
	{
		D_city dcity = new D_city();
		/// <summary>
		/// 市 列表
		/// </summary>
		public ActionResult cityList(tb_city model)
		{
			int count = 0;
			ViewBag.cityList = dcity.GetList(model, ref count);
			ViewBag.page = Utils.ShowPage(count, model.PageSize, model.PageIndex, 5);
			return View();
		}

		/// <summary>
		/// 市 保存
		/// </summary>
		public JsonResult citySave(tb_city model)
		{
			if (model == null)
			{
				return ResultTool.jsonResult(false, "参数错误！");
			}
			if(!String.IsNullOrEmpty(model.id))
			{
				bool boolResult = dcity.Update(model);
				return ResultTool.jsonResult(boolResult, boolResult ? "成功！" : "更新失败！");
			}
			else
			{
				model.id = Guid.NewGuid().ToString("N");
				bool boolResult = dcity.Add(model);
				return ResultTool.jsonResult(boolResult, boolResult ? "成功！" : "添加失败！");
			}
		}

		/// <summary>
		/// 市 删除
		/// </summary>
		public JsonResult cityDelete(tb_city model)
		{
			bool boolResult = dcity.Delete(model);
			return ResultTool.jsonResult(boolResult, boolResult ? "成功！" : "删除失败！");
		}

		/// <summary>
		/// 市 详情
		/// </summary>
		public ActionResult cityInfo(tb_city model)
		{
			model = dcity.GetInfo(model);
			return View(model??new tb_city());
		}

	}
}

