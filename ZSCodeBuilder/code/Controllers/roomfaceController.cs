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
	/// 楼层展示图
	/// </summary>
	public  class roomfaceController:Controller
	{
		D_roomface droomface = new D_roomface();
		/// <summary>
		/// 楼层展示图 列表
		/// </summary>
		public ActionResult roomfaceList(tb_roomface model)
		{
			int count = 0;
			ViewBag.roomfaceList = droomface.GetList(model, ref count);
			ViewBag.page = Utils.ShowPage(count, model.PageSize, model.PageIndex, 5);
			return View();
		}

		/// <summary>
		/// 楼层展示图 保存
		/// </summary>
		public bool roomfaceSave(tb_roomface model)
		{
			if (model == null)
			{
				return false;
			}
			if(!String.IsNullOrEmpty(model.id))
			{
				 return droomface.Update(model);
			}
			model.id = Guid.NewGuid().ToString("N");
			return droomface.Add(model);
		}

		/// <summary>
		/// 楼层展示图 删除
		/// </summary>
		public bool roomfaceDelete(tb_roomface model)
		{
			return droomface.Delete(model);
		}

		/// <summary>
		/// 楼层展示图 详情
		/// </summary>
		public ActionResult roomfaceInfo(tb_roomface model)
		{
			model = droomface.GetInfo(model);
			return View(model??new tb_roomface());
		}

	}
}

