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
	/// 楼宇配套服务
	/// </summary>
	public  class buildingserviceController:Controller
	{
		D_buildingservice dbuildingservice = new D_buildingservice();
		/// <summary>
		/// 楼宇配套服务 列表
		/// </summary>
		public ActionResult buildingserviceList(tb_buildingservice model)
		{
			int count = 0;
			ViewBag.buildingserviceList = dbuildingservice.GetList(model, ref count);
			ViewBag.page = Utils.ShowPage(count, model.PageSize, model.PageIndex, 5);
			return View();
		}

		/// <summary>
		/// 楼宇配套服务 保存
		/// </summary>
		public JsonResult buildingserviceSave(tb_buildingservice model)
		{
			if (model == null)
			{
				return ResultTool.jsonResult(false, "参数错误！");
			}
			if(!String.IsNullOrEmpty(model.id))
			{
				bool boolResult = dbuildingservice.Update(model);
				return ResultTool.jsonResult(boolResult, boolResult ? "成功！" : "更新失败！");
			}
			else
			{
				model.id = Guid.NewGuid().ToString("N");
				bool boolResult = dbuildingservice.Add(model);
				return ResultTool.jsonResult(boolResult, boolResult ? "成功！" : "添加失败！");
			}
		}

		/// <summary>
		/// 楼宇配套服务 删除
		/// </summary>
		public JsonResult buildingserviceDelete(tb_buildingservice model)
		{
			bool boolResult = dbuildingservice.Delete(model);
			return ResultTool.jsonResult(boolResult, boolResult ? "成功！" : "删除失败！");
		}

		/// <summary>
		/// 楼宇配套服务 详情
		/// </summary>
		public ActionResult buildingserviceInfo(tb_buildingservice model)
		{
			model = dbuildingservice.GetInfo(model);
			return View(model??new tb_buildingservice());
		}

	}
}

