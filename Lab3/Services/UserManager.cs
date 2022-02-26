using Lab3.Context;
using Lab3.Interfaces;
using Lab3.Models;

namespace Lab3.Services
{
    public class UserManager : IUserManager
    {
        private readonly DataContext _dataContext;

        public UserManager(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public void Add(string login, string password, string email, string role)
        {
            User user = new User();
            user.login = login;
            user.Password = password;
            user.email = email;
            user.role = role;
            _dataContext.Users.Add(user);
            _dataContext.SaveChanges();
        }

        public void Add(User user)
        {
            _dataContext.Users.Add(user);
            _dataContext.SaveChanges();
        }

        public User Find(string login)
        {
            foreach (User user in _dataContext.Users)
            {
                if (user.login == login || user.email == login)
                    return user;
            }
            return null;
        }

        public IEnumerable<User> GetAll()
        {
            return _dataContext.Users;
        }

        public void MakeOrder(User user)
        {
            Order order = new Order();
            order.userId = user.Id;
        }
    }
}
