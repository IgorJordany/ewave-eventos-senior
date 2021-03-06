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
        public string JobId { get; private set; }
        public ICollection<EventoFuncionario> Organizadores { get; } = new HashSet<EventoFuncionario>();
        public ICollection<Palestra> Palestras { get; } = new HashSet<Palestra>();

        public Evento(string nome, DateTime dataInicio, DateTime dataFim)
        {
            if (!IsDataValida(dataInicio, dataFim))
            {
                throw new Exception("DataInicio está maior ou igual DataFim");
            }
            else
            {
                Nome = nome;
                DataInicio = dataInicio;
                DataFim = dataFim;
            }
        }

        public void AdicionarOrganizadores(ICollection<EventoFuncionario> organizadores)
        {
            foreach (var item in organizadores)
            {
                Organizadores.Add(item);
            }
        }

        public void AdicionarJobId(string jobId)
        {
            JobId = jobId;
        }

        public void RemoverJobId()
        {
            JobId = null;
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
