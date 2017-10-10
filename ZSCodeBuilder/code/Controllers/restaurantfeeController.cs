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
		public bool restaurantfeeSave(tb_restaurantfee model)
		{
			if (model == null)
			{
				return false;
			}
			if(!String.IsNullOrEmpty(model.id))
			{
				 return drestaurantfee.Update(model);
			}
			model.id = Guid.NewGuid().ToString("N");
			return drestaurantfee.Add(model);
		}

		/// <summary>
		/// 收费标准 删除
		/// </summary>
		public bool restaurantfeeDelete(tb_restaurantfee model)
		{
			return drestaurantfee.Delete(model);
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

