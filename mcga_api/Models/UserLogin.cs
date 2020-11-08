using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Formatting;
using System.Web;

namespace mcga_api.Models
{
    public class UserLogin
    {
        public UserLogin(string userId, string name, string role)
        {
            this.userId = userId;
            this.name = name;
            this.role = role;
        }
        public string userId { get; private set; }
        public string name { get; private set; }
        public string role { get; private set; }
    }
}