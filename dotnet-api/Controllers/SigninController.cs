using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using dotnet_api.Models.Entities;
using dotnet_api.Repository.Interfaces;
using AutoMapper;
using dotnet_api.Models.Dtos;

namespace dotnet_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SigninController : ControllerBase
    {
        private readonly ICustomerRepository _repository;
        private readonly IMapper _mapper;

        public SigninController(ICustomerRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        [HttpPost()]
        public async Task<IActionResult> Post(Customer cust)
        {
            if (cust.login == null || cust.login == "") return BadRequest("Login Inválido");

            if (cust.password == null || cust.password == "") return BadRequest("Senha Inválida");

            var user = await _repository.GetCustomerByLoginPasswordAsync(cust.login, cust.password);


            return user != null
                ? Ok(user)
                : BadRequest("Login não encontrado.");

        }

    }
}
