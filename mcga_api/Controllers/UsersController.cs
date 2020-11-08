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
using AuthorizeAttribute = System.Web.Mvc.AuthorizeAttribute;

namespace mcga_api.Controllers
{

    [Authorize]
    public class UsersController : ApiBaseController
    {
        public IHttpActionResult Get([FromUri] string search, [FromUri] string artistId, [FromUri] int page, [FromUri] int rows, [FromUri] int order)
        {
            var list = ctx.listUsers(search, artistId, page, rows, (UserOrderBy)order);

            PagerResult result = new PagerResult(page, rows);
            result.totalRecords = ctx.totalUsers();
            result.setResult<User>(list);

            return Ok(result);
        }

        public IHttpActionResult Get(string id)
        {
            if (id == null)
            {
                return BadRequest();
            }
            User model = ctx.findUser(id);
            if (model == null)
            {
                return NotFound();
            }
            return Ok(model);
        }

        public IHttpActionResult Post([FromBody] User model)
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
