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
	/// 内容管理
	/// </summary>
	public  class documentController:Controller
	{
		D_document ddocument = new D_document();
		/// <summary>
		/// 内容管理 列表
		/// </summary>
		public ActionResult documentList(tb_document model)
		{
			int count = 0;
			ViewBag.documentList = ddocument.GetList(model, ref count);
			ViewBag.page = Utils.ShowPage(count, model.PageSize, model.PageIndex, 5);
			return View();
		}

		/// <summary>
		/// 内容管理 保存
		/// </summary>
		public bool documentSave(tb_document model)
		{
			if (model == null)
			{
				return false;
			}
			if(!String.IsNullOrEmpty(model.id))
			{
				 return ddocument.Update(model);
			}
			model.id = Guid.NewGuid().ToString("N");
			return ddocument.Add(model);
		}

		/// <summary>
		/// 内容管理 删除
		/// </summary>
		public bool documentDelete(tb_document model)
		{
			return ddocument.Delete(model);
		}

		/// <summary>
		/// 内容管理 详情
		/// </summary>
		public ActionResult documentInfo(tb_document model)
		{
			model = ddocument.GetInfo(model);
			return View(model??new tb_document());
		}

	}
}

