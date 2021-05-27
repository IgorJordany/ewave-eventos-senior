using System;
using System.Threading.Tasks;
using Eventos.Application.Queries.CategoriaPalestra;
using Microsoft.AspNetCore.Mvc;

namespace Eventos.Api.Controllers.Queries
{
    [ApiController]
    [Route("queries/categoria-palestras")]
    public class CategoriaPalestraController : ControllerBase
    {
        private readonly ObterCategoriaPalestrasHandler _obterCategoriaPalestrasHandler;

        public CategoriaPalestraController(
            ObterCategoriaPalestrasHandler obterCategoriaPalestrasHandler)
        {
            _obterCategoriaPalestrasHandler = obterCategoriaPalestrasHandler;
        }

        [HttpGet("")]
        public async Task<ObterCategoriaPalestrasResponse> ObterCategoriaPalestras()
        {
            var response = await _obterCategoriaPalestrasHandler.Handle(new ObterCategoriaPalestrasRequest());
            return response;
        }
    }
}