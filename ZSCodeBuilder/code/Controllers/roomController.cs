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
	/// 房屋租赁
	/// </summary>
	public  class roomController:Controller
	{
		D_room droom = new D_room();
		/// <summary>
		/// 房屋租赁 列表
		/// </summary>
		public ActionResult roomList(tb_room model)
		{
			int count = 0;
			ViewBag.roomList = droom.GetList(model, ref count);
			ViewBag.page = Utils.ShowPage(count, model.PageSize, model.PageIndex, 5);
			return View();
		}

		/// <summary>
		/// 房屋租赁 保存
		/// </summary>
		public JsonResult roomSave(tb_room model)
		{
			if (model == null)
			{
				return ResultTool.jsonResult(false, "参数错误！");
			}
			if(!String.IsNullOrEmpty(model.id))
			{
				bool boolResult = droom.Update(model);
				return ResultTool.jsonResult(boolResult, boolResult ? "成功！" : "更新失败！");
			}
			else
			{
				model.id = Guid.NewGuid().ToString("N");
				bool boolResult = droom.Add(model);
				return ResultTool.jsonResult(boolResult, boolResult ? "成功！" : "添加失败！");
			}
		}

		/// <summary>
		/// 房屋租赁 删除
		/// </summary>
		public JsonResult roomDelete(tb_room model)
		{
			bool boolResult = droom.Delete(model);
			return ResultTool.jsonResult(boolResult, boolResult ? "成功！" : "删除失败！");
		}

		/// <summary>
		/// 房屋租赁 详情
		/// </summary>
		public ActionResult roomInfo(tb_room model)
		{
			model = droom.GetInfo(model);
			return View(model??new tb_room());
		}

	}
}

