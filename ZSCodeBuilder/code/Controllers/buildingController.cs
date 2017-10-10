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
	/// 楼宇
	/// </summary>
	public  class buildingController:Controller
	{
		D_building dbuilding = new D_building();
		/// <summary>
		/// 楼宇 列表
		/// </summary>
		public ActionResult buildingList(tb_building model)
		{
			int count = 0;
			ViewBag.buildingList = dbuilding.GetList(model, ref count);
			ViewBag.page = Utils.ShowPage(count, model.PageSize, model.PageIndex, 5);
			return View();
		}

		/// <summary>
		/// 楼宇 保存
		/// </summary>
		public bool buildingSave(tb_building model)
		{
			if (model == null)
			{
				return false;
			}
			if(!String.IsNullOrEmpty(model.id))
			{
				 return dbuilding.Update(model);
			}
			model.id = Guid.NewGuid().ToString("N");
			return dbuilding.Add(model);
		}

		/// <summary>
		/// 楼宇 删除
		/// </summary>
		public bool buildingDelete(tb_building model)
		{
			return dbuilding.Delete(model);
		}

		/// <summary>
		/// 楼宇 详情
		/// </summary>
		public ActionResult buildingInfo(tb_building model)
		{
			model = dbuilding.GetInfo(model);
			return View(model??new tb_building());
		}

	}
}

