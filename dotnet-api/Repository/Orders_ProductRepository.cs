using dotnet_api.Context;
using dotnet_api.Models.Dtos;
using dotnet_api.Models.Entities;
using dotnet_api.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace dotnet_api.Repository
{
    public class Order_ProductRepository : BaseRepository, IOrder_ProductRepository
    {
        private readonly dotnet_apiContext _context;

        public Order_ProductRepository(dotnet_apiContext context) : base(context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Order_Product>> GetOrder_ProductAsync()
        {
            return await _context.Order_Product
                .Select(x => new Order_Product { orderID = x.orderID, productID = x.productID })
                .ToListAsync();
        }
    }
}
