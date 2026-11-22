using api.repository;
namespace api.service
{
    public class PasswordService : IPasswordService
    {
        private IPasswordData PD;
        public PasswordService(IPasswordData PD)
        {
            this.PD = PD;
        }
        public int CheckPassword(string password)
        {
            return PD.PDCheckPassword(password);
        }
    }
}
