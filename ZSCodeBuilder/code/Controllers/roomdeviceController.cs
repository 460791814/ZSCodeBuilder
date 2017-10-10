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
	/// 其他配套设备设施
	/// </summary>
	public  class roomdeviceController:Controller
	{
		D_roomdevice droomdevice = new D_roomdevice();
		/// <summary>
		/// 其他配套设备设施 列表
		/// </summary>
		public ActionResult roomdeviceList(tb_roomdevice model)
		{
			int count = 0;
			ViewBag.roomdeviceList = droomdevice.GetList(model, ref count);
			ViewBag.page = Utils.ShowPage(count, model.PageSize, model.PageIndex, 5);
			return View();
		}

		/// <summary>
		/// 其他配套设备设施 保存
		/// </summary>
		public bool roomdeviceSave(tb_roomdevice model)
		{
			if (model == null)
			{
				return false;
			}
			if(!String.IsNullOrEmpty(model.id))
			{
				 return droomdevice.Update(model);
			}
			model.id = Guid.NewGuid().ToString("N");
			return droomdevice.Add(model);
		}

		/// <summary>
		/// 其他配套设备设施 删除
		/// </summary>
		public bool roomdeviceDelete(tb_roomdevice model)
		{
			return droomdevice.Delete(model);
		}

		/// <summary>
		/// 其他配套设备设施 详情
		/// </summary>
		public ActionResult roomdeviceInfo(tb_roomdevice model)
		{
			model = droomdevice.GetInfo(model);
			return View(model??new tb_roomdevice());
		}

	}
}

