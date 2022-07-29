using CadastroTelefonicoMVC.Data;
using CadastroTelefonicoMVC.Models;

namespace CadastroTelefonicoMVC.Repositorio
{
    public class UsuarioRepositorio : IUsuarioRepositorio
    {
        private readonly ContextDb _contextDb;
        public UsuarioRepositorio(ContextDb contextDb)
        {
            _contextDb = contextDb;
        }

        public UsuarioModel Adicionar(UsuarioModel usuario)
        {
            usuario.DataCadastro = DateTime.Now;
            usuario.DataAtualizacao = DateTime.Now;
            _contextDb.Usuarios.Add(usuario);
            _contextDb.SaveChanges();
            return usuario;
        }

        public bool Apagar(int id)
        {
            UsuarioModel usuarioDb = ListarPorId(id);

            if (usuarioDb == null) throw new System.Exception("Houve um erro ao tentar apagar o contanto");

            _contextDb.Usuarios.Remove(usuarioDb);
            _contextDb.SaveChanges();
            return true;
        }

        public UsuarioModel Atualizar(UsuarioModel usuario)
        {
            UsuarioModel usuarioDb = ListarPorId(usuario.Id);

            if (usuarioDb == null) throw new System.Exception("Houve um erro na atualização do usuario");

            usuarioDb.Nome = usuario.Nome;
            usuarioDb.Login = usuario.Login;
            usuarioDb.Email = usuario.Email;
            usuarioDb.Perfil = usuario.Perfil;
            //Data de atualização é a data atual (no momento da atualização);
            usuarioDb.DataAtualizacao = DateTime.Now;

            _contextDb.Usuarios.Update(usuarioDb);
            _contextDb.SaveChanges();
            return usuarioDb;
        }

        public List<UsuarioModel> BuscarTodos()
        {
            return _contextDb.Usuarios.ToList();
        }

        public UsuarioModel ListarPorId(int id)
        {
            return _contextDb.Usuarios.FirstOrDefault(x => x.Id == id);
        }
    }
}