using System;
using Eventos.Application.Commands.Base;

namespace Eventos.Application.Commands.Funcionario
{
    public class InserirEventoResponse : ICommandResponse
    {
        public object Erro { get; set; }
        public Guid EventoId { get; set; }
    }
}