using System.ComponentModel.DataAnnotations;

namespace api_1
{
    public class User
    {
        //Public properties are PascalCase in C#, but don't rename them: the data file uses these names. Read the JSON with new JsonSerializerOptions { PropertyNameCaseInsensitive = true }
        public int id { get; set; }
        [Required]
        public string name { get; set; }
        [EmailAddress,Required]
        public string email { get; set; }
        [Required]
        public string password { get; set; }
    }
}
