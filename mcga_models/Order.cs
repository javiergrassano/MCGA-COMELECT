using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace mcga.models
{

    public enum MethodsOfPayment: short{
        Cash,
        CreditCard
    }

    [Table("Orders")]
    public partial class Order: GenericId
    {
        public Order()
        {
            items = new List<OrderDetail>();
        }

        public Guid userId { get; set; }

        public DateTime orderDate { get; set; }

        public int orderNumber { get; set; }

        [NotMapped]
        public string period { get => orderDate.ToString("yyyy-MM"); }

        public MethodsOfPayment methodOfPayment { get; set; }

        public double totalPrice { get; set; }

        public int itemCount { get; set; }

        public virtual List<OrderDetail> items { get; set; }

    }

}
