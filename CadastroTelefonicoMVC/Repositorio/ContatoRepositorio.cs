using CadastroTelefonicoMVC.Data;
using CadastroTelefonicoMVC.Models;

namespace CadastroTelefonicoMVC.Repositorio
{
    public class ContatoRepositorio : IContatoRepositorio
    {
        private readonly ContextDb _contextDb;

        public ContatoRepositorio(ContextDb contextDb)
        {
            _contextDb = contextDb;
        }

        public ContatoModel ListarPorId(int id)
        {
            return _contextDb.Contatos.FirstOrDefault(x => x.Id == id);
        }

        public List<ContatoModel> BuscarTodos()
        {
            return _contextDb.Contatos.ToList();
        }

        public ContatoModel Adicionar(ContatoModel contato)
        {
            _contextDb.Contatos.Add(contato);
            _contextDb.SaveChanges();
            return contato;
        }

        public ContatoModel Atualizar(ContatoModel contato)
        {
            ContatoModel contatoDb = ListarPorId(contato.Id);

            if (contatoDb == null) throw new System.Exception("Houve um erro na atualização do contato");

            contatoDb.Nome = contato.Nome;
            contatoDb.Email = contato.Email;
            contatoDb.Celular = contato.Celular;

            _contextDb.Contatos.Update(contatoDb);
            _contextDb.SaveChanges();
            return contatoDb;
        }

        public bool Apagar(int id)
        {
            ContatoModel contatoDb = ListarPorId(id);

            if (contatoDb == null) throw new System.Exception("Houve um erro ao apagar o contato");

            _contextDb.Contatos.Remove(contatoDb);
            _contextDb.SaveChanges();
            return true;
        }
    }
}