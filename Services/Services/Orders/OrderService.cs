using AutoMapper;
using BusinessLogicLayer.Repositories.Orders;
using BusinessLogicLayer.Repositories.Products;
using DataAccessLayer.DTOs;
using DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Services.Orders
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _repository;
        private readonly IProductRepository _productRepo;
        private readonly IMapper _mapper;

        public OrderService(IOrderRepository repository, IProductRepository productRepo, IMapper mapper)
        {
            _repository = repository;
            _productRepo = productRepo;
            _mapper = mapper;
        }

        public async Task<OrderDto?> CreateOrderAsync(CreateOrderDto dto)
        {
            var order = new Order { CustomerName = dto.CustomerName };
            decimal total = 0;

            foreach (var item in dto.Items)
            {
                var product = await _productRepo.GetByIdAsync(item.ProductId);
                if (product == null || product.Stock < item.Quantity) return null;

                product.Stock -= item.Quantity;

                order.Items.Add(new OrderItem
                {
                    ProductId = product.Id,
                    Quantity = item.Quantity,
                    UnitPrice = product.Price
                });

                total += product.Price * item.Quantity;
            }

            order.TotalAmount = total;
            var result = await _repository.CreateAsync(order);
            return _mapper.Map<OrderDto>(result);
        }

        public async Task<IEnumerable<OrderDto>> GetAllOrdersAsync()
        {
            var orders = await _repository.GetAllAsync();
            return _mapper.Map<IEnumerable<OrderDto>>(orders);
        }

        public async Task<bool> UpdateOrderAsync(int id, UpdateOrderDto dto)
        {
            var order = await _repository.GetByIdWithItemsAsync(id);
            if (order == null) return false;

            foreach (var item in order.Items)
            {
                var product = await _productRepo.GetByIdAsync(item.ProductId);
                if (product != null) product.Stock += item.Quantity;
            }

            order.Items.Clear();
            order.CustomerName = dto.CustomerName;
            decimal total = 0;

            foreach (var item in dto.Items)
            {
                var product = await _productRepo.GetByIdAsync(item.ProductId);
                if (product == null || product.Stock < item.Quantity) return false;

                product.Stock -= item.Quantity;

                order.Items.Add(new OrderItem
                {
                    ProductId = item.ProductId,
                    Quantity = item.Quantity,
                    UnitPrice = product.Price
                });

                total += product.Price * item.Quantity;
            }

            order.TotalAmount = total;
            return await _repository.UpdateAsync(order);
        }

        public async Task<bool> DeleteOrderAsync(int id)
        {
            var order = await _repository.GetByIdWithItemsAsync(id);
            if (order == null) return false;

            foreach (var item in order.Items)
            {
                var product = await _productRepo.GetByIdAsync(item.ProductId);
                if (product != null) product.Stock += item.Quantity;
            }

            return await _repository.DeleteAsync(id);
        }
    }

}
