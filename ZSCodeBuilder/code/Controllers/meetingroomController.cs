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
		public bool meetingroomSave(tb_meetingroom model)
		{
			if (model == null)
			{
				return false;
			}
			if(!String.IsNullOrEmpty(model.id))
			{
				 return dmeetingroom.Update(model);
			}
			model.id = Guid.NewGuid().ToString("N");
			return dmeetingroom.Add(model);
		}

		/// <summary>
		/// 会议室管理 删除
		/// </summary>
		public bool meetingroomDelete(tb_meetingroom model)
		{
			return dmeetingroom.Delete(model);
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

