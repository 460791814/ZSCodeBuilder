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
	/// 首页 推荐内容
	/// </summary>
	public  class featureController:Controller
	{
		D_feature dfeature = new D_feature();
		/// <summary>
		/// 首页 推荐内容 列表
		/// </summary>
		public ActionResult featureList(tb_feature model)
		{
			int count = 0;
			ViewBag.featureList = dfeature.GetList(model, ref count);
			ViewBag.page = Utils.ShowPage(count, model.PageSize, model.PageIndex, 5);
			return View();
		}

		/// <summary>
		/// 首页 推荐内容 保存
		/// </summary>
		public bool featureSave(tb_feature model)
		{
			if (model == null)
			{
				return false;
			}
			if(!String.IsNullOrEmpty(model.id))
			{
				 return dfeature.Update(model);
			}
			model.id = Guid.NewGuid().ToString("N");
			return dfeature.Add(model);
		}

		/// <summary>
		/// 首页 推荐内容 删除
		/// </summary>
		public bool featureDelete(tb_feature model)
		{
			return dfeature.Delete(model);
		}

		/// <summary>
		/// 首页 推荐内容 详情
		/// </summary>
		public ActionResult featureInfo(tb_feature model)
		{
			model = dfeature.GetInfo(model);
			return View(model??new tb_feature());
		}

	}
}

