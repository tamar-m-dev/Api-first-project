using Zxcvbn;

namespace api_1.repository
{
    public class PasswordData : IPasswordData
    {
        public int PDCheckPassword(string password)
        {
            int score = Core.EvaluatePassword(password).Score;
            return score;
        }
    }
}
