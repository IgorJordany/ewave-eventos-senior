using System;
using System.Collections.Generic;
using Eventos.Shared.Entities;

namespace Eventos.Core.Entities
{
    public class Funcionario : Entity
    {
        public string Nome { get; }
        public string Cpf { get; }
        public DateTime DataNascimento { get; }
        public virtual ICollection<EventoFuncionario> Eventos { get; } = new HashSet<EventoFuncionario>();

        public Funcionario(string nome, string cpf, DateTime dataNascimento)
        {
            Nome = nome;
            Cpf = cpf;
            DataNascimento = dataNascimento;
        }
    }
}