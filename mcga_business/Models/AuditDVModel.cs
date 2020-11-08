using mcga.models;
using System;

namespace ArtEx.BL.Models
{
    public class AuditDVModel
    {
        public string tableName { get; set; }
        public Guid id { get; set; }
        public string detail { get; set; }
        public GenericAuditId objectModel { get; set; }
    }
}
