using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace mcga.models
{
    [Table("Carts")]
    public partial class Cart: GenericId
    {

        [Required]
        [StringLength(40)]
        public string cookie { get; set; }

        public DateTime cartDate { get; set; }

        public int itemCount { get; set; }
        
        public double total { get; set; }

        public List<CartItem> items { get; set; }
    }
}
