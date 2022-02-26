using Lab3.Context;
using Lab3.Interfaces;
using Lab3.Models;

namespace Lab3.Services
{
    public class OrderManager : IOrderManager
    {
        private readonly DataContext _dataContext;

        public OrderManager(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public void Add(Order order)
        {
            _dataContext.Orders.Add(order);
            _dataContext.SaveChanges();
        }

        public IEnumerable<Order> GetUserOrders(string email)
        {
            var user = _dataContext.Users.FirstOrDefault(u => u.login == email || u.email == email);
            return _dataContext.Orders.Where(o => o.userId == user.Id);
        }
    }
}
