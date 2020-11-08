using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace mcga.models
{

    [Table("AuditDVH")]
    public partial class AuditDvh
    {
        [Key, Column(Order=0), StringLength(40)]
        public string tableName{ get; set; }
        [Key, Column(Order = 1), StringLength(40)]
        public string id{ get; set; }
        
        [StringLength(40)]
        public string dv { get; set; }
    }
}
