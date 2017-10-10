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
	/// 呼叫记录
	/// </summary>
	public  class calllogController:Controller
	{
		D_calllog dcalllog = new D_calllog();
		/// <summary>
		/// 呼叫记录 列表
		/// </summary>
		public ActionResult calllogList(tb_calllog model)
		{
			int count = 0;
			ViewBag.calllogList = dcalllog.GetList(model, ref count);
			ViewBag.page = Utils.ShowPage(count, model.PageSize, model.PageIndex, 5);
			return View();
		}

		/// <summary>
		/// 呼叫记录 保存
		/// </summary>
		public bool calllogSave(tb_calllog model)
		{
			if (model == null)
			{
				return false;
			}
			if(!String.IsNullOrEmpty(model.id))
			{
				 return dcalllog.Update(model);
			}
			model.id = Guid.NewGuid().ToString("N");
			return dcalllog.Add(model);
		}

		/// <summary>
		/// 呼叫记录 删除
		/// </summary>
		public bool calllogDelete(tb_calllog model)
		{
			return dcalllog.Delete(model);
		}

		/// <summary>
		/// 呼叫记录 详情
		/// </summary>
		public ActionResult calllogInfo(tb_calllog model)
		{
			model = dcalllog.GetInfo(model);
			return View(model??new tb_calllog());
		}

	}
}

