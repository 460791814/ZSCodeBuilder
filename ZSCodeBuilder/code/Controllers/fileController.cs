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
	/// 文件表
	/// </summary>
	public  class fileController:Controller
	{
		D_file dfile = new D_file();
		/// <summary>
		/// 文件表 列表
		/// </summary>
		public ActionResult fileList(tb_file model)
		{
			int count = 0;
			ViewBag.fileList = dfile.GetList(model, ref count);
			ViewBag.page = Utils.ShowPage(count, model.PageSize, model.PageIndex, 5);
			return View();
		}

		/// <summary>
		/// 文件表 保存
		/// </summary>
		public JsonResult fileSave(tb_file model)
		{
			if (model == null)
			{
				return ResultTool.jsonResult(false, "参数错误！");
			}
			if(!String.IsNullOrEmpty(model.id))
			{
				bool boolResult = dfile.Update(model);
				return ResultTool.jsonResult(boolResult, boolResult ? "成功！" : "更新失败！");
			}
			else
			{
				model.id = Guid.NewGuid().ToString("N");
				bool boolResult = dfile.Add(model);
				return ResultTool.jsonResult(boolResult, boolResult ? "成功！" : "添加失败！");
			}
		}

		/// <summary>
		/// 文件表 删除
		/// </summary>
		public JsonResult fileDelete(tb_file model)
		{
			bool boolResult = dfile.Delete(model);
			return ResultTool.jsonResult(boolResult, boolResult ? "成功！" : "删除失败！");
		}

		/// <summary>
		/// 文件表 详情
		/// </summary>
		public ActionResult fileInfo(tb_file model)
		{
			model = dfile.GetInfo(model);
			return View(model??new tb_file());
		}

	}
}

