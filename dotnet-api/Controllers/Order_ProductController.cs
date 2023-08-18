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

namespace dotnet_api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class Order_ProductController : ControllerBase
    {
        private readonly IOrder_ProductRepository _repository;
        private readonly IMapper _mapper;

        public Order_ProductController(IOrder_ProductRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> Post(Order_Product[] order_product)
        {
            if (order_product == null) return BadRequest("Dados Inválidos");
            foreach (Order_Product ord in order_product)
            {
                ord.created_at = DateTime.Now;
                var orderProdInsert = _mapper.Map<Order_Product>(ord);
                _repository.Add(orderProdInsert);
                return await _repository.SaveChangesAsync()
                           ? Ok("Sucesso ao Salvar Ordem Product.")
                           : BadRequest("Erro ao Salvar Ordem Product.");
            }

            return await _repository.SaveChangesAsync()
                          ? Ok("Sucesso ao Salvar Ordem Product.")
                          : BadRequest("Erro ao Salvar Ordem Product.");


        }
    }
}