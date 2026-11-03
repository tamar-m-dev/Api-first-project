using Zxcvbn;

namespace repository
{
    public class PasswordData
    {
        public int PDCheckPassword(string password)
        {
            int score = Core.EvaluatePassword(password).Score;
            return score;
        }
    }
}
