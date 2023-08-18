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
    public class CustomerRepository : BaseRepository, ICustomerRepository
    {
        private readonly dotnet_apiContext _context;

        public CustomerRepository(dotnet_apiContext context) : base(context)
        {
            _context = context;
        }

        public async Task<Customer> GetCustomerByLoginPasswordAsync(string Login, string Password)
        {
            return await _context.Customer
                        .Where(x => x.login == Login && x.password == Password).FirstOrDefaultAsync(); ;
        }
    }
}
