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
	/// 会议室评价
	/// </summary>
	public  class meetingroomcommentController:Controller
	{
		D_meetingroomcomment dmeetingroomcomment = new D_meetingroomcomment();
		/// <summary>
		/// 会议室评价 列表
		/// </summary>
		public ActionResult meetingroomcommentList(tb_meetingroomcomment model)
		{
			int count = 0;
			ViewBag.meetingroomcommentList = dmeetingroomcomment.GetList(model, ref count);
			ViewBag.page = Utils.ShowPage(count, model.PageSize, model.PageIndex, 5);
			return View();
		}

		/// <summary>
		/// 会议室评价 保存
		/// </summary>
		public bool meetingroomcommentSave(tb_meetingroomcomment model)
		{
			if (model == null)
			{
				return false;
			}
			if(!String.IsNullOrEmpty(model.id))
			{
				 return dmeetingroomcomment.Update(model);
			}
			model.id = Guid.NewGuid().ToString("N");
			return dmeetingroomcomment.Add(model);
		}

		/// <summary>
		/// 会议室评价 删除
		/// </summary>
		public bool meetingroomcommentDelete(tb_meetingroomcomment model)
		{
			return dmeetingroomcomment.Delete(model);
		}

		/// <summary>
		/// 会议室评价 详情
		/// </summary>
		public ActionResult meetingroomcommentInfo(tb_meetingroomcomment model)
		{
			model = dmeetingroomcomment.GetInfo(model);
			return View(model??new tb_meetingroomcomment());
		}

	}
}

