using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace mcga.models
{

    [Table("OrdersDetails")]
    public partial class OrderDetail: GenericId
    {
        [ForeignKey("order")]
        public Guid orderId { get; set; }

        [ForeignKey("product")]
        public Guid productId { get; set; }

        public double price { get; set; }

        public int quantity { get; set; }

        [NotMapped]
        public double total { get => price * (double)quantity; }

        public virtual Order order { get; set; }
        public virtual Product product { get; set; }
    }
}
