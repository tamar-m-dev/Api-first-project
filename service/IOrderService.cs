using entiti;
using System;
using System.Collections.Generic;
using System.Text;

namespace service
{
    public interface IOrderService
    {
        Task<Order> GetOrderById(int id);
        Task<Order> CreateOrder(Order order);
    }
}
