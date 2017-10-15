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
	/// 收费标准
	/// </summary>
	public  class restaurantfeeController:Controller
	{
		D_restaurantfee drestaurantfee = new D_restaurantfee();
		/// <summary>
		/// 收费标准 列表
		/// </summary>
		public ActionResult restaurantfeeList(tb_restaurantfee model)
		{
			int count = 0;
			ViewBag.restaurantfeeList = drestaurantfee.GetList(model, ref count);
			ViewBag.page = Utils.ShowPage(count, model.PageSize, model.PageIndex, 5);
			return View();
		}

		/// <summary>
		/// 收费标准 保存
		/// </summary>
		public JsonResult restaurantfeeSave(tb_restaurantfee model)
		{
			if (model == null)
			{
				return ResultTool.jsonResult(false, "参数错误！");
			}
			if(!String.IsNullOrEmpty(model.id))
			{
				bool boolResult = drestaurantfee.Update(model);
				return ResultTool.jsonResult(boolResult, boolResult ? "成功！" : "更新失败！");
			}
			else
			{
				model.id = Guid.NewGuid().ToString("N");
				bool boolResult = drestaurantfee.Add(model);
				return ResultTool.jsonResult(boolResult, boolResult ? "成功！" : "添加失败！");
			}
		}

		/// <summary>
		/// 收费标准 删除
		/// </summary>
		public JsonResult restaurantfeeDelete(tb_restaurantfee model)
		{
			bool boolResult = drestaurantfee.Delete(model);
			return ResultTool.jsonResult(boolResult, boolResult ? "成功！" : "删除失败！");
		}

		/// <summary>
		/// 收费标准 详情
		/// </summary>
		public ActionResult restaurantfeeInfo(tb_restaurantfee model)
		{
			model = drestaurantfee.GetInfo(model);
			return View(model??new tb_restaurantfee());
		}

	}
}

