using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using CadastroTelefonicoMVC.Models;
using CadastroTelefonicoMVC.Repositorio;

namespace CadastroTelefonicoMVC.Controllers
{
    //[Route("[controller]")]
    public class ContatoController : Controller
    {
        private readonly IContatoRepositorio _contatoRepositorio;
        public ContatoController(IContatoRepositorio contatoRepositorio)
        {
            _contatoRepositorio = contatoRepositorio;
        }

        public IActionResult Index()
        {
            List<ContatoModel> contatos = _contatoRepositorio.BuscarTodos();

            return View(contatos);
        }

        public IActionResult Criar()
        {
            return View();
        }

        public IActionResult Editar(int id)
        {
            ContatoModel contato = _contatoRepositorio.ListarPorId(id);
            return View(contato);
        }

        public IActionResult ExcluirConfirmacao(int id)
        {
            ContatoModel contato = _contatoRepositorio.ListarPorId(id);
            return View(contato);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult Apagar(int id)
        {
            try
            {
                bool excluido = _contatoRepositorio.Apagar(id);

                if (excluido)
                {
                    TempData["MensagemSucesso"] = "Contato excluido com sucesso";
                }
                else
                {
                    TempData["MensagemError"] = "Ops, algo deu errado ao tentar excluir o contato, tente novamente.";
                }

                return RedirectToAction("Index");
            }
            catch (System.Exception erro)
            {
                TempData["MensagemError"] = $"Ops, algo deu errado ao tentar excluir o contato, tente novamente. Detalhe do erro: {erro.Message}";
                return RedirectToAction("Index");
            }
        }

        [HttpPost]
        public IActionResult Criar(ContatoModel contato)
        {
            try
            {

                if (ModelState.IsValid)
                {
                    _contatoRepositorio.Adicionar(contato);
                    TempData["MensagemSucesso"] = "Contato cadastrado com sucesso";
                    return RedirectToAction("Index");
                }

                return View(contato);

            }
            catch (System.Exception erro)
            {
                TempData["MensagemError"] = $"Ops, algo deu errado ao cadastrar, tente novamente. Detalhe do erro:{erro.Message}";
                return RedirectToAction("Index");
            }

        }

        [HttpPost]
        public IActionResult Editar(ContatoModel contato)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _contatoRepositorio.Atualizar(contato);
                    TempData["MensagemSucesso"] = "Contato alterado com sucesso";
                    return RedirectToAction("Index");
                }

                return View(contato);
                /*
                Caso o nome da função fosse diferente do nome da View, daria um error e oderiamos corrigir:

                return View("Editar", contato);

                passando a View desejada para que retorne e o objeto;  
                */
            }
            catch (System.Exception erro)
            {
                TempData["MensagemError"] = $"Ops, algo deu errado ao tentar alterar, tente novamente. Detalhe do erro: {erro.Message}";
                return RedirectToAction("Index");
            }
        }
    }
}