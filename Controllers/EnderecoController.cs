using ApiBuscaCepV2.Context;
using ApiBuscaCepV2.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ApiBuscaCepV2.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EnderecoController : ControllerBase
    {
        private readonly AppDbContext _context;
        
        public EnderecoController(AppDbContext context)
        {
            _context = context;
        }
        
        [HttpGet]
        public ActionResult<IEnumerable<Endereco>> Get()
        {
            try
            {
                var enderecos = _context.Enderecos!.AsNoTracking().ToList();
                if (enderecos is null)
                {
                    return NotFound();
                }
                return enderecos;
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
        
        [HttpGet("{id:int}",Name ="ObterEndereco")]
        public ActionResult<Endereco> GetById(int id)
        {
            try
            {
                var endereco = _context.Enderecos!.FirstOrDefault(e => e.EnderecoId == id);
                if (endereco is null)
                {
                    return NotFound();
                }
                return endereco;
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpGet("usuarioenderecos/{id:int}")]
        public ActionResult<IEnumerable<Endereco>> GetUsuarioEnderecosSalvos(int id)
        {
            try
            {
                var endereco = _context.Enderecos!.Where(e => e.UsuarioId == id).AsNoTracking().ToList();
                if (endereco is null)
                {
                    return NotFound();
                }
                return endereco;
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        
        [HttpPost]
        public ActionResult Post(Endereco endereco)
        {
            try
            {
                if (endereco is null)
                {
                    return BadRequest();
                }
                _context.Enderecos!.Add(endereco);
                _context.SaveChanges();
                return new CreatedAtRouteResult("ObterEndereco", new { id = endereco.EnderecoId }, endereco);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
        
        [HttpPut("{id:int}")]
        public ActionResult Put(int id, Endereco endereco)
        {
            try
            {
                if (id != endereco.EnderecoId)
                {
                    return BadRequest();
                }
                _context.Entry(endereco).State = EntityState.Modified;
                _context.SaveChanges();
                return Ok(endereco);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
        
        [HttpDelete("{id:int}")]
        public ActionResult Delete(int id)
        {
            try
            {
                var endereco = _context.Enderecos!.FirstOrDefault(e => e.EnderecoId == id);
                if (endereco is null)
                {
                    return NotFound();
                }
                _context.Enderecos!.Remove(endereco);
                _context.SaveChanges();
                return Ok(endereco);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
    }
}