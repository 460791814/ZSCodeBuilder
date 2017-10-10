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
	/// 微博
	/// </summary>
	public  class weibolicenseController:Controller
	{
		D_weibolicense dweibolicense = new D_weibolicense();
		/// <summary>
		/// 微博 列表
		/// </summary>
		public ActionResult weibolicenseList(tb_weibolicense model)
		{
			int count = 0;
			ViewBag.weibolicenseList = dweibolicense.GetList(model, ref count);
			ViewBag.page = Utils.ShowPage(count, model.PageSize, model.PageIndex, 5);
			return View();
		}

		/// <summary>
		/// 微博 保存
		/// </summary>
		public bool weibolicenseSave(tb_weibolicense model)
		{
			if (model == null)
			{
				return false;
			}
			return dweibolicense.Add(model);
		}

		/// <summary>
		/// 微博 删除
		/// </summary>
		public bool weibolicenseDelete(tb_weibolicense model)
		{
			return dweibolicense.Delete(model);
		}

		/// <summary>
		/// 微博 详情
		/// </summary>
		public ActionResult weibolicenseInfo(tb_weibolicense model)
		{
			model = dweibolicense.GetInfo(model);
			return View(model??new tb_weibolicense());
		}

	}
}

