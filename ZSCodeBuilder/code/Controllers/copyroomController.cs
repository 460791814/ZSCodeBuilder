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
	/// 文印设计
	/// </summary>
	public  class copyroomController:Controller
	{
		D_copyroom dcopyroom = new D_copyroom();
		/// <summary>
		/// 文印设计 列表
		/// </summary>
		public ActionResult copyroomList(tb_copyroom model)
		{
			int count = 0;
			ViewBag.copyroomList = dcopyroom.GetList(model, ref count);
			ViewBag.page = Utils.ShowPage(count, model.PageSize, model.PageIndex, 5);
			return View();
		}

		/// <summary>
		/// 文印设计 保存
		/// </summary>
		public JsonResult copyroomSave(tb_copyroom model)
		{
			if (model == null)
			{
				return ResultTool.jsonResult(false, "参数错误！");
			}
			if(!String.IsNullOrEmpty(model.id))
			{
				bool boolResult = dcopyroom.Update(model);
				return ResultTool.jsonResult(boolResult, boolResult ? "成功！" : "更新失败！");
			}
			else
			{
				model.id = Guid.NewGuid().ToString("N");
				bool boolResult = dcopyroom.Add(model);
				return ResultTool.jsonResult(boolResult, boolResult ? "成功！" : "添加失败！");
			}
		}

		/// <summary>
		/// 文印设计 删除
		/// </summary>
		public JsonResult copyroomDelete(tb_copyroom model)
		{
			bool boolResult = dcopyroom.Delete(model);
			return ResultTool.jsonResult(boolResult, boolResult ? "成功！" : "删除失败！");
		}

		/// <summary>
		/// 文印设计 详情
		/// </summary>
		public ActionResult copyroomInfo(tb_copyroom model)
		{
			model = dcopyroom.GetInfo(model);
			return View(model??new tb_copyroom());
		}

	}
}

