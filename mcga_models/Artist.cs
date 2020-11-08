using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace mcga.models
{
    [Table("Artists")]
    public partial class Artist: GenericId
    {
        public Artist()
        {
        }

        [Required(ErrorMessage = "Nombre requerido")]
        [StringLength(30, ErrorMessage = "El nombre no puede superar los 30 caracteres")]
        public string firstName { get; set; }

        [Required(ErrorMessage = "Apellido requerido")]
        [StringLength(30, ErrorMessage = "El apellido no puede superar los 30 caracteres")]
        public string lastName { get; set; }

        [NotMapped]
        public string fullName { get => $"{lastName}, {firstName}"; }

        [StringLength(30, ErrorMessage = "El tiempo de vida no puede superar los 30 caracteres")]
        public string lifeSpan { get; set; }

        [StringLength(30, ErrorMessage = "El pais no puede superar los 30 caracteres")]
        public string country { get; set; }

        [StringLength(2000, ErrorMessage = "El apellido no puede superar los 2000 caracteres")]
        public string description { get; set; }

        public int totalProducts { get; set; }

        [NotMapped]
        public string image
        {
            get
            {
                return $"{Config.urlImage}/artists/{id}.jpg";
            }
        }

        [NotMapped]
        public string flagImage
        {
            get
            {
                return $"{Config.urlImage}/flag_{country}.png";
            }
        }

        //public virtual List<Product> products { get; set; }
    }
}
