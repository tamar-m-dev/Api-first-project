using entiti;
using Zxcvbn;
namespace service
{
    public class PasswordService : IPasswordService
    {
        public int CheckPassword(string password)
        {
            return Core.EvaluatePassword(password).Score;
        }
    }
}
