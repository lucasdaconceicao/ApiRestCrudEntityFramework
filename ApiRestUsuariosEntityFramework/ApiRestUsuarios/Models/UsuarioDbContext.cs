using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace ApiRestUsuarios.Models
{
    public class UsuarioDbContext : DbContext
    {
        public UsuarioDbContext(DbContextOptions<UsuarioDbContext> options)
            : base(options)
        {
        }
        public DbSet<Usuario> Usuarios { get; set; }
    }
}
