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
		public JsonResult countySave(tb_county model)
		{
			if (model == null)
			{
				return ResultTool.jsonResult(false, "参数错误！");
			}
			if(!String.IsNullOrEmpty(model.id))
			{
				bool boolResult = dcounty.Update(model);
				return ResultTool.jsonResult(boolResult, boolResult ? "成功！" : "更新失败！");
			}
			else
			{
				model.id = Guid.NewGuid().ToString("N");
				bool boolResult = dcounty.Add(model);
				return ResultTool.jsonResult(boolResult, boolResult ? "成功！" : "添加失败！");
			}
		}

		/// <summary>
		/// 县 删除
		/// </summary>
		public JsonResult countyDelete(tb_county model)
		{
			bool boolResult = dcounty.Delete(model);
			return ResultTool.jsonResult(boolResult, boolResult ? "成功！" : "删除失败！");
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

