﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Core.Controllers
{
    public class CoreController : Controller
    {
        //
        // GET: /Core/

        public ActionResult Index()
        {
            return View();
        }

        public ViewResult Main()
        {
            return View();
        }
    }
}