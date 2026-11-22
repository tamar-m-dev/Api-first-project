using Zxcvbn;

namespace api.repository
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
