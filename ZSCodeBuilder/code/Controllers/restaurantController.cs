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
	/// 餐饮美食
	/// </summary>
	public  class restaurantController:Controller
	{
		D_restaurant drestaurant = new D_restaurant();
		/// <summary>
		/// 餐饮美食 列表
		/// </summary>
		public ActionResult restaurantList(tb_restaurant model)
		{
			int count = 0;
			ViewBag.restaurantList = drestaurant.GetList(model, ref count);
			ViewBag.page = Utils.ShowPage(count, model.PageSize, model.PageIndex, 5);
			return View();
		}

		/// <summary>
		/// 餐饮美食 保存
		/// </summary>
		public JsonResult restaurantSave(tb_restaurant model)
		{
			if (model == null)
			{
				return ResultTool.jsonResult(false, "参数错误！");
			}
			if(!String.IsNullOrEmpty(model.id))
			{
				bool boolResult = drestaurant.Update(model);
				return ResultTool.jsonResult(boolResult, boolResult ? "成功！" : "更新失败！");
			}
			else
			{
				model.id = Guid.NewGuid().ToString("N");
				bool boolResult = drestaurant.Add(model);
				return ResultTool.jsonResult(boolResult, boolResult ? "成功！" : "添加失败！");
			}
		}

		/// <summary>
		/// 餐饮美食 删除
		/// </summary>
		public JsonResult restaurantDelete(tb_restaurant model)
		{
			bool boolResult = drestaurant.Delete(model);
			return ResultTool.jsonResult(boolResult, boolResult ? "成功！" : "删除失败！");
		}

		/// <summary>
		/// 餐饮美食 详情
		/// </summary>
		public ActionResult restaurantInfo(tb_restaurant model)
		{
			model = drestaurant.GetInfo(model);
			return View(model??new tb_restaurant());
		}

	}
}

