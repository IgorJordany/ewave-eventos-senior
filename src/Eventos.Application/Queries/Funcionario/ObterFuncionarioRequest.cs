using System;
using System.ComponentModel.DataAnnotations;
using Eventos.Application.Queries.Base;

namespace Eventos.Application.Queries.Funcionario
{
    public class ObterFuncionarioRequest : IRequest<ObterFuncionarioResponse>
    {
        [Required]
        public Guid FuncionarioId { get; set; }
    }
}