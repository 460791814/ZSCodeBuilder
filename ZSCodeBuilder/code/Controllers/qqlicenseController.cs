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
	/// qq
	/// </summary>
	public  class qqlicenseController:Controller
	{
		D_qqlicense dqqlicense = new D_qqlicense();
		/// <summary>
		/// qq 列表
		/// </summary>
		public ActionResult qqlicenseList(tb_qqlicense model)
		{
			int count = 0;
			ViewBag.qqlicenseList = dqqlicense.GetList(model, ref count);
			ViewBag.page = Utils.ShowPage(count, model.PageSize, model.PageIndex, 5);
			return View();
		}

		/// <summary>
		/// qq 保存
		/// </summary>
		public JsonResult qqlicenseSave(tb_qqlicense model)
		{
			if (model == null)
			{
				return ResultTool.jsonResult(false, "参数错误！");
			}
			if(!String.IsNullOrEmpty(model.id))
			{
				bool boolResult = dqqlicense.Update(model);
				return ResultTool.jsonResult(boolResult, boolResult ? "成功！" : "更新失败！");
			}
			else
			{
				model.id = Guid.NewGuid().ToString("N");
				bool boolResult = dqqlicense.Add(model);
				return ResultTool.jsonResult(boolResult, boolResult ? "成功！" : "添加失败！");
			}
		}

		/// <summary>
		/// qq 删除
		/// </summary>
		public JsonResult qqlicenseDelete(tb_qqlicense model)
		{
			bool boolResult = dqqlicense.Delete(model);
			return ResultTool.jsonResult(boolResult, boolResult ? "成功！" : "删除失败！");
		}

		/// <summary>
		/// qq 详情
		/// </summary>
		public ActionResult qqlicenseInfo(tb_qqlicense model)
		{
			model = dqqlicense.GetInfo(model);
			return View(model??new tb_qqlicense());
		}

	}
}

