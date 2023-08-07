using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;

namespace MvcProje.Controllers
{
    [AllowAnonymous]
    public class MailSubcribeController : Controller
    {
        SubscribeMailManager sm = new SubscribeMailManager(new EfMailDal());

        // GET: MailSubcribe
        [HttpGet]
        public PartialViewResult AddMail()
        {
            return PartialView();
        }
        [HttpPost]
        public PartialViewResult AddMail(SubscribeMail p)
        {
            
            sm.TAdd(p);
            return PartialView();
        }

    }
}