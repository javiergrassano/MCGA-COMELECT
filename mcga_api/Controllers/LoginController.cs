using ArtEx.BL;
using mcga.models;
using mcga.tools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Runtime.InteropServices.ComTypes;
using System.Security.Cryptography;
using System.Security.Principal;
using System.Threading;
using System.Web.Http;

namespace mcga_api.Controllers
{
    /// <summary>
    /// login controller class for authenticate users
    /// </summary>
    [AllowAnonymous]
    [RoutePrefix("api/login")]
    public class LoginController : ApiController
    {
        [HttpGet]
        [Route("echoping")]
        public IHttpActionResult EchoPing()
        {
            return Ok(true);
        }

        [HttpGet]
        [Route("echouser")]
        public IHttpActionResult EchoUser()
        {
            IIdentity identity = Thread.CurrentPrincipal.Identity;
            return Ok($" IPrincipal-user: {identity.Name} - IsAuthenticated: {identity.IsAuthenticated}");
        }

        [HttpGet]
        [Route("listar")]
        public IHttpActionResult Listar()
        {
            return Ok(true);
        }

        [HttpPost]
        [Route("authenticate")]
        public IHttpActionResult Authenticate(LoginRequest login)
        {
            string token = "";

            if (login == null)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            BusinessContext ctx = new BusinessContext();
            User user = ctx.findUser(login.username);
            login.password = Cryptog.EncriptarMD5(login.password);
            if (user == null || !user.active || user.bloqued || user.password != login.password)
                return Unauthorized();

            token = TokenGenerator.GenerateTokenJwt(user.id.ToString(), login.username, user.role.ToString());
            return Ok(token);
        }
    }
}