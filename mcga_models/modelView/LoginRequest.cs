using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace mcga.models
{
    public class LoginRequest
    {
        public string username{ get; set; }
        public string  password { get; set; }
    }
}
