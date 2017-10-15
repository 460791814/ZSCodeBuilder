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
	/// 周边配套介绍
	/// </summary>
	public  class buildingaroundController:Controller
	{
		D_buildingaround dbuildingaround = new D_buildingaround();
		/// <summary>
		/// 周边配套介绍 列表
		/// </summary>
		public ActionResult buildingaroundList(tb_buildingaround model)
		{
			int count = 0;
			ViewBag.buildingaroundList = dbuildingaround.GetList(model, ref count);
			ViewBag.page = Utils.ShowPage(count, model.PageSize, model.PageIndex, 5);
			return View();
		}

		/// <summary>
		/// 周边配套介绍 保存
		/// </summary>
		public JsonResult buildingaroundSave(tb_buildingaround model)
		{
			if (model == null)
			{
				return ResultTool.jsonResult(false, "参数错误！");
			}
			if(!String.IsNullOrEmpty(model.id))
			{
				bool boolResult = dbuildingaround.Update(model);
				return ResultTool.jsonResult(boolResult, boolResult ? "成功！" : "更新失败！");
			}
			else
			{
				model.id = Guid.NewGuid().ToString("N");
				bool boolResult = dbuildingaround.Add(model);
				return ResultTool.jsonResult(boolResult, boolResult ? "成功！" : "添加失败！");
			}
		}

		/// <summary>
		/// 周边配套介绍 删除
		/// </summary>
		public JsonResult buildingaroundDelete(tb_buildingaround model)
		{
			bool boolResult = dbuildingaround.Delete(model);
			return ResultTool.jsonResult(boolResult, boolResult ? "成功！" : "删除失败！");
		}

		/// <summary>
		/// 周边配套介绍 详情
		/// </summary>
		public ActionResult buildingaroundInfo(tb_buildingaround model)
		{
			model = dbuildingaround.GetInfo(model);
			return View(model??new tb_buildingaround());
		}

	}
}

