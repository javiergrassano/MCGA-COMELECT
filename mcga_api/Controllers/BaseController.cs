using ArtEx.BL;
using mcga.models;
using mcga_api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Security.Principal;
using System.Threading;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;

namespace mcga_api.Controllers
{
    public class ApiBaseController : ApiController
    {
        internal BusinessContext ctx = null;
        internal User currentUser = null;

        public ApiBaseController()
        {
            var identity = Thread.CurrentPrincipal.Identity;
            if (identity.IsAuthenticated)
            {
                currentUser = new User() { id = Guid.Parse( "3c9c03d6-008a-5adf-42c2-a55dd4a1a9f2"), username = "purebas" };
                ctx = new BusinessContext(currentUser.id);
            }
            else
            {
                ctx = new BusinessContext();
            }
    }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                ctx = null;
            }
            base.Dispose(disposing);
        }

    }
}
