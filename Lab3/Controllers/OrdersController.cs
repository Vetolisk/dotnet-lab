using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Lab3.Models;
using Lab3.Context;
using Lab3.Interfaces;

namespace Lab3.Controllers
{
    public class OrdersController : Controller
    {
        private readonly IOrderManager _orderManager;
        private readonly IUserManager _userManager;

        public OrdersController(IOrderManager orderManager, IUserManager userManager)
        {
            _orderManager = orderManager;
            _userManager = userManager;
        }

        [Route("/Order")]
        public IActionResult Order()
        { 
            OrderModel orderModel = new OrderModel();
            //order.Orders = getAllOrders(User.Identity.Name);
            orderModel.Orders = _orderManager.GetUserOrders(User.Identity.Name).ToList();
            return View(orderModel);
        }

        [Route("/OrderAdd")]
        public IActionResult OrderAdd()
        {
            return View();
        }

        [HttpPost("/OrderAdd")]
        [Authorize]
        public IActionResult OrderAdd(Order model)
        {
            if (ModelState.IsValid)
            {
                //var user = _dataContext.FindUser(User.Identity.Name);
                var user = _userManager.Find(User.Identity.Name);
                Order order = new Order() { description = model.description, title = model.title, status = false, userId =user.Id};
                //_dataContext.Orders.Add(order);
                _orderManager.Add(order);
                //_dataContext.SaveChanges();
                return RedirectToAction("Order");

            }

            return View(model);
        }
    }
}
