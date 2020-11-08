using System.ComponentModel.DataAnnotations.Schema;

namespace mcga.models
{
    [Table("OrderNumber")]
    public partial class OrderNumber: GenericId
    {
        public int number { get; set; }
    }
}
