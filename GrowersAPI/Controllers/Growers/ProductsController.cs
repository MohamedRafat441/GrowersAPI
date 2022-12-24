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
    public class ProductsController : ControllerBase
    {
        private readonly IProductsService _ProductsService;

        public ProductsController(IProductsService ProductsService)
        {
            _ProductsService = ProductsService;
        }
        [Route("")]
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<Product>))]
        public async Task<IActionResult> Get()
        {
            try
            {
                List<Product> products = await _ProductsService.GetAll();
                return Ok(products);
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Internal Server Error");
            }

        }
        [Route("GetByGrowerId")]
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<Product>))]
        public async Task<IActionResult> Get(int growerId)
        {
            try
            {
                List<Product> products = await _ProductsService.GetAll(growerId);
                return Ok(products);
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Internal Server Error");
            }

        }

        [Route("")]
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(bool))]
        public async Task<IActionResult> Add(Product entity)
        {
            try
            {
                entity.CategoryId = 1;
                bool isAdded = await _ProductsService.Add(entity);
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
        public async Task<IActionResult> Edit(Product entity)
        {
            try
            {
                bool isEdit = await _ProductsService.Edit(entity);
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
                bool isDelete = await _ProductsService.Remove(id);
                return Ok(isDelete);
              
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Internal Server Error");
            }

        }

    }
}
