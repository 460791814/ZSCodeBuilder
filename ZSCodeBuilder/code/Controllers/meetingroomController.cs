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
	/// 会议室管理
	/// </summary>
	public  class meetingroomController:Controller
	{
		D_meetingroom dmeetingroom = new D_meetingroom();
		/// <summary>
		/// 会议室管理 列表
		/// </summary>
		public ActionResult meetingroomList(tb_meetingroom model)
		{
			int count = 0;
			ViewBag.meetingroomList = dmeetingroom.GetList(model, ref count);
			ViewBag.page = Utils.ShowPage(count, model.PageSize, model.PageIndex, 5);
			return View();
		}

		/// <summary>
		/// 会议室管理 保存
		/// </summary>
		public JsonResult meetingroomSave(tb_meetingroom model)
		{
			if (model == null)
			{
				return ResultTool.jsonResult(false, "参数错误！");
			}
			if(!String.IsNullOrEmpty(model.id))
			{
				bool boolResult = dmeetingroom.Update(model);
				return ResultTool.jsonResult(boolResult, boolResult ? "成功！" : "更新失败！");
			}
			else
			{
				model.id = Guid.NewGuid().ToString("N");
				bool boolResult = dmeetingroom.Add(model);
				return ResultTool.jsonResult(boolResult, boolResult ? "成功！" : "添加失败！");
			}
		}

		/// <summary>
		/// 会议室管理 删除
		/// </summary>
		public JsonResult meetingroomDelete(tb_meetingroom model)
		{
			bool boolResult = dmeetingroom.Delete(model);
			return ResultTool.jsonResult(boolResult, boolResult ? "成功！" : "删除失败！");
		}

		/// <summary>
		/// 会议室管理 详情
		/// </summary>
		public ActionResult meetingroomInfo(tb_meetingroom model)
		{
			model = dmeetingroom.GetInfo(model);
			return View(model??new tb_meetingroom());
		}

	}
}

