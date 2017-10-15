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
	/// 房屋展示图
	/// </summary>
	public  class roomfaceController:Controller
	{
		D_roomface droomface = new D_roomface();
		/// <summary>
		/// 房屋展示图 列表
		/// </summary>
		public ActionResult roomfaceList(tb_roomface model)
		{
			int count = 0;
			ViewBag.roomfaceList = droomface.GetList(model, ref count);
			ViewBag.page = Utils.ShowPage(count, model.PageSize, model.PageIndex, 5);
			return View();
		}

		/// <summary>
		/// 房屋展示图 保存
		/// </summary>
		public JsonResult roomfaceSave(tb_roomface model)
		{
			if (model == null)
			{
				return ResultTool.jsonResult(false, "参数错误！");
			}
			if(!String.IsNullOrEmpty(model.id))
			{
				bool boolResult = droomface.Update(model);
				return ResultTool.jsonResult(boolResult, boolResult ? "成功！" : "更新失败！");
			}
			else
			{
				model.id = Guid.NewGuid().ToString("N");
				bool boolResult = droomface.Add(model);
				return ResultTool.jsonResult(boolResult, boolResult ? "成功！" : "添加失败！");
			}
		}

		/// <summary>
		/// 房屋展示图 删除
		/// </summary>
		public JsonResult roomfaceDelete(tb_roomface model)
		{
			bool boolResult = droomface.Delete(model);
			return ResultTool.jsonResult(boolResult, boolResult ? "成功！" : "删除失败！");
		}

		/// <summary>
		/// 房屋展示图 详情
		/// </summary>
		public ActionResult roomfaceInfo(tb_roomface model)
		{
			model = droomface.GetInfo(model);
			return View(model??new tb_roomface());
		}

	}
}

