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
using AuthorizeAttribute = System.Web.Http.AuthorizeAttribute;
using NSwag.Annotations;

namespace mcga_api.Controllers
{
    public class AuditController : ApiBaseController
    {

        public IHttpActionResult Get()
        {
            try
            {
                var result = ctx.checkAuditDV();
                return Ok(result);
            }
            catch (Exception err)
            {
            }
            return BadRequest();
        }

        public IHttpActionResult Post()
        {
            try
            {
                ctx.createAuditDV();
                return Ok();
            }
            catch(Exception err)
            {
            }
            return BadRequest();
        }

    }
}
