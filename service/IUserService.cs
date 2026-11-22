using api.entiti;
namespace api.service
{
    public interface IUserService
    {
        void ChangeUser(int id, User user);
        User CreateUser(User user);
        List<User> GetUsers();
        User GetUsersById(int id);
        User LoginUser(logUser logUser);
    }
}