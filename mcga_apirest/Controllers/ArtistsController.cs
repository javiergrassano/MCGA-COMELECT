using System;
using System.IO;
using System.Net;
using System.Web;
using HttpGetAttribute = System.Web.Http.HttpGetAttribute;
using ArtEx.BL;
using mcga.models;
using AuthorizeAttribute = System.Web.Http.AuthorizeAttribute;
using Microsoft.AspNetCore.Mvc;
using FromBodyAttribute = Microsoft.AspNetCore.Mvc.FromBodyAttribute;

namespace mcga_api.Controllers
{
    //[Authorize]
    [Route("api/artists")]
    [ApiController]
    public class ArtistsController : ApiBaseController
    {
        /// <summary>
        /// Retorna una lista de artistas, paginado
        /// </summary>
        /// <param name="search">Texto a buscar</param>
        /// <param name="page">Pagina actual</param>
        /// <param name="rows">Cantidad de registros por pagina</param>
        /// <param name="order">Columna ordenada</param>
        /// <returns></returns>
        [HttpGet]
        public System.Web.Http.IHttpActionResult Get([FromQuery] string search, [FromQuery] int page, [FromQuery] int rows, [FromQuery] int order)
        {
            var list = ctx.listArtits(search, page, rows, (ArtitsOrderBy)order);

            PagerResult result = new PagerResult(page,rows);
            result.totalRecords = ctx.totalArtists();
            result.setResult<Artist>(list);

            return Ok(result);
        }

        [HttpGet, Route("/{id}")]
        public System.Web.Http.IHttpActionResult Get(string id)
        {
            if (id == null)
            {
                return BadRequest();
            }
            Artist model = ctx.findArtit(id);
            if (model == null)
            {
                return NotFound();
            }
            return Ok(model);
        }

        public System.Web.Http.IHttpActionResult Post([FromBody] Artist model)
        {
            try
            {
                ctx.Update(model);
                return Ok(model.id);
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
