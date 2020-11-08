using ArtEx.BL;
using System.Web.Http;

namespace mcga_api.Controllers
{
    public class ApiBaseController : ApiController
    {
        internal BusinessContext ctx = new BusinessContext();

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
