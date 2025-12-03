using System.Reflection.Metadata.Ecma335;
using GestaoUsuariosAPI;
using GestaoUsuariosAPI.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ActionConstraints;

namespace GestaoUsuariosAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UsuariosController : ControllerBase
{
    private UsuarioContext _context;

    public UsuariosController(UsuarioContext context)
    {
        _context = context;
    }

    [HttpPost]
    public CreatedAtActionResult CadastrarUsuario([FromBody]Usuario usuario)
    {

        _context.Add(usuario);
        _context.SaveChanges(); 
        return CreatedAtAction(nameof(BuscarUsuariosPorId),
         new { id = usuario.Id}, 
         usuario);
    }

    [HttpGet]
    public IEnumerable<Usuario> BuscarUsuarios([FromQuery] int skip = 0, [FromQuery] int take = 0)
    {
        return _context.Usuarios.Skip(skip).Take(take);
    }

    [HttpGet("{id}")]
    public IActionResult BuscarUsuariosPorId(int id)
    {
        var usuario = _context.Usuarios.FirstOrDefault
        (usuario => usuario.Id == id);

        return usuario == null ? NotFound() : Ok(usuario); 
    }

    // [HttpDelete]
    // public void DeletarUsuarios()
    // {
   
    // }
    
    // [HttpDelete("{id}")]
    // public void DeletarUsuarioPorId(int id)
    // {
    //     _context.Remove();
    // }


}   
