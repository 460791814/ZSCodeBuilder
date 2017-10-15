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
	/// 会议服务 会议预定管理
	/// </summary>
	public  class meetingorderController:Controller
	{
		D_meetingorder dmeetingorder = new D_meetingorder();
		/// <summary>
		/// 会议服务 会议预定管理 列表
		/// </summary>
		public ActionResult meetingorderList(tb_meetingorder model)
		{
			int count = 0;
			ViewBag.meetingorderList = dmeetingorder.GetList(model, ref count);
			ViewBag.page = Utils.ShowPage(count, model.PageSize, model.PageIndex, 5);
			return View();
		}

		/// <summary>
		/// 会议服务 会议预定管理 保存
		/// </summary>
		public JsonResult meetingorderSave(tb_meetingorder model)
		{
			if (model == null)
			{
				return ResultTool.jsonResult(false, "参数错误！");
			}
			if(!String.IsNullOrEmpty(model.id))
			{
				bool boolResult = dmeetingorder.Update(model);
				return ResultTool.jsonResult(boolResult, boolResult ? "成功！" : "更新失败！");
			}
			else
			{
				model.id = Guid.NewGuid().ToString("N");
				bool boolResult = dmeetingorder.Add(model);
				return ResultTool.jsonResult(boolResult, boolResult ? "成功！" : "添加失败！");
			}
		}

		/// <summary>
		/// 会议服务 会议预定管理 删除
		/// </summary>
		public JsonResult meetingorderDelete(tb_meetingorder model)
		{
			bool boolResult = dmeetingorder.Delete(model);
			return ResultTool.jsonResult(boolResult, boolResult ? "成功！" : "删除失败！");
		}

		/// <summary>
		/// 会议服务 会议预定管理 详情
		/// </summary>
		public ActionResult meetingorderInfo(tb_meetingorder model)
		{
			model = dmeetingorder.GetInfo(model);
			return View(model??new tb_meetingorder());
		}

	}
}

