using ApiBuscaCepV2.Context;
using ApiBuscaCepV2.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ApiBuscaCepV2.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsuarioController : ControllerBase
    {
        private readonly AppDbContext _context;
        public UsuarioController(AppDbContext context)
        {
            _context = context;
        }
        [HttpGet]
        public ActionResult<IEnumerable<Usuario>> Get()
        {
            try
            {
                return _context.Usuario!.AsNoTracking().ToList();
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
        
        [HttpGet("{id:int}", Name = "ObterUsuario")]
        public ActionResult<Usuario> Get(int id)
        {
            try
            {
                var endereco = _context.Usuario!.FirstOrDefault(u => u.UsuarioId == id);
                if (endereco == null)
                {
                    return NotFound();
                }
                return Ok(endereco);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpPost]
        public ActionResult Post(Usuario usuario)
        {
            try
            {
                if (usuario is null)
                {
                    return BadRequest();
                }
                _context.Usuario!.Add(usuario);
                _context.SaveChanges();
                return new CreatedAtRouteResult("ObterUsuario", new { id = usuario.UsuarioId }, usuario);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
        
        [HttpPut("{id:int}")]
        public ActionResult Put(int id, Usuario usuario)
        {
            try
            {
                if (id != usuario.UsuarioId)
                {
                    return BadRequest();
                }
                _context.Entry(usuario).State = EntityState.Modified;
                _context.SaveChanges();
                return Ok(usuario);
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
        
        [HttpDelete("{id:int}")]
        public ActionResult<Usuario> Delete(int id)
        {
            try
            {
                var usuario = _context.Usuario!.FirstOrDefault(u => u.UsuarioId == id);
                if (usuario is null)
                {
                    return NotFound();
                }
                _context.Usuario!.Remove(usuario);
                _context.SaveChanges();
                return Ok(usuario);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
    }
}