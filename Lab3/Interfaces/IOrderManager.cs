using Lab3.Models;

namespace Lab3.Interfaces
{
    public interface IOrderManager
    {
        public IEnumerable<Order> GetUserOrders(string emailD);
        public void Add(Order order);
    }
}
