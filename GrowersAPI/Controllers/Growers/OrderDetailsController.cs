using GrowersAPI.Models;
using GrowersDomain.Models.Growers;
using GrowersServices.Interfaces.Growers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GrowersAPI.Controllers.Growers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderDetailsController : ControllerBase
    {
        private readonly IOrderDetailsService _OrderDetailsService;
        private readonly IOrderService _OrderService;
        public OrderDetailsController(IOrderDetailsService OrderDetailsService, IOrderService OrderService)
        {
            _OrderDetailsService = OrderDetailsService;
            _OrderService = OrderService;
        }
        [Route("")]
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<OrderDetails>))]
        public async Task<IActionResult> Get()
        {
            try
            {
                List<OrderDetails> OrderDetails = await _OrderDetailsService.GetAll();
                return Ok(OrderDetails);
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Internal Server Error");
            }

        }

        [Route("")]
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(bool))]
        public async Task<IActionResult> Add(OrderDetails entity)
        {
            try
            {
               
                bool isAdded = await _OrderDetailsService.Add(entity);
                return Ok(isAdded);
              
            }
            catch (Exception e)
            {
               
                return StatusCode(StatusCodes.Status500InternalServerError, "Internal Server Error");
            }

        }
        [Route("AddOrderDetails")]
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(bool))]
        public async Task<IActionResult> Add(OrderModel entity)
        {
            try
            {
                Order order = new Order()
                {
                    GrowerId = entity.GrowerId,
                    CustomerId=entity.CustomerId,
                    OrderNumber= Guid.NewGuid(),
                    TotalAmount=entity.TotalAmount
            };
               var orderObj=await _OrderService.Add(order);
            
                foreach (var orderDetail in entity.OrderDetails)
                {
                    orderDetail.OrderId = orderObj.Id;
                    await _OrderDetailsService.Add(orderDetail);
                }
                
                return Ok(true);

            }
            catch (Exception e)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "Internal Server Error");
            }

        }

        [Route("")]
        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(bool))]
        public async Task<IActionResult> Edit(OrderDetails entity)
        {
            try
            {
                bool isEdit = await _OrderDetailsService.Edit(entity);
                return Ok(isEdit);
            }
            catch (Exception e)
            {
                
                return StatusCode(StatusCodes.Status500InternalServerError, "Internal Server Error");
            }

        }

        [Route("Delete")]
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(bool))]
        public async Task<IActionResult> Delete([FromQuery] int id)
        {
            try
            {
                bool isDelete = await _OrderDetailsService.Remove(id);
                return Ok(isDelete);
              
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Internal Server Error");
            }

        }

    }
}
