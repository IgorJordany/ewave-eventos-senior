using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Eventos.Application.Commands.Base;

namespace Eventos.Application.Commands.Palestra
{
    public class InserirPalestraCommand : ICommand<InserirPalestraResponse>
    {
        [Required]
        public Guid CategoriaId { get; set; }

        [Required]
        public Guid EventoId { get; set; }

        [Required]
        [StringLength(50)]
        public string Tema { get; set; }

        [Required]
        [StringLength(50)]
        public string Local { get; set; }

        [Required]
        public DateTime DataInicio { get; set; }

        [Required]
        public float Duracao { get; set; }

        [Required]
        public Guid PalestranteId { get; set; }

        [Required]
        public List<ParticipadoresDto> Participadores { get; set; }
    }

    public class ParticipadoresDto
    {
        public Guid FuncionarioId { get; set; }
    }
}