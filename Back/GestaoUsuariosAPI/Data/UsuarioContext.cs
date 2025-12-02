using Microsoft.EntityFrameworkCore;

namespace GestaoUsuariosAPI.Data
{
    class UsuarioContext : DbContext
    {
        public UsuarioContext(DbContextOptions<UsuarioContext> opts) 
        : base(opts)
        {
            
        }

        public DbSet<Usuario> Usuarios { get; set; }
    }
}