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
	/// 首页 推荐内容
	/// </summary>
	public  class featureController:Controller
	{
		D_feature dfeature = new D_feature();
		/// <summary>
		/// 首页 推荐内容 列表
		/// </summary>
		public ActionResult featureList(tb_feature model)
		{
			int count = 0;
			ViewBag.featureList = dfeature.GetList(model, ref count);
			ViewBag.page = Utils.ShowPage(count, model.PageSize, model.PageIndex, 5);
			return View();
		}

		/// <summary>
		/// 首页 推荐内容 保存
		/// </summary>
		public JsonResult featureSave(tb_feature model)
		{
			if (model == null)
			{
				return ResultTool.jsonResult(false, "参数错误！");
			}
			if(!String.IsNullOrEmpty(model.id))
			{
				bool boolResult = dfeature.Update(model);
				return ResultTool.jsonResult(boolResult, boolResult ? "成功！" : "更新失败！");
			}
			else
			{
				model.id = Guid.NewGuid().ToString("N");
				bool boolResult = dfeature.Add(model);
				return ResultTool.jsonResult(boolResult, boolResult ? "成功！" : "添加失败！");
			}
		}

		/// <summary>
		/// 首页 推荐内容 删除
		/// </summary>
		public JsonResult featureDelete(tb_feature model)
		{
			bool boolResult = dfeature.Delete(model);
			return ResultTool.jsonResult(boolResult, boolResult ? "成功！" : "删除失败！");
		}

		/// <summary>
		/// 首页 推荐内容 详情
		/// </summary>
		public ActionResult featureInfo(tb_feature model)
		{
			model = dfeature.GetInfo(model);
			return View(model??new tb_feature());
		}

	}
}

