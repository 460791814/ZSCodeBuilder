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
	/// 县
	/// </summary>
	public  class countyController:Controller
	{
		D_county dcounty = new D_county();
		/// <summary>
		/// 县 列表
		/// </summary>
		public ActionResult countyList(tb_county model)
		{
			int count = 0;
			ViewBag.countyList = dcounty.GetList(model, ref count);
			ViewBag.page = Utils.ShowPage(count, model.PageSize, model.PageIndex, 5);
			return View();
		}

		/// <summary>
		/// 县 保存
		/// </summary>
		public bool countySave(tb_county model)
		{
			if (model == null)
			{
				return false;
			}
			if(!String.IsNullOrEmpty(model.id))
			{
				 return dcounty.Update(model);
			}
			model.id = Guid.NewGuid().ToString("N");
			return dcounty.Add(model);
		}

		/// <summary>
		/// 县 删除
		/// </summary>
		public bool countyDelete(tb_county model)
		{
			return dcounty.Delete(model);
		}

		/// <summary>
		/// 县 详情
		/// </summary>
		public ActionResult countyInfo(tb_county model)
		{
			model = dcounty.GetInfo(model);
			return View(model??new tb_county());
		}

	}
}

