using entiti;
using System;
using System.Collections.Generic;
using System.Text;

namespace repository
{
    public interface IOrderRepository
    {
        Task<Order> GetOrderById(int id);
        Task<Order> CreateOrder(Order order);
    }
}
