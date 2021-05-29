using System;
using System.ComponentModel.DataAnnotations;
using Eventos.Application.Commands.Base;

namespace Eventos.Application.Commands.Funcionario
{
    public class InserirFuncionarioCommand : ICommand<InserirFuncionarioResponse>
    {
        [Required]
        [StringLength(50)]
        public string Nome { get; set; }
        [Required]
        [StringLength(50)]
        public string Email { get; set; }
        [Required]
        [StringLength(14)]
        public string Cpf { get; set; }
        [Required]
        public DateTime DataNascimento { get; set; }
    }
}