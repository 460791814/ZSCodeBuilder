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
	/// 收费标准
	/// </summary>
	public  class copyroomfeeController:Controller
	{
		D_copyroomfee dcopyroomfee = new D_copyroomfee();
		/// <summary>
		/// 收费标准 列表
		/// </summary>
		public ActionResult copyroomfeeList(tb_copyroomfee model)
		{
			int count = 0;
			ViewBag.copyroomfeeList = dcopyroomfee.GetList(model, ref count);
			ViewBag.page = Utils.ShowPage(count, model.PageSize, model.PageIndex, 5);
			return View();
		}

		/// <summary>
		/// 收费标准 保存
		/// </summary>
		public JsonResult copyroomfeeSave(tb_copyroomfee model)
		{
			if (model == null)
			{
				return ResultTool.jsonResult(false, "参数错误！");
			}
			if(!String.IsNullOrEmpty(model.id))
			{
				bool boolResult = dcopyroomfee.Update(model);
				return ResultTool.jsonResult(boolResult, boolResult ? "成功！" : "更新失败！");
			}
			else
			{
				model.id = Guid.NewGuid().ToString("N");
				bool boolResult = dcopyroomfee.Add(model);
				return ResultTool.jsonResult(boolResult, boolResult ? "成功！" : "添加失败！");
			}
		}

		/// <summary>
		/// 收费标准 删除
		/// </summary>
		public JsonResult copyroomfeeDelete(tb_copyroomfee model)
		{
			bool boolResult = dcopyroomfee.Delete(model);
			return ResultTool.jsonResult(boolResult, boolResult ? "成功！" : "删除失败！");
		}

		/// <summary>
		/// 收费标准 详情
		/// </summary>
		public ActionResult copyroomfeeInfo(tb_copyroomfee model)
		{
			model = dcopyroomfee.GetInfo(model);
			return View(model??new tb_copyroomfee());
		}

	}
}

