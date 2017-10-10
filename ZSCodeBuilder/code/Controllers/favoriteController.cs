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
	/// 我的收藏
	/// </summary>
	public  class favoriteController:Controller
	{
		D_favorite dfavorite = new D_favorite();
		/// <summary>
		/// 我的收藏 列表
		/// </summary>
		public ActionResult favoriteList(tb_favorite model)
		{
			int count = 0;
			ViewBag.favoriteList = dfavorite.GetList(model, ref count);
			ViewBag.page = Utils.ShowPage(count, model.PageSize, model.PageIndex, 5);
			return View();
		}

		/// <summary>
		/// 我的收藏 保存
		/// </summary>
		public bool favoriteSave(tb_favorite model)
		{
			if (model == null)
			{
				return false;
			}
			if(!String.IsNullOrEmpty(model.id))
			{
				 return dfavorite.Update(model);
			}
			model.id = Guid.NewGuid().ToString("N");
			return dfavorite.Add(model);
		}

		/// <summary>
		/// 我的收藏 删除
		/// </summary>
		public bool favoriteDelete(tb_favorite model)
		{
			return dfavorite.Delete(model);
		}

		/// <summary>
		/// 我的收藏 详情
		/// </summary>
		public ActionResult favoriteInfo(tb_favorite model)
		{
			model = dfavorite.GetInfo(model);
			return View(model??new tb_favorite());
		}

	}
}

