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
using AutoMapper;
using dotnet_api.Repository.Interfaces;
using dotnet_api.Models.Dtos;
using System.Globalization;

namespace dotnet_api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrdersController : ControllerBase
    {
        private readonly IOrdersRepository _repository;
        private readonly IMapper _mapper;

        public OrdersController(IOrdersRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> Post(Orders order)
        {
            if (order == null) return BadRequest("Dados Inválidos");

            order.created_at = DateTime.Now;

            var orderInsert = _mapper.Map<Orders>(order);

            _repository.Add(orderInsert);

            return await _repository.SaveChangesAsync()
                ? Ok(orderInsert)
                : BadRequest("Erro ao Salvar Ordem.");

        }
    }
}