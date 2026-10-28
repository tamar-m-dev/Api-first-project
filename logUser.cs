using System.ComponentModel.DataAnnotations;

namespace api_1
{
    //Class names are PascalCase and the file is named after the class.
    //A full name is clearer too: LoginUser (in LoginUser.cs), with properties Email and Password
    public class logUser
    {
        [EmailAddress,Required]
        public string email { get; set; }
        [Required]
        public string password { get; set; }
    }
}
