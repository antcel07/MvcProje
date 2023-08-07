using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;

namespace MvcProje.Controllers
{
	public class CategoryController : Controller
	{
		// GET: Category
		CategoryManager cm = new CategoryManager(new EfCategoryDal());
	
		[AllowAnonymous]
		public PartialViewResult BlogDetailsCategoryList()
		{
			var categoryvalues = cm.GetList();
			return PartialView(categoryvalues);
		}

		public ActionResult AdminCategoryList()
		{
			var categoryList = cm.GetList();
			return View(categoryList);
		}
		[HttpGet]
		public ActionResult AdminCategoryAdd()
		{

			return View();
		}
		[HttpPost]
		public ActionResult AdminCategoryAdd(Category p)
		{
			CategoryValidator categoryvalidator = new CategoryValidator();
			ValidationResult results = categoryvalidator.Validate(p);
			if (results.IsValid)
			{
				cm.TAdd(p);
				return RedirectToAction("AdminCategoryList");
			}

			else
			{
                foreach (var item in results.Errors)
                {
					ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
			return View();
		}

		[HttpGet]
		public ActionResult CategoryEdit(int id)
		{
			Category category = cm.GetById(id);
			return View(category);
		}
		[HttpPost]
		public ActionResult CategoryEdit(Category p)
		{
			CategoryValidator categoryvalidator = new CategoryValidator();
			ValidationResult results = categoryvalidator.Validate(p);
			if (results.IsValid)
			{
				cm.TUpdate(p);
			return RedirectToAction("AdminCategoryList");
			}

			else
			{
				foreach (var item in results.Errors)
				{
					ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
				}
			}
			return View();

			
		}

		public ActionResult CategoryDelete(int id)
		{
			cm.CategoryStatusFalseBL(id);
			return RedirectToAction("AdminCategoryList");
		}
		public ActionResult CategoryStatusTrue(int id)
		{
			cm.CategoryStatusTrueBL(id);
			return RedirectToAction("AdminCategoryList");
		}

	}
}
