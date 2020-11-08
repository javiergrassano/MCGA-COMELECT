using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace mcga.models
{
    public abstract class GenericAuditId: GenericId
    {
        [NotMapped]
        public string DV { get; set; }
	}

}
