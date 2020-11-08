﻿using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using mcga.models;
using ArtExWeb.Helpers;

namespace ArtExWeb.Controllers
{
    public class ProductsController : BaseController
    {

        public ActionResult Index(string search, int page = 0, int orderBy = 0)
        {
//            return View(ctx.ListProducts(search, page, 15, (ProductOrderBy)orderBy));
            return View();
        }

        public ActionResult View(int? id)
        {
            //if (id == null)
            //{
            //    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            //}
            //Product product = ctx.findProduct(id.Value);
            //if (product == null)
            //{
            //    return HttpNotFound();
            //}
            //return View(product);
            return View();
        }

        public ActionResult Create()
        {
            //ViewBag.artistId = new SelectList(ctx.listArtits(), "id", "fullName");
            //return View("Edit");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Product product)
        {
            //if (ctx.IsValid(product))
            //{
            //    ctx.Update(product);
            //    return RedirectToAction("Index");
            //}
            //ViewBag.artistId = new SelectList(ctx.listArtits(), "id", "fullName");
            //return View("Edit", product);
            return View();
        }


        public ActionResult Edit(int? id)
        {
            //if (id == null)
            //{
            //    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            //}
            //Product product = ctx.findProduct(id.Value);
            //if (product == null)
            //{
            //    return HttpNotFound();
            //}
            //ViewBag.artistId = new SelectList(ctx.listArtits(), "id", "fullName");
            //return View("Edit", product);
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Update(Product product , HttpPostedFileBase newImage)
        {
            //ModelState["Id"].Errors.Clear();
            //if (ModelState.IsValid)
            //{
            //    try
            //    {
            //        product.image = DateTime.Now.ToString("yyyyMMddHHmmss") + newImage.FileName.Substring(newImage.FileName.Length - 4, 4); // newImage.FileName.Substring(0,26) + newImage.FileName.Substring(newImage.FileName.Length-4, 4);
            //        ctx.Update(product);

            //        if (newImage.ContentLength > 0)
            //        {
            //            string _path = Path.Combine(Server.MapPath("~/public/pictures"), product.image);
            //            newImage.SaveAs(_path);
            //        }
            //        return RedirectToAction("Index");
            //    }
            //    catch(Exception ex)
            //    {
            //        LogHelper.Logs(ex);
            //    }
                
            //}
            
            //ViewBag.artistId = new SelectList(ctx.listArtits(), "id", "fullName");
            //return View("Edit", product);
            return View();
        }

    }
}
