using mcga.models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.CompilerServices;

namespace mcga.interfaces
{
    public interface IUser
    {
        string username { get; set; }
        string firstName { get; set; }
        string lastName { get; set; }
        string email { get; set; }
        Roles role { get; set; }
        short retries { get; set; }
        bool bloqued { get; set; }
        bool active { get; set; }
        
    }
}
