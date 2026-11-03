using api_1.entiti;
using api_1.repository;
namespace api_1.service;
public class UserService
{
        UserData userData = new UserData();
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
            userData.UDChangeUser(id, user);
        }
}


