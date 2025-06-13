using DataAccessLayer.DBContext;
using DataAccessLayer.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Repositories.Orders
{
    public class OrderRepository : IOrderRepository
    {
        private readonly SimpleShopDbContext _context;

        public OrderRepository(SimpleShopDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Order>> GetAllAsync() =>
            await _context.Orders.ToListAsync();

        public async Task<Order?> GetByIdAsync(int id) =>
            await _context.Orders.FindAsync(id);

        public async Task<Order?> GetByIdWithItemsAsync(int id) =>
            await _context.Orders.Include(o => o.Items).FirstOrDefaultAsync(o => o.Id == id);

        public async Task<Order> CreateAsync(Order order)
        {
            _context.Orders.Add(order);
            await _context.SaveChangesAsync();
            return order;
        }

        public async Task<bool> UpdateAsync(Order order)
        {
            _context.Orders.Update(order);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var order = await _context.Orders.Include(o => o.Items).FirstOrDefaultAsync(o => o.Id == id);
            if (order == null) return false;

            _context.Orders.Remove(order);
            return await _context.SaveChangesAsync() > 0;
        }
    }

}
