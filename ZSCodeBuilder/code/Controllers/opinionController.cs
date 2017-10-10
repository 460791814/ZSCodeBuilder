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
	/// 意见反馈
	/// </summary>
	public  class opinionController:Controller
	{
		D_opinion dopinion = new D_opinion();
		/// <summary>
		/// 意见反馈 列表
		/// </summary>
		public ActionResult opinionList(tb_opinion model)
		{
			int count = 0;
			ViewBag.opinionList = dopinion.GetList(model, ref count);
			ViewBag.page = Utils.ShowPage(count, model.PageSize, model.PageIndex, 5);
			return View();
		}

		/// <summary>
		/// 意见反馈 保存
		/// </summary>
		public bool opinionSave(tb_opinion model)
		{
			if (model == null)
			{
				return false;
			}
			if(!String.IsNullOrEmpty(model.id))
			{
				 return dopinion.Update(model);
			}
			model.id = Guid.NewGuid().ToString("N");
			return dopinion.Add(model);
		}

		/// <summary>
		/// 意见反馈 删除
		/// </summary>
		public bool opinionDelete(tb_opinion model)
		{
			return dopinion.Delete(model);
		}

		/// <summary>
		/// 意见反馈 详情
		/// </summary>
		public ActionResult opinionInfo(tb_opinion model)
		{
			model = dopinion.GetInfo(model);
			return View(model??new tb_opinion());
		}

	}
}

