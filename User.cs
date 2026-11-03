using System.ComponentModel.DataAnnotations;

namespace api_1
{
    public class User
    {
        public int id { get; set; }
        [Required]
        public string name { get; set; }
        [EmailAddress,Required]
        public string email { get; set; }
        [Required]
        public string password { get; set; }
    }
}
