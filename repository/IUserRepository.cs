using entiti;

namespace repository
{
    public interface IUserRepository
    {
        Task ChangeUser(int id, User user);
        Task<User> CreateUser(User user);
        Task<User> GetUsersById(int id);
        Task<User> LoginUser(logUser logUser);
    }
}