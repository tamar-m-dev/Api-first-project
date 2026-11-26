using Microsoft.EntityFrameworkCore;
using entiti;

namespace repository
{
    public class UserRepository : IUserRepository
    {
        my_shopContext _context;
        public UserRepository(my_shopContext _context)
        {
            this._context = _context;
        }
        public async Task<User> GetUsersById(int id)
        {
            return await _context.Users.FindAsync(id);
        }

        public async Task<User> CreateUser(User user)
        {
            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();
            return user;
        }

        public async Task<User> LoginUser(logUser logUser)
        {
            return await _context.Users.FirstOrDefaultAsync(u => u.Email == logUser.email && u.Password == logUser.password);
        }

        public async Task ChangeUser(int id, User user)
        {
            _context.Users.Update(user);
            await _context.SaveChangesAsync();
        }
    }
}
