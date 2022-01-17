using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DoubleADevMVC.Controllers
{
    public class PeerController : Controller
    {
        // GET: Peer
        public ActionResult Peers()
        {
            return View();
        }
    }
}