using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Api.Controllers.V1
{
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]/[Action]")]
    [ApiController]
  
    public class DocumentosController : ControllerBase
    {
        // GET: api/<DocumentosController>
        [HttpGet]
       
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        //[MapToApiVersion("2.0")]
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<DocumentosController>
        [HttpPost]
       // [MapToApiVersion("2.0")]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<DocumentosController>/5
        [HttpPut("{id}")]
        //[MapToApiVersion("2.0")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<DocumentosController>/5
        [HttpDelete("{id}")]
        //[MapToApiVersion("2.0")]
        public void Delete(int id)
        {
        }
    }
}
