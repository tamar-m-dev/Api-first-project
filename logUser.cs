using System.ComponentModel.DataAnnotations;

namespace api_1
{
    //In C#, class names are PascalCase: LogUser, in a file named LogUser.cs
    public class logUser
    {
        [EmailAddress,Required]
        public string email { get; set; }
        [Required]
        public string password { get; set; }
    }
}
