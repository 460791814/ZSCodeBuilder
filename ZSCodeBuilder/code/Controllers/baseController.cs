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
	/// 基础数据
	/// </summary>
	public  class baseController:Controller
	{
		D_base dbase = new D_base();
		/// <summary>
		/// 基础数据 列表
		/// </summary>
		public ActionResult baseList(tb_base model)
		{
			int count = 0;
			ViewBag.baseList = dbase.GetList(model, ref count);
			ViewBag.page = Utils.ShowPage(count, model.PageSize, model.PageIndex, 5);
			return View();
		}

		/// <summary>
		/// 基础数据 保存
		/// </summary>
		public bool baseSave(tb_base model)
		{
			if (model == null)
			{
				return false;
			}
			if(!String.IsNullOrEmpty(model.id))
			{
				 return dbase.Update(model);
			}
			model.id = Guid.NewGuid().ToString("N");
			return dbase.Add(model);
		}

		/// <summary>
		/// 基础数据 删除
		/// </summary>
		public bool baseDelete(tb_base model)
		{
			return dbase.Delete(model);
		}

		/// <summary>
		/// 基础数据 详情
		/// </summary>
		public ActionResult baseInfo(tb_base model)
		{
			model = dbase.GetInfo(model);
			return View(model??new tb_base());
		}

	}
}

