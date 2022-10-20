
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
    [ApiVersion("3.0")]
    [Route("api/v{version:apiVersion}/[controller]/[Action]")]
    [ApiController]
    [TypeFilter(typeof(ExceptionManager))]
    public class DocumentosController : ControllerBase
    {
        readonly IDocumento DocumentoB;
        readonly IMapper Mapper;
        public DocumentosController(IDocumento documentoB, IMapper mapper)
        {
            DocumentoB = documentoB;
            Mapper = mapper;
        }
        // GET: api/<DocumentosController>
        [HttpGet]
        public async Task<ActionResult<List<DocumentoDto>>> Get()
        {
            var result = await DocumentoB.Get();

            if (result.Count > 0)
            {
                var resultDto = Mapper.Map<List<DocumentoDto>>(result);
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

        // POST api/<DocumentosController>
        [HttpPost]
        public async Task<ActionResult<DocumentoDto>> Post(DocumentoDto docDto)
        {
            var validator = new DocumentoValidator();
            var valid = validator.Validate(docDto);

            if (!valid.IsValid)
            { 
                List<string> strError = new List<string>();
                foreach (var item in valid.Errors)
                {
                    strError.Add(item.ErrorMessage);
                }
                    
                return NotFound(new
                {
                    Result = strError,
                    Message = "parametros faltantes : " + strError.Count,
                    State = false
                });
            }
            var doc = Mapper.Map<Documento>(docDto);
            var result = await DocumentoB.Create(doc);
            var resultDto = Mapper.Map<DocumentoDto>(result);
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

        // PUT api/<DocumentosController>/
        [HttpPut]
        public async Task<ActionResult<DocumentoDto>> Put(DocumentoDto docDto)
        {
            var validator = new DocumentoValidator();
            var valid = validator.Validate(docDto);

            if (!valid.IsValid)
            {
                List<string> strError = new List<string>();
                foreach (var item in valid.Errors)
                {
                    strError.Add(item.ErrorMessage);
                }
                return NotFound(new
                {
                    Result = strError,
                    Message = "parametros faltantes : " + strError.Count,
                    State = false
                });
            }
            var doc = Mapper.Map<Documento>(docDto);
            var result = await DocumentoB.Update(doc);
            var resultDto = Mapper.Map<DocumentoDto>(result);
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

        // DELETE api/<DocumentosController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<bool>> Delete(int id)
        {
            var result = await DocumentoB.Delete(id);
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
