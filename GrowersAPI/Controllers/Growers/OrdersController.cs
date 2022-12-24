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
    public class OrdersController : ControllerBase
    {
        private readonly IOrderService _OrdersService;

        public OrdersController(IOrderService OrdersService)
        {
            _OrdersService = OrdersService;
        }
        [Route("")]
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<Order>))]
        public async Task<IActionResult> Get()
        {
            try
            {
                List<Order> Orders = await _OrdersService.GetAll();
                return Ok(Orders);
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Internal Server Error");
            }

        }
        [Route("GetByGrowerId")]
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<Order>))]
        public async Task<IActionResult> GetByGrowerId(int growerId)
        {
            try
            {
                List<Order> Orders = await _OrdersService.GetAll(growerId);
                return Ok(Orders);
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Internal Server Error");
            }

        }
        [Route("GetByCustomerId")]
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<Order>))]
        public async Task<IActionResult> GetByCustomerId(int customerId)
        {
            try
            {
                List<Order> Orders = await _OrdersService.GetAllByCustomerId(customerId);
                return Ok(Orders);
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Internal Server Error");
            }

        }

        [Route("")]
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(bool))]
        public async Task<IActionResult> Add(Order entity)
        {
            try
            {
                entity.OrderNumber = new Guid();
                entity.CreatedOn = DateTime.Now;
                entity.CreatedBy = entity.CustomerId;
                var isAdded = await _OrdersService.Add(entity);
                return Ok(isAdded);
              
            }
            catch (Exception e)
            {
               
                return StatusCode(StatusCodes.Status500InternalServerError, "Internal Server Error");
            }

        }

        [Route("")]
        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(bool))]
        public async Task<IActionResult> Edit(Order entity)
        {
            try
            {
                bool isEdit = await _OrdersService.Edit(entity);
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
                bool isDelete = await _OrdersService.Remove(id);
                return Ok(isDelete);
              
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Internal Server Error");
            }

        }

    }
}
