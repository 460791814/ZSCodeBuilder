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
	public  class buildingfaceController:Controller
	{
		D_buildingface dbuildingface = new D_buildingface();
		/// <summary>
		/// 楼层展示图 列表
		/// </summary>
		public ActionResult buildingfaceList(tb_buildingface model)
		{
			int count = 0;
			ViewBag.buildingfaceList = dbuildingface.GetList(model, ref count);
			ViewBag.page = Utils.ShowPage(count, model.PageSize, model.PageIndex, 5);
			return View();
		}

		/// <summary>
		/// 楼层展示图 保存
		/// </summary>
		public JsonResult buildingfaceSave(tb_buildingface model)
		{
			if (model == null)
			{
				return ResultTool.jsonResult(false, "参数错误！");
			}
			if(!String.IsNullOrEmpty(model.id))
			{
				bool boolResult = dbuildingface.Update(model);
				return ResultTool.jsonResult(boolResult, boolResult ? "成功！" : "更新失败！");
			}
			else
			{
				model.id = Guid.NewGuid().ToString("N");
				bool boolResult = dbuildingface.Add(model);
				return ResultTool.jsonResult(boolResult, boolResult ? "成功！" : "添加失败！");
			}
		}

		/// <summary>
		/// 楼层展示图 删除
		/// </summary>
		public JsonResult buildingfaceDelete(tb_buildingface model)
		{
			bool boolResult = dbuildingface.Delete(model);
			return ResultTool.jsonResult(boolResult, boolResult ? "成功！" : "删除失败！");
		}

		/// <summary>
		/// 楼层展示图 详情
		/// </summary>
		public ActionResult buildingfaceInfo(tb_buildingface model)
		{
			model = dbuildingface.GetInfo(model);
			return View(model??new tb_buildingface());
		}

	}
}

