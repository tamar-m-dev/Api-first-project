using entiti;
namespace service
{
    public interface IUserService
    {
        Task ChangeUser(int id, User user);
        Task<User> CreateUser(User user);
        Task<User> GetUsersById(int id);
        Task<User> LoginUser(logUser logUser);
    }
}