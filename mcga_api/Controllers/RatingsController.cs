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
    public class RatingsController : ApiBaseController
    {

        public IHttpActionResult Post([FromBody] ItemRequest model)
        {
            try
            {
                ctx.AddItemCart(model);
                return Ok();
            }
            catch(Exception err)
            {
                return BadRequest();
            }
        }
    }
}
