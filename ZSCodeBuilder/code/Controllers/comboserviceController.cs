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
	/// 套餐服务内容
	/// </summary>
	public  class comboserviceController:Controller
	{
		D_comboservice dcomboservice = new D_comboservice();
		/// <summary>
		/// 套餐服务内容 列表
		/// </summary>
		public ActionResult comboserviceList(tb_comboservice model)
		{
			int count = 0;
			ViewBag.comboserviceList = dcomboservice.GetList(model, ref count);
			ViewBag.page = Utils.ShowPage(count, model.PageSize, model.PageIndex, 5);
			return View();
		}

		/// <summary>
		/// 套餐服务内容 保存
		/// </summary>
		public bool comboserviceSave(tb_comboservice model)
		{
			if (model == null)
			{
				return false;
			}
			if(!String.IsNullOrEmpty(model.id))
			{
				 return dcomboservice.Update(model);
			}
			model.id = Guid.NewGuid().ToString("N");
			return dcomboservice.Add(model);
		}

		/// <summary>
		/// 套餐服务内容 删除
		/// </summary>
		public bool comboserviceDelete(tb_comboservice model)
		{
			return dcomboservice.Delete(model);
		}

		/// <summary>
		/// 套餐服务内容 详情
		/// </summary>
		public ActionResult comboserviceInfo(tb_comboservice model)
		{
			model = dcomboservice.GetInfo(model);
			return View(model??new tb_comboservice());
		}

	}
}

