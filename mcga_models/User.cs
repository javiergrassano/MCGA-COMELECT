using mcga.interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.CompilerServices;

namespace mcga.models
{
    public enum Roles: short
    {
        User,
        Administrator,
        SystemAdmin
    }

    [Table("Users")]
    public partial class User: GenericAuditId, IUser, IAudit
    {
        public User()
        {
            active = true;
            bloqued = false;
        }

        [Required]
        [StringLength(30)]
        public string username { get; set; }

        [Required]
        [StringLength(30)]
        public string firstName { get; set; }

        [Required]
        [StringLength(30)]
        public string lastName { get; set; }

        [Required]
        [StringLength(100)]
        public string email { get; set; }

        [Required]
        [StringLength(100)]
        public string password { get; set; }

        public string token { get; set; }
        public DateTime? signupDate { get; set; }
        public DateTime? tokenExpiration { get; set; }

        public Roles role { get; set; }
        public short retries { get; set; }
        public bool bloqued { get; set; }
        public bool active { get; set; }
        
    }
}
