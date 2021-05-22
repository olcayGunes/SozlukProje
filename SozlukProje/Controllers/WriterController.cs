﻿using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SozlukProje.Controllers
{
	public class WriterController : Controller
	{
		WriterManager writerManager = new WriterManager(new EfWriterDal());
		public ActionResult Index()
		{
			var writerValues = writerManager.GetList();
			return View(writerValues);
		}

		[HttpGet]
		public ActionResult AddWriter()
		{
			return View();
		}

		[HttpPost]
		public ActionResult AddWriter(Writer writer)
		{
			WriterValidator writerValidator = new WriterValidator();
			ValidationResult results = writerValidator.Validate(writer);

			if (results.IsValid)
			{
				writerManager.WriterAdd(writer);
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
	}
}