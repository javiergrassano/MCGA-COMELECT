﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ArtExWeb.Controllers
{
    public class HomeController : BaseController
    {
        public ActionResult Index()
        {
            //ViewBag.mostSelled = ctx.ListProducts(orderBy: ProductOrderBy.quantitySold).Take(4);
            //ViewBag.bestRanked = ctx.ListProducts(orderBy: ProductOrderBy.rating).Take(4);
            return View();
        }

    }
}