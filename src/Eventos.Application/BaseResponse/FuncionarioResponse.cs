using System;

namespace Eventos.Application.BaseResponse
{
    public class FuncionarioResponse
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }

        public string Cpf { get; set; }
        public DateTime DataNascimento { get; set; }
    }
}