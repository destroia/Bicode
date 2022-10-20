
using Api.ExceptionsCustomer;
using AutoMapper;
using Business.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Api.Controllers.V2
{
    [ApiVersion("2.0")]
    [Route("api/v{version:apiVersion}/[controller]/[Action]")]
    [ApiController]
    [TypeFilter(typeof(ExceptionManager))]
    public class GenerosController : ControllerBase
    {
        readonly IGenero GeneroB;
        readonly IMapper Mapper;
        public GenerosController(IGenero generoB, IMapper mapper)
        {
            GeneroB = generoB;
            Mapper = mapper;
        }
        // GET: api/<GenerosController>
        [HttpGet]
        public async Task<ActionResult<List<GeneroDto>>> Get()
        {
            var result = await GeneroB.Get();
            if (result.Count > 0)
            {
                var resultDto = Mapper.Map<List<GeneroDto>>(result);
                return Ok(new
                {
                    Result = resultDto,
                    Message = "Success",
                    State = true
                });
            }
            else
            {
                return NotFound(new
                {
                    Result = result,
                    Message = "NotFound",
                    State = false
                });
            }
        }

       

        // POST api/<GenerosController>
        [HttpPost]
        public async Task<ActionResult<GeneroDto>> Post(GeneroDto  generoDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new
                {
                    Result = ModelState,
                    Message = "parametros faltantes : " + ModelState.ErrorCount,
                    State = false
                });
            }
            var genero = Mapper.Map<Genero>(generoDto);
            var result = await GeneroB.Create(genero);
            var resultDto = Mapper.Map<GeneroDto>(result);
            if (resultDto != null)
            {
                return Ok(new
                {
                    Result = result,
                    Message = "Success",
                    State = true
                });
            }
            else
            {
                return NotFound(new
                {
                    Result = result,
                    Message = "NotFound",
                    State = false
                });
            }

        }

        // PUT api/<GenerosController>/5
        [HttpPut]
        public async Task<ActionResult<GeneroDto>> Put(GeneroDto  generoDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new
                {
                    Result = ModelState,
                    Message = "parametros faltantes : " + ModelState.ErrorCount,
                    State = false
                });
            }
            var genero = Mapper.Map<Genero>(generoDto);
            var result = await GeneroB.Update(genero);
            var resultDto = Mapper.Map<GeneroDto>(result);
            if (resultDto != null)
            {
                return Ok(new
                {
                    Result = result,
                    Message = "Success",
                    State = true
                });
            }
            else
            {
                return NotFound(new
                {
                    Result = result,
                    Message = "NotFound",
                    State = false
                });
            }
        }

        // DELETE api/<GenerosController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<bool>> Delete(int id)
        {
            bool result = await GeneroB.Delete(id);
            if (result)
            {
                return Ok(new
                {
                    Result = result,
                    Message = "Success",
                    State = result
                });
            }
            else
            {
                return NotFound(new
                {
                    Result = result,
                    Message = "NotFound",
                    State = result
                });
            }
        }
    }
}
