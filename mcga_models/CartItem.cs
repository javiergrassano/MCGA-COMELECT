using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace mcga.models
{

    [Table("CartsItems")]
    public partial class CartItem: GenericId
    {

        [ForeignKey("cart")]
        public Guid cartId { get; set; }

        [ForeignKey("product")]
        public Guid productId { get; set; }
        public virtual Product product { get; set; }

        public double price { get; set; }

        public int quantity { get; set; }

        public virtual Cart cart { get; set; }

        [NotMapped]
        public double total { get => price*(double)quantity;  }

    }
}
