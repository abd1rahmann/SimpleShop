using DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Repositories.Orders
{
    public interface IOrderRepository
    {
        Task<IEnumerable<Order>> GetAllAsync();
        Task<Order?> GetByIdAsync(int id);
        Task<Order?> GetByIdWithItemsAsync(int id);
        Task<Order> CreateAsync(Order order);
        Task<bool> UpdateAsync(Order order);
        Task<bool> DeleteAsync(int id);
    }

}
