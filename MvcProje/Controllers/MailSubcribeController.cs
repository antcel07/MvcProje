﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BusinessLayer.Concrete;
using EntityLayer.Concrete;

namespace MvcProje.Controllers
{
    public class MailSubcribeController : Controller
    {
        // GET: MailSubcribe
        [HttpGet]
        public PartialViewResult AddMail()
        {
            return PartialView();
        }
        [HttpPost]
        public PartialViewResult AddMail(SubscribeMail p)
        {
            SubscribeMailManager sm= new SubscribeMailManager();
            sm.BLAdd(p);
            return PartialView();
        }

    }
}