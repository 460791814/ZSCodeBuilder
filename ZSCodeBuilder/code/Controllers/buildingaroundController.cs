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
	/// 周边配套介绍
	/// </summary>
	public  class buildingaroundController:Controller
	{
		D_buildingaround dbuildingaround = new D_buildingaround();
		/// <summary>
		/// 周边配套介绍 列表
		/// </summary>
		public ActionResult buildingaroundList(tb_buildingaround model)
		{
			int count = 0;
			ViewBag.buildingaroundList = dbuildingaround.GetList(model, ref count);
			ViewBag.page = Utils.ShowPage(count, model.PageSize, model.PageIndex, 5);
			return View();
		}

		/// <summary>
		/// 周边配套介绍 保存
		/// </summary>
		public bool buildingaroundSave(tb_buildingaround model)
		{
			if (model == null)
			{
				return false;
			}
			if(!String.IsNullOrEmpty(model.id))
			{
				 return dbuildingaround.Update(model);
			}
			model.id = Guid.NewGuid().ToString("N");
			return dbuildingaround.Add(model);
		}

		/// <summary>
		/// 周边配套介绍 删除
		/// </summary>
		public bool buildingaroundDelete(tb_buildingaround model)
		{
			return dbuildingaround.Delete(model);
		}

		/// <summary>
		/// 周边配套介绍 详情
		/// </summary>
		public ActionResult buildingaroundInfo(tb_buildingaround model)
		{
			model = dbuildingaround.GetInfo(model);
			return View(model??new tb_buildingaround());
		}

	}
}

