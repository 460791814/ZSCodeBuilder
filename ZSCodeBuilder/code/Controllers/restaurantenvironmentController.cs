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
	/// 餐厅环境介绍
	/// </summary>
	public  class restaurantenvironmentController:Controller
	{
		D_restaurantenvironment drestaurantenvironment = new D_restaurantenvironment();
		/// <summary>
		/// 餐厅环境介绍 列表
		/// </summary>
		public ActionResult restaurantenvironmentList(tb_restaurantenvironment model)
		{
			int count = 0;
			ViewBag.restaurantenvironmentList = drestaurantenvironment.GetList(model, ref count);
			ViewBag.page = Utils.ShowPage(count, model.PageSize, model.PageIndex, 5);
			return View();
		}

		/// <summary>
		/// 餐厅环境介绍 保存
		/// </summary>
		public bool restaurantenvironmentSave(tb_restaurantenvironment model)
		{
			if (model == null)
			{
				return false;
			}
			if(!String.IsNullOrEmpty(model.id))
			{
				 return drestaurantenvironment.Update(model);
			}
			model.id = Guid.NewGuid().ToString("N");
			return drestaurantenvironment.Add(model);
		}

		/// <summary>
		/// 餐厅环境介绍 删除
		/// </summary>
		public bool restaurantenvironmentDelete(tb_restaurantenvironment model)
		{
			return drestaurantenvironment.Delete(model);
		}

		/// <summary>
		/// 餐厅环境介绍 详情
		/// </summary>
		public ActionResult restaurantenvironmentInfo(tb_restaurantenvironment model)
		{
			model = drestaurantenvironment.GetInfo(model);
			return View(model??new tb_restaurantenvironment());
		}

	}
}

