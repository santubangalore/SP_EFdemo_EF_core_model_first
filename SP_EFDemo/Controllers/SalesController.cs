using Microsoft.AspNetCore.Mvc;
using SP_EFDemo.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SP_EFDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SalesController : ControllerBase
    {
        // GET: api/<SalesController>
        [HttpGet("GetSalesList")]
        public async Task<ActionResult> Get()
        {
            return Ok();
        }


        // GET api/<SalesController>/5
        [HttpGet("{id}")]
        public string Get(int salesid)
        {
            return "value";
        }

        // POST api/<SalesController>
        [HttpPost("AddSaleRecord")]
        public void Post([FromBody] Sales sales)
        {

        }

        // PUT api/<SalesController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Sales sales)
        {
        }

        // DELETE api/<SalesController>/5
        [HttpDelete("{id}")]
        public void Delete(int salesId)
        {

        }
    }
}
