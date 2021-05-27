using System;
using System.Threading.Tasks;
using Eventos.Application.Queries.Palestra;
using Microsoft.AspNetCore.Mvc;

namespace Eventos.Api.Controllers.Queries
{
    [ApiController]
    [Route("queries/palestras")]
    public class PalestraController : ControllerBase
    {
        private readonly ObterPalestrasHandler _obterPalestrasHandler;
        private readonly ObterPalestraHandler _obterPalestraHandler;

        public PalestraController(ObterPalestrasHandler obterPalestrasHandler,
            ObterPalestraHandler obterPalestraHandler)
        {
            _obterPalestrasHandler = obterPalestrasHandler;
            _obterPalestraHandler = obterPalestraHandler;
        }

        [HttpGet("")]
        public async Task<ObterPalestrasResponse> ObterPalestras()
        {
            var response = await _obterPalestrasHandler.Handle(new ObterPalestrasRequest());
            return response;
        }

        [HttpGet("{palestraId}")]
        public async Task<ObterPalestraResponse> ObterPalestra([FromRoute] Guid palestraId)
        {
            var response = await _obterPalestraHandler.Handle(new ObterPalestraRequest());
            return response;
        }
    }
}