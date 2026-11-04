using api_1.entiti;

namespace api_1.repository
{
    public interface IUserData
    {
        void UDChangeUser(int id, User user);
        User UDCreateUser(User user);
        List<User> UDGetUsers();
        User UDGetUsersById(int id);
        User UDLoginUser(logUser logUser);
    }
}