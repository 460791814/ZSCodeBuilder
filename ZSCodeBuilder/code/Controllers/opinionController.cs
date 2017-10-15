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
	/// 意见反馈
	/// </summary>
	public  class opinionController:Controller
	{
		D_opinion dopinion = new D_opinion();
		/// <summary>
		/// 意见反馈 列表
		/// </summary>
		public ActionResult opinionList(tb_opinion model)
		{
			int count = 0;
			ViewBag.opinionList = dopinion.GetList(model, ref count);
			ViewBag.page = Utils.ShowPage(count, model.PageSize, model.PageIndex, 5);
			return View();
		}

		/// <summary>
		/// 意见反馈 保存
		/// </summary>
		public JsonResult opinionSave(tb_opinion model)
		{
			if (model == null)
			{
				return ResultTool.jsonResult(false, "参数错误！");
			}
			if(!String.IsNullOrEmpty(model.id))
			{
				bool boolResult = dopinion.Update(model);
				return ResultTool.jsonResult(boolResult, boolResult ? "成功！" : "更新失败！");
			}
			else
			{
				model.id = Guid.NewGuid().ToString("N");
				bool boolResult = dopinion.Add(model);
				return ResultTool.jsonResult(boolResult, boolResult ? "成功！" : "添加失败！");
			}
		}

		/// <summary>
		/// 意见反馈 删除
		/// </summary>
		public JsonResult opinionDelete(tb_opinion model)
		{
			bool boolResult = dopinion.Delete(model);
			return ResultTool.jsonResult(boolResult, boolResult ? "成功！" : "删除失败！");
		}

		/// <summary>
		/// 意见反馈 详情
		/// </summary>
		public ActionResult opinionInfo(tb_opinion model)
		{
			model = dopinion.GetInfo(model);
			return View(model??new tb_opinion());
		}

	}
}

