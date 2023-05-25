using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Business_Logic_Layer.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace API_UL_Layer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductenController : ControllerBase
    {

        private readonly RapairBLL _RapairBLL;

        public ProductenController()
        {
            _RapairBLL = new RapairBLL();
        }

        [HttpPost]
        public async Task<ActionResult<RapairModel>> addProduct([FromBody] RapairModel product)
        {
            //if (product == null)
            //{
            //    return BadRequest();
            //}

            RapairModel result = await _RapairBLL.AddProduct(product);


            return result;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<RapairModel>>> GetProducts()
        {
            var products = await _RapairBLL.GetProducts();
            return Ok(products);
        }

        [HttpGet("{_id:guid}")]
        public async Task<ActionResult<RapairModel>> GetProductById(Guid _id)
        {
            var product = await _RapairBLL.GetProductById(_id);

            if (product == null)
            {
                return NotFound();
            } 

            return Ok(product);
        }

        [HttpPut("{_id:guid}")]
        public async Task<ActionResult<RapairModel>> UpdateProduct(Guid _id, [FromBody] RapairModel product)
        {
            //if (product == null || _id != product._id)
            //{
            //    return BadRequest();
            //}

            var updatedProduct = await _RapairBLL.UpdateProduct(_id, product);

            if (updatedProduct == null)
            {
                return NotFound();
            }
             
            return Ok(updatedProduct);
        }


        [HttpPut("status/{_id:guid}")]
        public async Task<ActionResult> UpdateStatus(Guid _id, [FromBody] string status)
        {

            var updatedProduct = await _RapairBLL.UpdateStatus(_id, status);
            if (updatedProduct == null)
            {
                return NotFound();
            }
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteProduct(Guid id)
        {
            var deletedProduct = await _RapairBLL.DeleteProduct(id);

            if (deletedProduct == null)
            {
                return NotFound();
            }

            return NoContent();
        }


    }
}