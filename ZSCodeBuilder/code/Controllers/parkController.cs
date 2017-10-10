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
	/// 车位信息
	/// </summary>
	public  class parkController:Controller
	{
		D_park dpark = new D_park();
		/// <summary>
		/// 车位信息 列表
		/// </summary>
		public ActionResult parkList(tb_park model)
		{
			int count = 0;
			ViewBag.parkList = dpark.GetList(model, ref count);
			ViewBag.page = Utils.ShowPage(count, model.PageSize, model.PageIndex, 5);
			return View();
		}

		/// <summary>
		/// 车位信息 保存
		/// </summary>
		public bool parkSave(tb_park model)
		{
			if (model == null)
			{
				return false;
			}
			if(!String.IsNullOrEmpty(model.id))
			{
				 return dpark.Update(model);
			}
			model.id = Guid.NewGuid().ToString("N");
			return dpark.Add(model);
		}

		/// <summary>
		/// 车位信息 删除
		/// </summary>
		public bool parkDelete(tb_park model)
		{
			return dpark.Delete(model);
		}

		/// <summary>
		/// 车位信息 详情
		/// </summary>
		public ActionResult parkInfo(tb_park model)
		{
			model = dpark.GetInfo(model);
			return View(model??new tb_park());
		}

	}
}

