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
	public  class pcctvController:Controller
	{
		D_pcctv dpcctv = new D_pcctv();
		/// <summary>
		/// 各类车型车位数量 列表
		/// </summary>
		public ActionResult pcctvList(tb_pcctv model)
		{
			int count = 0;
			ViewBag.pcctvList = dpcctv.GetList(model, ref count);
			ViewBag.page = Utils.ShowPage(count, model.PageSize, model.PageIndex, 5);
			return View();
		}

		/// <summary>
		/// 各类车型车位数量 保存
		/// </summary>
		public JsonResult pcctvSave(tb_pcctv model)
		{
			if (model == null)
			{
				return ResultTool.jsonResult(false, "参数错误！");
			}
			if(!String.IsNullOrEmpty(model.id))
			{
				bool boolResult = dpcctv.Update(model);
				return ResultTool.jsonResult(boolResult, boolResult ? "成功！" : "更新失败！");
			}
			else
			{
				model.id = Guid.NewGuid().ToString("N");
				bool boolResult = dpcctv.Add(model);
				return ResultTool.jsonResult(boolResult, boolResult ? "成功！" : "添加失败！");
			}
		}

		/// <summary>
		/// 各类车型车位数量 删除
		/// </summary>
		public JsonResult pcctvDelete(tb_pcctv model)
		{
			bool boolResult = dpcctv.Delete(model);
			return ResultTool.jsonResult(boolResult, boolResult ? "成功！" : "删除失败！");
		}

		/// <summary>
		/// 各类车型车位数量 详情
		/// </summary>
		public ActionResult pcctvInfo(tb_pcctv model)
		{
			model = dpcctv.GetInfo(model);
			return View(model??new tb_pcctv());
		}

	}
}

