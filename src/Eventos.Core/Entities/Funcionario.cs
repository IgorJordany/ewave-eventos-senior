using System;
using Eventos.Shared.Entities;

namespace Eventos.Core.Entities
{
    public class Funcionario : Entity
    {
        public string Nome { get; }
        public string Cpf { get; }
        public DateTime DataNascimento { get; }

        public Funcionario(string nome, string cpf, DateTime dataNascimento)
        {
            Nome = nome;
            Cpf = cpf;
            DataNascimento = dataNascimento;
        }
    }
}