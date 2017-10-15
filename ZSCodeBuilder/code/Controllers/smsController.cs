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
	/// 手机短信验证码
	/// </summary>
	public  class smsController:Controller
	{
		D_sms dsms = new D_sms();
		/// <summary>
		/// 手机短信验证码 列表
		/// </summary>
		public ActionResult smsList(tb_sms model)
		{
			int count = 0;
			ViewBag.smsList = dsms.GetList(model, ref count);
			ViewBag.page = Utils.ShowPage(count, model.PageSize, model.PageIndex, 5);
			return View();
		}

		/// <summary>
		/// 手机短信验证码 保存
		/// </summary>
		public JsonResult smsSave(tb_sms model)
		{
			if (model == null)
			{
				return ResultTool.jsonResult(false, "参数错误！");
			}
			if(!String.IsNullOrEmpty(model.id))
			{
				bool boolResult = dsms.Update(model);
				return ResultTool.jsonResult(boolResult, boolResult ? "成功！" : "更新失败！");
			}
			else
			{
				model.id = Guid.NewGuid().ToString("N");
				bool boolResult = dsms.Add(model);
				return ResultTool.jsonResult(boolResult, boolResult ? "成功！" : "添加失败！");
			}
		}

		/// <summary>
		/// 手机短信验证码 删除
		/// </summary>
		public JsonResult smsDelete(tb_sms model)
		{
			bool boolResult = dsms.Delete(model);
			return ResultTool.jsonResult(boolResult, boolResult ? "成功！" : "删除失败！");
		}

		/// <summary>
		/// 手机短信验证码 详情
		/// </summary>
		public ActionResult smsInfo(tb_sms model)
		{
			model = dsms.GetInfo(model);
			return View(model??new tb_sms());
		}

	}
}

