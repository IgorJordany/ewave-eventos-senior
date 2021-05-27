using System;
using System.Collections.Generic;

namespace Eventos.Application.Queries.CategoriaPalestra
{
    public class ObterCategoriaPalestrasResponse
    {
        public IEnumerable<CategoriaPalestrasDto> CategoriaPalestras { get; set; }
    }

    public class CategoriaPalestrasDto
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
    }
}