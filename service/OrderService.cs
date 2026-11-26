using entiti;
using repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace service
{
    public class OrderService : IOrderService
    {
        IOrderRepository OrderRepository;
        public OrderService(IOrderRepository OrderRepository)
        {
            this.OrderRepository = OrderRepository;
        }
        public async Task<Order> CreateOrder(Order order)
        {
            return await OrderRepository.CreateOrder(order);
        }

        public async Task<Order> GetOrderById(int id)
        {
            return await OrderRepository.GetOrderById(id);
        }
    }
}