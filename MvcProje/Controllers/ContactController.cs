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
    public class ContactController : Controller
    {
        // GET: Contact
        ContactManager cm=new ContactManager(new EfContactDal());

        [AllowAnonymous]
        public ActionResult Index()
        {
            return View();
        }
        [AllowAnonymous]
        [HttpGet]
        public ActionResult SendMessage() 
        {
            return View();
        }
        [AllowAnonymous]
        [HttpPost]
        public ActionResult SendMessage(Contact p)
        {
			ContactValidator contactvalidator = new ContactValidator();
			ValidationResult results = contactvalidator.Validate(p);
			if (results.IsValid)
			{
                p.MessageDate = DateTime.Parse(DateTime.Now.ToShortDateString());
				cm.TAdd(p);
				return RedirectToAction("Index","Blog");
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

        public ActionResult SendBox()
        {
            var messagelist = cm.GetList();
            return View(messagelist);  
        }

        public ActionResult MessageDetails(int id)
        {
            Contact contact = cm.GetById(id);
            return View(contact);
        }
    }
}