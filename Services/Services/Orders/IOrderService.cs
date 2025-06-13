using DataAccessLayer.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Services.Orders
{
    public interface IOrderService
    {
        Task<OrderDto?> CreateOrderAsync(CreateOrderDto dto);
        Task<IEnumerable<OrderDto>> GetAllOrdersAsync();
        Task<bool> UpdateOrderAsync(int id, UpdateOrderDto dto);
        Task<bool> DeleteOrderAsync(int id);
    }
}
