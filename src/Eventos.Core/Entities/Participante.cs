using Eventos.Shared.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Eventos.Core.Entities
{
    public class Participante : Entity
    {
        public Guid PalestraId { get; set; }
        public Funcionario Funcionario{ get; }
        public bool Confirmou { get; }
    }
}
