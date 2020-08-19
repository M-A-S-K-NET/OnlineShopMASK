using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineShopMASK.WebUI.Controllers
{
    public class HtmlController : Controller
    {
        // GET: Html
        public ActionResult Contact()
        {
            var result = new FilePathResult("~/Views/Html Pages/Contact.html", "text/html");
            return result;
        }
    }
}