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
	/// 套餐
	/// </summary>
	public  class comboController:Controller
	{
		D_combo dcombo = new D_combo();
		/// <summary>
		/// 套餐 列表
		/// </summary>
		public ActionResult comboList(tb_combo model)
		{
			int count = 0;
			ViewBag.comboList = dcombo.GetList(model, ref count);
			ViewBag.page = Utils.ShowPage(count, model.PageSize, model.PageIndex, 5);
			return View();
		}

		/// <summary>
		/// 套餐 保存
		/// </summary>
		public bool comboSave(tb_combo model)
		{
			if (model == null)
			{
				return false;
			}
			if(!String.IsNullOrEmpty(model.id))
			{
				 return dcombo.Update(model);
			}
			model.id = Guid.NewGuid().ToString("N");
			return dcombo.Add(model);
		}

		/// <summary>
		/// 套餐 删除
		/// </summary>
		public bool comboDelete(tb_combo model)
		{
			return dcombo.Delete(model);
		}

		/// <summary>
		/// 套餐 详情
		/// </summary>
		public ActionResult comboInfo(tb_combo model)
		{
			model = dcombo.GetInfo(model);
			return View(model??new tb_combo());
		}

	}
}

