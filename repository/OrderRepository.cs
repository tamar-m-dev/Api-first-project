using entiti;
using System;
using System.Collections.Generic;
using System.Text;

namespace repository
{
    public class OrderRepository : IOrderRepository
    {
        my_shopContext _context;
        public OrderRepository(my_shopContext _context)
        {
            this._context = _context;
        }
        public async Task<Order> CreateOrder(Order order)
        {
            _context.Orders.Add(order);
            await _context.SaveChangesAsync();
            return order;
        }

        public async Task<Order> GetOrderById(int id)
        {
            Order order = await _context.Orders.FindAsync(id);
            return order;
        }
    }
}
