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
		public JsonResult meetingroomcommentSave(tb_meetingroomcomment model)
		{
			if (model == null)
			{
				return ResultTool.jsonResult(false, "参数错误！");
			}
			if(!String.IsNullOrEmpty(model.id))
			{
				bool boolResult = dmeetingroomcomment.Update(model);
				return ResultTool.jsonResult(boolResult, boolResult ? "成功！" : "更新失败！");
			}
			else
			{
				model.id = Guid.NewGuid().ToString("N");
				bool boolResult = dmeetingroomcomment.Add(model);
				return ResultTool.jsonResult(boolResult, boolResult ? "成功！" : "添加失败！");
			}
		}

		/// <summary>
		/// 会议室评价 删除
		/// </summary>
		public JsonResult meetingroomcommentDelete(tb_meetingroomcomment model)
		{
			bool boolResult = dmeetingroomcomment.Delete(model);
			return ResultTool.jsonResult(boolResult, boolResult ? "成功！" : "删除失败！");
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

