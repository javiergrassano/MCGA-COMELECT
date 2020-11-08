using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace mcga_apirest.Controllers
{
    [Route("api/users")]
    [ApiController]
    public class Users : ControllerBase
    {
       [Route("nombre")]
       public string Nombre()
        {
            return "Javier";
        }

        [Route("listar")]
        public string Nombres()
        {
            return "Javier,Fernando";
        }



    }
}
