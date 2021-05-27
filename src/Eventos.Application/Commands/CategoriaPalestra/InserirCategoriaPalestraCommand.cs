using System.ComponentModel.DataAnnotations;
using Eventos.Application.Commands.Base;

namespace Eventos.Application.Commands.CategoriaPalestra
{
    public class InserirCategoriaPalestraCommand : ICommand<InserirCategoriaPalestraResponse>
    {
        [Required]
        [StringLength(50)]
        public string Nome { get; set; }
    }
}