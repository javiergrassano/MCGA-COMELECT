using System;
using System.IO;
using System.Net;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using HttpGetAttribute = System.Web.Http.HttpGetAttribute;
using RoutePrefixAttribute = System.Web.Http.RoutePrefixAttribute;
using System.Web.Helpers;
using System.Collections.Generic;
using ArtEx.BL;
using mcga.models;

namespace mcga_api.Controllers
{

    //[Authorize]
    //[RoutePrefix("api/artists")]
    public class CartsController : ApiBaseController
    {
        //public IHttpActionResult Get([FromUri] string search, [FromUri] int page, [FromUri] int rows, [FromUri] int order)
        //{
        //    var list = ctx.listArtits(search, page, rows, (ArtitsOrderBy)order);

        //    PagerResult result = new PagerResult(page,rows);
        //    result.totalRecords = ctx.totalArtists();
        //    result.setResult<Artist>(list);

        //    return Ok(result);
        //}

        public IHttpActionResult Get(string id)
        {
            if (id == null)
            {
                return BadRequest();
            }
            Cart model = ctx.findCart(id);
            if (model == null)
            {
                return NotFound();
            }
            return Ok(model);
        }

        public IHttpActionResult Post([FromBody] ItemRequest model)
        {
            try
            {
                ctx.AddItemCart(model);
                return Ok(model);
            }
            catch(Exception err)
            {
                return BadRequest();
            }
        }
            
        // DELETE api/<controller>/5
        public void Delete(int id)
        {
        }




        //[HttpPost]
        //[Authorize(Roles = "Admin")]
        //public ActionResult Update(Artist artist, HttpPostedFileBase newImage)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        try
        //        {
        //            ctx.Update(artist);

        //            if (newImage != null && newImage.ContentLength > 0)
        //            {
        //                string _FileName = $"Artist_{artist.id}.jpg";
        //                string _path = Path.Combine(Server.MapPath("~/public"), _FileName);
        //                newImage.SaveAs(_path);
        //            }
        //        }
        //        catch (Exception ex)
        //        {
        //            LogHelper.Logs(ex);
        //        }

        //        return RedirectToAction("Index");
        //    }
        //    return View("Edit", artist);
        //}


    }
}
