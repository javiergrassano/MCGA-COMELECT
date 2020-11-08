using mcga.models;

namespace ArtEx.BL.Models
{
    public class UserModel
    {
        public string id { get; set; }
        public string username { get; set; }
        public Roles role { get; set; }
    }
}
