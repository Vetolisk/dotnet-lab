using Lab3.Models;

namespace Lab3.Interfaces
{
    public interface IUserManager
    {
        public User Find(string email);
        public void Add(User user);
        void Add(string login, string password, string email, string role);
        void MakeOrder(User user);
        IEnumerable<User> GetAll();
    }
}
