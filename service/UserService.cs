using Zxcvbn;
using entiti;
using repository;
namespace service
{
    public class UserService : IUserService
    {
        IUserRepository userData;
        public UserService(IUserRepository userData)
        {
            this.userData = userData;
        }
        public async Task<User> GetUsersById(int id)
        {
            return await userData.GetUsersById(id);
        }

        public async Task<User> CreateUser(User user)
        {
            int score = Core.EvaluatePassword(user.Password).Score;
            if (score < 3)
            {
                return null;
            }
            return await userData.CreateUser(user);
        }

        public async Task<User> LoginUser(logUser logUser)
        {
            return await userData.LoginUser(logUser);
        }

        public async Task ChangeUser(int id, User user)
        {
            int score = Core.EvaluatePassword(user.Password).Score;
            if (score < 3)
            {
                throw new Exception("bad password");
            }
            await userData.ChangeUser(id, user);
        }
    }


}