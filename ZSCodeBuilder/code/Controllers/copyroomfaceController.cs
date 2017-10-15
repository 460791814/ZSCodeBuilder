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
	/// 文印室展示图
	/// </summary>
	public  class copyroomfaceController:Controller
	{
		D_copyroomface dcopyroomface = new D_copyroomface();
		/// <summary>
		/// 文印室展示图 列表
		/// </summary>
		public ActionResult copyroomfaceList(tb_copyroomface model)
		{
			int count = 0;
			ViewBag.copyroomfaceList = dcopyroomface.GetList(model, ref count);
			ViewBag.page = Utils.ShowPage(count, model.PageSize, model.PageIndex, 5);
			return View();
		}

		/// <summary>
		/// 文印室展示图 保存
		/// </summary>
		public JsonResult copyroomfaceSave(tb_copyroomface model)
		{
			if (model == null)
			{
				return ResultTool.jsonResult(false, "参数错误！");
			}
			if(!String.IsNullOrEmpty(model.id))
			{
				bool boolResult = dcopyroomface.Update(model);
				return ResultTool.jsonResult(boolResult, boolResult ? "成功！" : "更新失败！");
			}
			else
			{
				model.id = Guid.NewGuid().ToString("N");
				bool boolResult = dcopyroomface.Add(model);
				return ResultTool.jsonResult(boolResult, boolResult ? "成功！" : "添加失败！");
			}
		}

		/// <summary>
		/// 文印室展示图 删除
		/// </summary>
		public JsonResult copyroomfaceDelete(tb_copyroomface model)
		{
			bool boolResult = dcopyroomface.Delete(model);
			return ResultTool.jsonResult(boolResult, boolResult ? "成功！" : "删除失败！");
		}

		/// <summary>
		/// 文印室展示图 详情
		/// </summary>
		public ActionResult copyroomfaceInfo(tb_copyroomface model)
		{
			model = dcopyroomface.GetInfo(model);
			return View(model??new tb_copyroomface());
		}

	}
}

