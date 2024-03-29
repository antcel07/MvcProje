﻿using System;
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
    public class AuthorController : Controller
    {
        // GET: Author

        BlogManager blogmanager = new BlogManager(new EfBlogDal());
        AuthorManager authormanager= new AuthorManager(new EfAuthorDal());

        [AllowAnonymous]
        public PartialViewResult AuthorAbout(int id)
        {
            var authordetail=blogmanager.GetBlogById(id);
            return PartialView(authordetail);
        }

        [AllowAnonymous]
        public PartialViewResult AuthorPopularPost(int id)
        {
            var blogauthorid=blogmanager.GetList().Where(x=>x.BlogId==id).Select(y=>y.AuthorId).FirstOrDefault();
          
            var authorblogs=blogmanager.GetBlogByAuthor(blogauthorid);
            return PartialView(authorblogs);
        }

        public ActionResult AuthorList()
        {
           var authorlists= authormanager.GetList();
            return View(authorlists);
        }

        [HttpGet]
        public ActionResult AddAuthor()
        {

            return View();
        }

        [HttpPost]
        public ActionResult AddAuthor(Author p)
        {
			AuthorValidator authorvalidator = new AuthorValidator();
			ValidationResult results = authorvalidator.Validate(p);
			if (results.IsValid)
			{
				authormanager.TAdd(p);
				return RedirectToAction("AuthorList");
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
        public ActionResult AuthorEdit(int id)
        {
            Author author=authormanager.GetById(id);
            return View(author);
        }
        [HttpPost]
        public ActionResult AuthorEdit(Author p)
        {
			AuthorValidator authorvalidator = new AuthorValidator();
			ValidationResult results = authorvalidator.Validate(p);
			if (results.IsValid)
			{
				authormanager.TUpdate(p);
				return RedirectToAction("AuthorList");
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