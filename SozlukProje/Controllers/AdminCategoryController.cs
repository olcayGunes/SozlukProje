using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SozlukProje.Controllers
{
    public class AdminCategoryController : Controller
    {
        CategoryManager categoryManager = new CategoryManager(new EfCategoryDal());

        public ActionResult Index()
        {
            var categoryValues = categoryManager.GetList();
            return View(categoryValues);
        }

        [HttpGet]
        public ActionResult AddCategory()
		{
            return View();
		}

        [HttpPost]
        public ActionResult AddCategory(Category p)
		{
            CategoryValidator categoryValidator = new CategoryValidator();
            ValidationResult results = categoryValidator.Validate(p);
			if (results.IsValid)
			{
                categoryManager.CategoryAdd(p);
                return RedirectToAction("Index");
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

        public ActionResult DeleteCategory (int id)
		{
            var categoryValue = categoryManager.GetById(id);
            categoryManager.CategoryDelete(categoryValue);
            return RedirectToAction("Index");
		}

        [HttpGet]
        public ActionResult UpdateCategory(int id)
		{
            var categoryValue = categoryManager.GetById(id);
            categoryManager.CategoryUpdate(categoryValue);
            return View(categoryValue);
		}

        [HttpPost]
        public ActionResult UpdateCategory(Category p)
        {
            categoryManager.CategoryUpdate(p);
            return RedirectToAction("Index");
        }
    }
}