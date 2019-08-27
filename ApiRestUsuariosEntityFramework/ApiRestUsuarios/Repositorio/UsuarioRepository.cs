using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiRestUsuarios.Models;
using ApiRestUsuarios.Util;

namespace ApiRestUsuarios.Repositorio
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly UsuarioDbContext _contexto;
        public UsuarioRepository(UsuarioDbContext ctx)
        {
            _contexto = ctx;
        }
        public void Criar(Usuario usuario)
        {
            Criptografia cripto = new Criptografia(); 
            usuario.senha=cripto.RetornarMD5(usuario.senha);;
            _contexto.Usuarios.Add(usuario);
            _contexto.SaveChanges();
        }
        public void Atualizar(Usuario usuario)
        {
            _contexto.Usuarios.Update(usuario);
            _contexto.SaveChanges();
        }
        public List<Usuario> ListarTodos()
        {
            return _contexto.Usuarios.ToList();
        }
        public Usuario ObterPorId(int id)
        {
            return _contexto.Usuarios.SingleOrDefault(u => u.id == id);
        }
        public void Remover(int id)
        {
            var entity = _contexto.Usuarios.SingleOrDefault(u => u.id == id);
            _contexto.Usuarios.Remove(entity);
            _contexto.SaveChanges();
        }
    }
}
