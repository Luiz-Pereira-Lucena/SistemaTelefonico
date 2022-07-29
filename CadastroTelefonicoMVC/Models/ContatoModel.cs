using System.ComponentModel.DataAnnotations;

namespace CadastroTelefonicoMVC.Models
{
    public class ContatoModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Não esqueça de informar o nome!")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Não esqueça de informar o e-mail!")]
        [EmailAddress(ErrorMessage = "O e-mail informado não é válido.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Não esqueça de informar o celular!")]
        [Phone(ErrorMessage = "O celular informado não é válido.")]
        public string Celular { get; set; }
    }
}