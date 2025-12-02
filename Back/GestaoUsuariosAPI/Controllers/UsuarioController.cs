using System.Reflection.Metadata.Ecma335;
using GestaoUsuariosAPI;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ActionConstraints;

namespace GestaoUsuariosAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UsuariosController : ControllerBase
{

    private static List<Usuario> usuarios = new List<Usuario>();
    private static int id = 0;
    [HttpPost]
    public CreatedAtActionResult CadastrarUsuario([FromBody]Usuario usuario)
    {
        usuario.Id = id++;
        usuarios.Add(usuario);  
        return CreatedAtAction(nameof(BuscarUsuariosPorId),
         new { id = usuario.Id}, 
         usuario);
    }

    [HttpGet]
    public IEnumerable<Usuario> BuscarUsuarios([FromQuery] int skip = 0, [FromQuery] int take = 0)
    {
        return usuarios.Skip(skip).Take(take);
    }

    [HttpGet("{id}")]
    public IActionResult BuscarUsuariosPorId(int id)
    {
        var usuario = usuarios.FirstOrDefault(usuario => usuario.Id == id);
        return usuario == null ? NotFound() : Ok(usuario); 
    }

    // [HttpDelete]
    // public void DeletarUsuarios()
    // {
   
    // }
    
    [HttpDelete("{id}")]
    public void DeletarUsuarioPorId(int id)
    {
        usuarios.RemoveAll(usuario => usuario.Id == id);
    }


}   
