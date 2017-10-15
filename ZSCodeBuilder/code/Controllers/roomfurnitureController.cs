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
	/// 家具
	/// </summary>
	public  class roomfurnitureController:Controller
	{
		D_roomfurniture droomfurniture = new D_roomfurniture();
		/// <summary>
		/// 家具 列表
		/// </summary>
		public ActionResult roomfurnitureList(tb_roomfurniture model)
		{
			int count = 0;
			ViewBag.roomfurnitureList = droomfurniture.GetList(model, ref count);
			ViewBag.page = Utils.ShowPage(count, model.PageSize, model.PageIndex, 5);
			return View();
		}

		/// <summary>
		/// 家具 保存
		/// </summary>
		public JsonResult roomfurnitureSave(tb_roomfurniture model)
		{
			if (model == null)
			{
				return ResultTool.jsonResult(false, "参数错误！");
			}
			if(!String.IsNullOrEmpty(model.id))
			{
				bool boolResult = droomfurniture.Update(model);
				return ResultTool.jsonResult(boolResult, boolResult ? "成功！" : "更新失败！");
			}
			else
			{
				model.id = Guid.NewGuid().ToString("N");
				bool boolResult = droomfurniture.Add(model);
				return ResultTool.jsonResult(boolResult, boolResult ? "成功！" : "添加失败！");
			}
		}

		/// <summary>
		/// 家具 删除
		/// </summary>
		public JsonResult roomfurnitureDelete(tb_roomfurniture model)
		{
			bool boolResult = droomfurniture.Delete(model);
			return ResultTool.jsonResult(boolResult, boolResult ? "成功！" : "删除失败！");
		}

		/// <summary>
		/// 家具 详情
		/// </summary>
		public ActionResult roomfurnitureInfo(tb_roomfurniture model)
		{
			model = droomfurniture.GetInfo(model);
			return View(model??new tb_roomfurniture());
		}

	}
}

