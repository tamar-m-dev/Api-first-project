using System.ComponentModel.DataAnnotations;

namespace api_1
{
    //In C#, public properties are written in PascalCase (Id, Name, Email, Password).
    //If you rename them, User.txt still has the old names, so read it with
    //new JsonSerializerOptions { PropertyNameCaseInsensitive = true }
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
