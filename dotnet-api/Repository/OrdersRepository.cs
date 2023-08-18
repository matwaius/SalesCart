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
    public class OrdersRepository : BaseRepository, IOrdersRepository
    {
        private readonly dotnet_apiContext _context;

        public OrdersRepository(dotnet_apiContext context) : base(context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Orders>> GetOrdersAsync()
        {
            return await _context.Orders
                .Select(x => new Orders { id = x.id, customerID = x.customerID, total_order = x.total_order, created_at = x.created_at, comments = x.comments })
                .ToListAsync();
        }
    }
}
