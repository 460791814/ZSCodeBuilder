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
	/// 微信
	/// </summary>
	public  class weixinlicenseController:Controller
	{
		D_weixinlicense dweixinlicense = new D_weixinlicense();
		/// <summary>
		/// 微信 列表
		/// </summary>
		public ActionResult weixinlicenseList(tb_weixinlicense model)
		{
			int count = 0;
			ViewBag.weixinlicenseList = dweixinlicense.GetList(model, ref count);
			ViewBag.page = Utils.ShowPage(count, model.PageSize, model.PageIndex, 5);
			return View();
		}

		/// <summary>
		/// 微信 保存
		/// </summary>
		public JsonResult weixinlicenseSave(tb_weixinlicense model)
		{
			if (model == null)
			{
				return ResultTool.jsonResult(false, "参数错误！");
			}
			if(!String.IsNullOrEmpty(model.id))
			{
				bool boolResult = dweixinlicense.Update(model);
				return ResultTool.jsonResult(boolResult, boolResult ? "成功！" : "更新失败！");
			}
			else
			{
				model.id = Guid.NewGuid().ToString("N");
				bool boolResult = dweixinlicense.Add(model);
				return ResultTool.jsonResult(boolResult, boolResult ? "成功！" : "添加失败！");
			}
		}

		/// <summary>
		/// 微信 删除
		/// </summary>
		public JsonResult weixinlicenseDelete(tb_weixinlicense model)
		{
			bool boolResult = dweixinlicense.Delete(model);
			return ResultTool.jsonResult(boolResult, boolResult ? "成功！" : "删除失败！");
		}

		/// <summary>
		/// 微信 详情
		/// </summary>
		public ActionResult weixinlicenseInfo(tb_weixinlicense model)
		{
			model = dweixinlicense.GetInfo(model);
			return View(model??new tb_weixinlicense());
		}

	}
}

