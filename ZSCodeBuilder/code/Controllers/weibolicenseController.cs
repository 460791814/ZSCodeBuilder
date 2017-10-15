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
	/// 微博
	/// </summary>
	public  class weibolicenseController:Controller
	{
		D_weibolicense dweibolicense = new D_weibolicense();
		/// <summary>
		/// 微博 列表
		/// </summary>
		public ActionResult weibolicenseList(tb_weibolicense model)
		{
			int count = 0;
			ViewBag.weibolicenseList = dweibolicense.GetList(model, ref count);
			ViewBag.page = Utils.ShowPage(count, model.PageSize, model.PageIndex, 5);
			return View();
		}

		/// <summary>
		/// 微博 保存
		/// </summary>
		public JsonResult weibolicenseSave(tb_weibolicense model)
		{
			if (model == null)
			{
				return ResultTool.jsonResult(false, "参数错误！");
			}
			if(!String.IsNullOrEmpty(model.id))
			{
				bool boolResult = dweibolicense.Update(model);
				return ResultTool.jsonResult(boolResult, boolResult ? "成功！" : "更新失败！");
			}
			else
			{
				model.id = Guid.NewGuid().ToString("N");
				bool boolResult = dweibolicense.Add(model);
				return ResultTool.jsonResult(boolResult, boolResult ? "成功！" : "添加失败！");
			}
		}

		/// <summary>
		/// 微博 删除
		/// </summary>
		public JsonResult weibolicenseDelete(tb_weibolicense model)
		{
			bool boolResult = dweibolicense.Delete(model);
			return ResultTool.jsonResult(boolResult, boolResult ? "成功！" : "删除失败！");
		}

		/// <summary>
		/// 微博 详情
		/// </summary>
		public ActionResult weibolicenseInfo(tb_weibolicense model)
		{
			model = dweibolicense.GetInfo(model);
			return View(model??new tb_weibolicense());
		}

	}
}

