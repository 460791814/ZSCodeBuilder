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
	/// 会议室配套设备设施
	/// </summary>
	public  class meetingroomdeviceController:Controller
	{
		D_meetingroomdevice dmeetingroomdevice = new D_meetingroomdevice();
		/// <summary>
		/// 会议室配套设备设施 列表
		/// </summary>
		public ActionResult meetingroomdeviceList(tb_meetingroomdevice model)
		{
			int count = 0;
			ViewBag.meetingroomdeviceList = dmeetingroomdevice.GetList(model, ref count);
			ViewBag.page = Utils.ShowPage(count, model.PageSize, model.PageIndex, 5);
			return View();
		}

		/// <summary>
		/// 会议室配套设备设施 保存
		/// </summary>
		public bool meetingroomdeviceSave(tb_meetingroomdevice model)
		{
			if (model == null)
			{
				return false;
			}
			if(!String.IsNullOrEmpty(model.id))
			{
				 return dmeetingroomdevice.Update(model);
			}
			model.id = Guid.NewGuid().ToString("N");
			return dmeetingroomdevice.Add(model);
		}

		/// <summary>
		/// 会议室配套设备设施 删除
		/// </summary>
		public bool meetingroomdeviceDelete(tb_meetingroomdevice model)
		{
			return dmeetingroomdevice.Delete(model);
		}

		/// <summary>
		/// 会议室配套设备设施 详情
		/// </summary>
		public ActionResult meetingroomdeviceInfo(tb_meetingroomdevice model)
		{
			model = dmeetingroomdevice.GetInfo(model);
			return View(model??new tb_meetingroomdevice());
		}

	}
}

