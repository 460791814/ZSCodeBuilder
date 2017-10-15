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
	/// 服务类别
	/// </summary>
	public  class copyroomserviceController:Controller
	{
		D_copyroomservice dcopyroomservice = new D_copyroomservice();
		/// <summary>
		/// 服务类别 列表
		/// </summary>
		public ActionResult copyroomserviceList(tb_copyroomservice model)
		{
			int count = 0;
			ViewBag.copyroomserviceList = dcopyroomservice.GetList(model, ref count);
			ViewBag.page = Utils.ShowPage(count, model.PageSize, model.PageIndex, 5);
			return View();
		}

		/// <summary>
		/// 服务类别 保存
		/// </summary>
		public JsonResult copyroomserviceSave(tb_copyroomservice model)
		{
			if (model == null)
			{
				return ResultTool.jsonResult(false, "参数错误！");
			}
			if(!String.IsNullOrEmpty(model.id))
			{
				bool boolResult = dcopyroomservice.Update(model);
				return ResultTool.jsonResult(boolResult, boolResult ? "成功！" : "更新失败！");
			}
			else
			{
				model.id = Guid.NewGuid().ToString("N");
				bool boolResult = dcopyroomservice.Add(model);
				return ResultTool.jsonResult(boolResult, boolResult ? "成功！" : "添加失败！");
			}
		}

		/// <summary>
		/// 服务类别 删除
		/// </summary>
		public JsonResult copyroomserviceDelete(tb_copyroomservice model)
		{
			bool boolResult = dcopyroomservice.Delete(model);
			return ResultTool.jsonResult(boolResult, boolResult ? "成功！" : "删除失败！");
		}

		/// <summary>
		/// 服务类别 详情
		/// </summary>
		public ActionResult copyroomserviceInfo(tb_copyroomservice model)
		{
			model = dcopyroomservice.GetInfo(model);
			return View(model??new tb_copyroomservice());
		}

	}
}

