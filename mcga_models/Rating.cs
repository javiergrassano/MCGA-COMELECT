using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace mcga.models
{

    [Table("Ratings")]
    public partial class Rating
    {

        [Key, Column(Order = 0)]
        public Guid userId { get; set; }

        [Key, Column(Order = 1)]
        public Guid productId { get; set; }

        public DateTime createdOn { get; set; }

        public DateTime changedOn { get; set; }

        public int stars { get; set; }

    }
}
