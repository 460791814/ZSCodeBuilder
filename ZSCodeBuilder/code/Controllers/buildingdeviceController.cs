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
		public JsonResult buildingdeviceSave(tb_buildingdevice model)
		{
			if (model == null)
			{
				return ResultTool.jsonResult(false, "参数错误！");
			}
			if(!String.IsNullOrEmpty(model.id))
			{
				bool boolResult = dbuildingdevice.Update(model);
				return ResultTool.jsonResult(boolResult, boolResult ? "成功！" : "更新失败！");
			}
			else
			{
				model.id = Guid.NewGuid().ToString("N");
				bool boolResult = dbuildingdevice.Add(model);
				return ResultTool.jsonResult(boolResult, boolResult ? "成功！" : "添加失败！");
			}
		}

		/// <summary>
		/// 楼宇配套设备 删除
		/// </summary>
		public JsonResult buildingdeviceDelete(tb_buildingdevice model)
		{
			bool boolResult = dbuildingdevice.Delete(model);
			return ResultTool.jsonResult(boolResult, boolResult ? "成功！" : "删除失败！");
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

