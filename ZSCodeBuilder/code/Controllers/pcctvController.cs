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
	/// 省市区县
	/// </summary>
	public  class pcctvController:Controller
	{
		D_pcctv dpcctv = new D_pcctv();
		/// <summary>
		/// 省市区县 列表
		/// </summary>
		public ActionResult pcctvList(tb_pcctv model)
		{
			int count = 0;
			ViewBag.pcctvList = dpcctv.GetList(model, ref count);
			ViewBag.page = Utils.ShowPage(count, model.PageSize, model.PageIndex, 5);
			return View();
		}

		/// <summary>
		/// 省市区县 保存
		/// </summary>
		public bool pcctvSave(tb_pcctv model)
		{
			if (model == null)
			{
				return false;
			}
			if(!String.IsNullOrEmpty(model.id))
			{
				 return dpcctv.Update(model);
			}
			model.id = Guid.NewGuid().ToString("N");
			return dpcctv.Add(model);
		}

		/// <summary>
		/// 省市区县 删除
		/// </summary>
		public bool pcctvDelete(tb_pcctv model)
		{
			return dpcctv.Delete(model);
		}

		/// <summary>
		/// 省市区县 详情
		/// </summary>
		public ActionResult pcctvInfo(tb_pcctv model)
		{
			model = dpcctv.GetInfo(model);
			return View(model??new tb_pcctv());
		}

	}
}

