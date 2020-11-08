using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using mcga.models;
using ArtExWeb.Helpers;

namespace ArtExWeb.Controllers
{
    [Authorize]
    public class OrdersController : BaseController
    {
        // GET: Orders/Create
        public ActionResult Create()
        {
            //string id = User?.Identity?.GetUserId() ?? "";
            //ctx = new SessionContext(id);

            //Order order = ctx.CloseCart(cookie);
            //return View(order);
            return View();
        }

        public ActionResult List()
        {
            //string id = User?.Identity?.GetUserId() ?? "";
            //ctx = new SessionContext(id);
            //var orders = ctx.GetOrders();
            //return View(orders.ToList());
            return View();
        }

    }
}
