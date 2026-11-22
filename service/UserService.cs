using api.entiti;
using api.repository;
namespace api.service
{
    public class UserService : IUserService
    {
        IUserData userData;
        public UserService(IUserData userData)
        {
            this.userData = userData;
        }
        public User GetUsersById(int id)
        {
            return userData.UDGetUsersById(id);
        }

        public List<User> GetUsers()
        {
            return userData.UDGetUsers();
        }

        public User CreateUser(User user)
        {
            return userData.UDCreateUser(user);
        }

        public User LoginUser(logUser logUser)
        {
            return userData.UDLoginUser(logUser);
        }

        public void ChangeUser(int id, User user)
        {
            try
            {
                userData.UDChangeUser(id, user);
            }
            catch(Exception)
            {
                throw;
            }
        }
    }


}