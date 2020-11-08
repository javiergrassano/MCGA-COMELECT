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
using RouteAttribute = System.Web.Http.RouteAttribute;

namespace mcga_api.Controllers
{

    //[Authorize]
    [RoutePrefix("api/products")]
    public class ProductsController : ApiBaseController
    {
        public IHttpActionResult Get([FromUri] string search, [FromUri] string artistId, [FromUri] int page, [FromUri] int rows, [FromUri] int order)
        {
            var list = ctx.listProducts(search, artistId, page, rows, (ProductOrderBy)order);

            PagerResult result = new PagerResult(page, rows);
            result.totalRecords = ctx.totalProducts();
            result.setResult<Product>(list);

            return Ok(result);
        }

        [Route("getall")]
        public IHttpActionResult GetAll([FromUri] string search, [FromUri] string artistId, [FromUri] int order)
        {
            List<Product> list = ctx.listProducts(search, artistId, 0, 0, (ProductOrderBy)order);
            return Ok(list);
        }

        [Route("getid")]
        public IHttpActionResult GetId([FromUri] string id)
        {
            if (id == null)
            {
                return BadRequest();
            }
            Product model = ctx.findProduct(id);
            if (model == null)
            {
                return NotFound();
            }
            return Ok(model);
        }

        public IHttpActionResult Post([FromBody] Product model)
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
    }
}
