using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace mcga.models
{
    public class RatingRequest
    {
        public string userId { get; set; }
        public string  productId { get; set; }
        public int stars { get; set; }

    }
}
