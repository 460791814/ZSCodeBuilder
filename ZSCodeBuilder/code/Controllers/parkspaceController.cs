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
	/// 各类车型车位数量
	/// </summary>
	public  class parkspaceController:Controller
	{
		D_parkspace dparkspace = new D_parkspace();
		/// <summary>
		/// 各类车型车位数量 列表
		/// </summary>
		public ActionResult parkspaceList(tb_parkspace model)
		{
			int count = 0;
			ViewBag.parkspaceList = dparkspace.GetList(model, ref count);
			ViewBag.page = Utils.ShowPage(count, model.PageSize, model.PageIndex, 5);
			return View();
		}

		/// <summary>
		/// 各类车型车位数量 保存
		/// </summary>
		public JsonResult parkspaceSave(tb_parkspace model)
		{
			if (model == null)
			{
				return ResultTool.jsonResult(false, "参数错误！");
			}
			if(!String.IsNullOrEmpty(model.id))
			{
				bool boolResult = dparkspace.Update(model);
				return ResultTool.jsonResult(boolResult, boolResult ? "成功！" : "更新失败！");
			}
			else
			{
				model.id = Guid.NewGuid().ToString("N");
				bool boolResult = dparkspace.Add(model);
				return ResultTool.jsonResult(boolResult, boolResult ? "成功！" : "添加失败！");
			}
		}

		/// <summary>
		/// 各类车型车位数量 删除
		/// </summary>
		public JsonResult parkspaceDelete(tb_parkspace model)
		{
			bool boolResult = dparkspace.Delete(model);
			return ResultTool.jsonResult(boolResult, boolResult ? "成功！" : "删除失败！");
		}

		/// <summary>
		/// 各类车型车位数量 详情
		/// </summary>
		public ActionResult parkspaceInfo(tb_parkspace model)
		{
			model = dparkspace.GetInfo(model);
			return View(model??new tb_parkspace());
		}

	}
}

