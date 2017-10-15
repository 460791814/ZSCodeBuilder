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
	/// 基础数据
	/// </summary>
	public  class statusController:Controller
	{
		D_status dstatus = new D_status();
		/// <summary>
		/// 基础数据 列表
		/// </summary>
		public ActionResult statusList(tb_status model)
		{
			int count = 0;
			ViewBag.statusList = dstatus.GetList(model, ref count);
			ViewBag.page = Utils.ShowPage(count, model.PageSize, model.PageIndex, 5);
			return View();
		}

		/// <summary>
		/// 基础数据 保存
		/// </summary>
		public JsonResult statusSave(tb_status model)
		{
			if (model == null)
			{
				return ResultTool.jsonResult(false, "参数错误！");
			}
			if(!String.IsNullOrEmpty(model.id))
			{
				bool boolResult = dstatus.Update(model);
				return ResultTool.jsonResult(boolResult, boolResult ? "成功！" : "更新失败！");
			}
			else
			{
				model.id = Guid.NewGuid().ToString("N");
				bool boolResult = dstatus.Add(model);
				return ResultTool.jsonResult(boolResult, boolResult ? "成功！" : "添加失败！");
			}
		}

		/// <summary>
		/// 基础数据 删除
		/// </summary>
		public JsonResult statusDelete(tb_status model)
		{
			bool boolResult = dstatus.Delete(model);
			return ResultTool.jsonResult(boolResult, boolResult ? "成功！" : "删除失败！");
		}

		/// <summary>
		/// 基础数据 详情
		/// </summary>
		public ActionResult statusInfo(tb_status model)
		{
			model = dstatus.GetInfo(model);
			return View(model??new tb_status());
		}

	}
}

