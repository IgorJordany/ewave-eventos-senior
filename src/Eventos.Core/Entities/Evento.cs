using Eventos.Shared.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Eventos.Core.Entities
{
    public class Evento : Entity
    {
        public string Nome { get; }
        public DateTime DataInicio { get; }
        public DateTime DataFim { get; }
        public ICollection<EventoFuncionario> Organizadores { get; set; } = new HashSet<EventoFuncionario>();

        public Evento(string nome, DateTime dataInicio, DateTime dataFim)
        {
            if (!IsDataValida(dataInicio, dataFim))
            {
                AddNotification(nameof(dataInicio), "DataInicio está maior ou igual DataFim");
            }
            else
            {
                Nome = nome;
                DataInicio = dataInicio;
                DataFim = dataFim;
            }
        }

        private bool IsDataValida(DateTime dataInicio, DateTime dataFim)
        {
            if (dataInicio < dataFim)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
