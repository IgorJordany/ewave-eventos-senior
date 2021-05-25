using Eventos.Shared.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Eventos.Core.Entities
{
    public class Participante : Entity
    {
        public Guid PalestraId { get; }
        public Palestra Palestra { get; }
        public Guid FuncionarioId { get; }
        public Funcionario Funcionario{ get; }
        public bool Confirmou { get; }

        public Participante(Guid palestraId, Guid funcionarioId, bool confirmou)
        {
            PalestraId = palestraId;
            FuncionarioId = funcionarioId;
            Confirmou = confirmou;
        }
    }
}
