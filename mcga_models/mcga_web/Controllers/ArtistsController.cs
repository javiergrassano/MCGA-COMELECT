﻿using mcga.models;
using ArtExWeb.Helpers;
using System;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace ArtExWeb.Controllers
{
    public class ArtistsController : BaseController
    {
        public ActionResult Index(string search, int page = 0, int orderBy = 0)
        {
            //return View(ctx.listArtits(search, page, 15, (ArtitsOrderBy)orderBy));
            return View();
        }

        public ActionResult View(int? id)
        {
            //if (id == null)
            //{
            //    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            //}
            //Artist artist = ctx.findArtit(id.Value);
            //if (artist == null)
            //{
            //    return HttpNotFound();
            //}
            //return View(artist);
            return View();
        }

        [Authorize(Roles = "Admin")]
        public ActionResult Create()
        {
            return View("Edit", new Artist());
        }

        [Authorize(Roles = "Admin")]
        public ActionResult Edit(int? id)
        {
            //if (id == null)
            //{
            //    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            //}
            //Artist artist = ctx.findArtit(id.Value);
            //if (artist == null)
            //{
            //    return HttpNotFound();
            //}
            //return View("Edit", artist);
            return View();
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public ActionResult Update(Artist artist, HttpPostedFileBase newImage)
        {
            //if (ModelState.IsValid)
            //{
            //    try
            //    {
            //        ctx.Update(artist);

            //        if (newImage != null && newImage.ContentLength > 0)
            //        {
            //            string _FileName = $"Artist_{artist.id}.jpg";
            //            string _path = Path.Combine(Server.MapPath("~/public"), _FileName);
            //            newImage.SaveAs(_path);
            //        }
            //    }
            //    catch (Exception ex)
            //    {
            //        LogHelper.Logs(ex);
            //    }

            //    return RedirectToAction("Index");
            //}
            //return View("Edit", artist);
            return View();
        }
    }
}
