
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
    public class PersonasController : ControllerBase
    {
        readonly IPersona PersonaB;
        readonly IMapper Mapper;
        public PersonasController(IPersona personaB, IMapper mapper)
        {
            PersonaB = personaB;
            Mapper = mapper;
        }
        // GET: api/<PersonasController>
        [HttpGet]
        public async Task<ActionResult<List<PersonaDto>>> Get()
        {
            var result = await PersonaB.Get();
            
            if (result.Count > 0)
            {
                var resultDto = Mapper.Map<List<PersonaDto>>(result);
                resultDto.ForEach(x => x.Clasificacion = PersonaB.GetClasificacion(x.FechaNacimiento));
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

        // GET api/<PersonasController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PersonaDto>> Get(int id)
        {
            var result = await PersonaB.GetById(id);

            if (result != null)
            {
                var resultDto = Mapper.Map<PersonaDto>(result);
                resultDto.Clasificacion = PersonaB.GetClasificacion(resultDto.FechaNacimiento);
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

        // POST api/<PersonasController>
        [HttpPost]
        public async Task<ActionResult<PersonaDto>> Post(PersonaDto  personaDto)
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
            var persona = Mapper.Map<Persona>(personaDto);
            var result = await PersonaB.Create(persona);

            if (result != null)
            {
                var resultDto = Mapper.Map<PersonaDto>(result);
                resultDto.Clasificacion = PersonaB.GetClasificacion(resultDto.FechaNacimiento);
                return Ok(new
                {
                    Result = resultDto,
                    Message = "Success",
                    State = true
                });
            }
            else
            {
                return BadRequest(new
                {
                    Result = result,
                    Message = "NotFound",
                    State = false
                });
            }
        }

        // PUT api/<PersonasController>/5
        [HttpPut]
        public async Task<ActionResult<PersonaDto>> Put(PersonaDto personaDto)
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
            var persona = Mapper.Map<Persona>(personaDto);
            var result = await PersonaB.Update(persona);

            if (result != null)
            {
                var resultDto = Mapper.Map<PersonaDto>(result);
                resultDto.Clasificacion = PersonaB.GetClasificacion(resultDto.FechaNacimiento);
                return Ok(new
                {
                    Result = resultDto,
                    Message = "Success",
                    State = true
                });
            }
            else
            {
                return BadRequest(new
                {
                    Result = result,
                    Message = "NotFound",
                    State = false
                });
            }
        }

        // DELETE api/<PersonasController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<bool>> Delete(int id)
        {
            bool result = await PersonaB.Delete(id);

            if (result )
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
