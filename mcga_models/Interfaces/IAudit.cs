using mcga.models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.CompilerServices;

namespace mcga.interfaces
{
    public interface IAudit
    {
        Guid id { get; set; }
        string DV { get; set; }
    }
}
