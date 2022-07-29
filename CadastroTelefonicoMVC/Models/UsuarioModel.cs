using System.ComponentModel.DataAnnotations;
using CadastroTelefonicoMVC.Enums;

namespace CadastroTelefonicoMVC.Models
{
    public class UsuarioModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Não esqueça de informar o nome!")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Não esqueça de informar o Login!")]
        public string Login { get; set; }

        [Required(ErrorMessage = "Não esqueça de informar o e-mail!")]
        [EmailAddress(ErrorMessage = "O e-mail informado não é válido.")]
        public string Email { get; set; }

        public PerfilEnum Perfil { get; set; }

        [Required(ErrorMessage = "Não esqueça de informar a senha!")]
        public string Senha { get; set; }

        public DateTime DataCadastro { get; set; }
        
        public DateTime? DataAtualizacao { get; set; }
    }
}