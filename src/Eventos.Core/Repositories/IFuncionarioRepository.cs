using Eventos.Core.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Eventos.Core.Repositories
{
    public interface IFuncionarioRepository
    {
        Task Incluir(Funcionario funcionario);
        Task<List<Funcionario>> ObterListaFuncionarios();
        Task<Funcionario> ObterFuncionarioPorId(Guid id);
    }
}