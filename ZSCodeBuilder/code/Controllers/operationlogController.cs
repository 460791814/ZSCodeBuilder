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
	/// 操作日志
	/// </summary>
	public  class operationlogController:Controller
	{
		D_operationlog doperationlog = new D_operationlog();
		/// <summary>
		/// 操作日志 列表
		/// </summary>
		public ActionResult operationlogList(tb_operationlog model)
		{
			int count = 0;
			ViewBag.operationlogList = doperationlog.GetList(model, ref count);
			ViewBag.page = Utils.ShowPage(count, model.PageSize, model.PageIndex, 5);
			return View();
		}

		/// <summary>
		/// 操作日志 保存
		/// </summary>
		public JsonResult operationlogSave(tb_operationlog model)
		{
			if (model == null)
			{
				return ResultTool.jsonResult(false, "参数错误！");
			}
			if(!String.IsNullOrEmpty(model.id))
			{
				bool boolResult = doperationlog.Update(model);
				return ResultTool.jsonResult(boolResult, boolResult ? "成功！" : "更新失败！");
			}
			else
			{
				model.id = Guid.NewGuid().ToString("N");
				bool boolResult = doperationlog.Add(model);
				return ResultTool.jsonResult(boolResult, boolResult ? "成功！" : "添加失败！");
			}
		}

		/// <summary>
		/// 操作日志 删除
		/// </summary>
		public JsonResult operationlogDelete(tb_operationlog model)
		{
			bool boolResult = doperationlog.Delete(model);
			return ResultTool.jsonResult(boolResult, boolResult ? "成功！" : "删除失败！");
		}

		/// <summary>
		/// 操作日志 详情
		/// </summary>
		public ActionResult operationlogInfo(tb_operationlog model)
		{
			model = doperationlog.GetInfo(model);
			return View(model??new tb_operationlog());
		}

	}
}

