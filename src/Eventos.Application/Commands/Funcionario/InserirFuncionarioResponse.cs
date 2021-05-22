using System;
using Eventos.Application.Commands.Base;

namespace Eventos.Application.Commands.Funcionario
{
    public class InserirFuncionarioResponse : ICommandResponse
    {
        public object Erro { get; set; }
        public Guid FuncionarioId { get; set; }
    }
}