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
	/// 租赁情况
	/// </summary>
	public  class roomleaseController:Controller
	{
		D_roomlease droomlease = new D_roomlease();
		/// <summary>
		/// 租赁情况 列表
		/// </summary>
		public ActionResult roomleaseList(tb_roomlease model)
		{
			int count = 0;
			ViewBag.roomleaseList = droomlease.GetList(model, ref count);
			ViewBag.page = Utils.ShowPage(count, model.PageSize, model.PageIndex, 5);
			return View();
		}

		/// <summary>
		/// 租赁情况 保存
		/// </summary>
		public JsonResult roomleaseSave(tb_roomlease model)
		{
			if (model == null)
			{
				return ResultTool.jsonResult(false, "参数错误！");
			}
			if(!String.IsNullOrEmpty(model.id))
			{
				bool boolResult = droomlease.Update(model);
				return ResultTool.jsonResult(boolResult, boolResult ? "成功！" : "更新失败！");
			}
			else
			{
				model.id = Guid.NewGuid().ToString("N");
				bool boolResult = droomlease.Add(model);
				return ResultTool.jsonResult(boolResult, boolResult ? "成功！" : "添加失败！");
			}
		}

		/// <summary>
		/// 租赁情况 删除
		/// </summary>
		public JsonResult roomleaseDelete(tb_roomlease model)
		{
			bool boolResult = droomlease.Delete(model);
			return ResultTool.jsonResult(boolResult, boolResult ? "成功！" : "删除失败！");
		}

		/// <summary>
		/// 租赁情况 详情
		/// </summary>
		public ActionResult roomleaseInfo(tb_roomlease model)
		{
			model = droomlease.GetInfo(model);
			return View(model??new tb_roomlease());
		}

	}
}

