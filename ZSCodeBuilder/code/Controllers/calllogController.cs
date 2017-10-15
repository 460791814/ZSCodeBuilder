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
	/// 呼叫记录
	/// </summary>
	public  class calllogController:Controller
	{
		D_calllog dcalllog = new D_calllog();
		/// <summary>
		/// 呼叫记录 列表
		/// </summary>
		public ActionResult calllogList(tb_calllog model)
		{
			int count = 0;
			ViewBag.calllogList = dcalllog.GetList(model, ref count);
			ViewBag.page = Utils.ShowPage(count, model.PageSize, model.PageIndex, 5);
			return View();
		}

		/// <summary>
		/// 呼叫记录 保存
		/// </summary>
		public JsonResult calllogSave(tb_calllog model)
		{
			if (model == null)
			{
				return ResultTool.jsonResult(false, "参数错误！");
			}
			if(!String.IsNullOrEmpty(model.id))
			{
				bool boolResult = dcalllog.Update(model);
				return ResultTool.jsonResult(boolResult, boolResult ? "成功！" : "更新失败！");
			}
			else
			{
				model.id = Guid.NewGuid().ToString("N");
				bool boolResult = dcalllog.Add(model);
				return ResultTool.jsonResult(boolResult, boolResult ? "成功！" : "添加失败！");
			}
		}

		/// <summary>
		/// 呼叫记录 删除
		/// </summary>
		public JsonResult calllogDelete(tb_calllog model)
		{
			bool boolResult = dcalllog.Delete(model);
			return ResultTool.jsonResult(boolResult, boolResult ? "成功！" : "删除失败！");
		}

		/// <summary>
		/// 呼叫记录 详情
		/// </summary>
		public ActionResult calllogInfo(tb_calllog model)
		{
			model = dcalllog.GetInfo(model);
			return View(model??new tb_calllog());
		}

	}
}

