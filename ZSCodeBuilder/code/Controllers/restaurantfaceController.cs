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
	/// 餐厅展示图
	/// </summary>
	public  class restaurantfaceController:Controller
	{
		D_restaurantface drestaurantface = new D_restaurantface();
		/// <summary>
		/// 餐厅展示图 列表
		/// </summary>
		public ActionResult restaurantfaceList(tb_restaurantface model)
		{
			int count = 0;
			ViewBag.restaurantfaceList = drestaurantface.GetList(model, ref count);
			ViewBag.page = Utils.ShowPage(count, model.PageSize, model.PageIndex, 5);
			return View();
		}

		/// <summary>
		/// 餐厅展示图 保存
		/// </summary>
		public JsonResult restaurantfaceSave(tb_restaurantface model)
		{
			if (model == null)
			{
				return ResultTool.jsonResult(false, "参数错误！");
			}
			if(!String.IsNullOrEmpty(model.id))
			{
				bool boolResult = drestaurantface.Update(model);
				return ResultTool.jsonResult(boolResult, boolResult ? "成功！" : "更新失败！");
			}
			else
			{
				model.id = Guid.NewGuid().ToString("N");
				bool boolResult = drestaurantface.Add(model);
				return ResultTool.jsonResult(boolResult, boolResult ? "成功！" : "添加失败！");
			}
		}

		/// <summary>
		/// 餐厅展示图 删除
		/// </summary>
		public JsonResult restaurantfaceDelete(tb_restaurantface model)
		{
			bool boolResult = drestaurantface.Delete(model);
			return ResultTool.jsonResult(boolResult, boolResult ? "成功！" : "删除失败！");
		}

		/// <summary>
		/// 餐厅展示图 详情
		/// </summary>
		public ActionResult restaurantfaceInfo(tb_restaurantface model)
		{
			model = drestaurantface.GetInfo(model);
			return View(model??new tb_restaurantface());
		}

	}
}

