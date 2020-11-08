using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace mcga.models
{
    public class ItemRequest
    {
        public string cartId { get; set; }
        public string  productId { get; set; }
        public int quantity { get; set; }

    }
}
