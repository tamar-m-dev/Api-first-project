using System.ComponentModel.DataAnnotations;

namespace api_1.entiti
{
    public class logUser
    {
        [EmailAddress,Required]
        public string email { get; set; }
        [Required]
        public string password { get; set; }
    }
}
