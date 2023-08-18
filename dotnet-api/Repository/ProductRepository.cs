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
    public class ProductRepository : BaseRepository, IProductRepository
    {
        private readonly dotnet_apiContext _context;

        public ProductRepository(dotnet_apiContext context) : base(context)
        {
            _context = context;
        }

        public async Task<IEnumerable<ProductDto>> GetProductAsync()
        {
            return await _context.Product
                .Select(x => new ProductDto { id = x.id, name = x.name, price = x.price })
                .ToListAsync();
        }
    }
}
