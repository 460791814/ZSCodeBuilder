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
	public  class statusController:Controller
	{
		D_status dstatus = new D_status();
		/// <summary>
		/// 基础数据 列表
		/// </summary>
		public ActionResult statusList(tb_status model)
		{
			int count = 0;
			ViewBag.statusList = dstatus.GetList(model, ref count);
			ViewBag.page = Utils.ShowPage(count, model.PageSize, model.PageIndex, 5);
			return View();
		}

		/// <summary>
		/// 基础数据 保存
		/// </summary>
		public bool statusSave(tb_status model)
		{
			if (model == null)
			{
				return false;
			}
			if(!String.IsNullOrEmpty(model.id))
			{
				 return dstatus.Update(model);
			}
			model.id = Guid.NewGuid().ToString("N");
			return dstatus.Add(model);
		}

		/// <summary>
		/// 基础数据 删除
		/// </summary>
		public bool statusDelete(tb_status model)
		{
			return dstatus.Delete(model);
		}

		/// <summary>
		/// 基础数据 详情
		/// </summary>
		public ActionResult statusInfo(tb_status model)
		{
			model = dstatus.GetInfo(model);
			return View(model??new tb_status());
		}

	}
}

