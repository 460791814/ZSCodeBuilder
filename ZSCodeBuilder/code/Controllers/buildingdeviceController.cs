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
	/// 楼宇配套设备
	/// </summary>
	public  class buildingdeviceController:Controller
	{
		D_buildingdevice dbuildingdevice = new D_buildingdevice();
		/// <summary>
		/// 楼宇配套设备 列表
		/// </summary>
		public ActionResult buildingdeviceList(tb_buildingdevice model)
		{
			int count = 0;
			ViewBag.buildingdeviceList = dbuildingdevice.GetList(model, ref count);
			ViewBag.page = Utils.ShowPage(count, model.PageSize, model.PageIndex, 5);
			return View();
		}

		/// <summary>
		/// 楼宇配套设备 保存
		/// </summary>
		public bool buildingdeviceSave(tb_buildingdevice model)
		{
			if (model == null)
			{
				return false;
			}
			if(!String.IsNullOrEmpty(model.id))
			{
				 return dbuildingdevice.Update(model);
			}
			model.id = Guid.NewGuid().ToString("N");
			return dbuildingdevice.Add(model);
		}

		/// <summary>
		/// 楼宇配套设备 删除
		/// </summary>
		public bool buildingdeviceDelete(tb_buildingdevice model)
		{
			return dbuildingdevice.Delete(model);
		}

		/// <summary>
		/// 楼宇配套设备 详情
		/// </summary>
		public ActionResult buildingdeviceInfo(tb_buildingdevice model)
		{
			model = dbuildingdevice.GetInfo(model);
			return View(model??new tb_buildingdevice());
		}

	}
}

