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
	/// 系统用户
	/// </summary>
	public  class sysuserController:Controller
	{
		D_sysuser dsysuser = new D_sysuser();
		/// <summary>
		/// 系统用户 列表
		/// </summary>
		public ActionResult sysuserList(tb_sysuser model)
		{
			int count = 0;
			ViewBag.sysuserList = dsysuser.GetList(model, ref count);
			ViewBag.page = Utils.ShowPage(count, model.PageSize, model.PageIndex, 5);
			return View();
		}

		/// <summary>
		/// 系统用户 保存
		/// </summary>
		public JsonResult sysuserSave(tb_sysuser model)
		{
			if (model == null)
			{
				return ResultTool.jsonResult(false, "参数错误！");
			}
			if(!String.IsNullOrEmpty(model.id))
			{
				bool boolResult = dsysuser.Update(model);
				return ResultTool.jsonResult(boolResult, boolResult ? "成功！" : "更新失败！");
			}
			else
			{
				model.id = Guid.NewGuid().ToString("N");
				bool boolResult = dsysuser.Add(model);
				return ResultTool.jsonResult(boolResult, boolResult ? "成功！" : "添加失败！");
			}
		}

		/// <summary>
		/// 系统用户 删除
		/// </summary>
		public JsonResult sysuserDelete(tb_sysuser model)
		{
			bool boolResult = dsysuser.Delete(model);
			return ResultTool.jsonResult(boolResult, boolResult ? "成功！" : "删除失败！");
		}

		/// <summary>
		/// 系统用户 详情
		/// </summary>
		public ActionResult sysuserInfo(tb_sysuser model)
		{
			model = dsysuser.GetInfo(model);
			return View(model??new tb_sysuser());
		}

	}
}

