using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Eventos.Core.Entities;
using Eventos.Core.Repositories;
using Eventos.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Eventos.Infrastructure.Repositories
{
    public class FuncionarioRepository : IFuncionarioRepository
    {
        private readonly DatabaseContext _databaseContext;

        public FuncionarioRepository(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }
        public async Task Incluir(Funcionario funcionario)
        {
            await _databaseContext.Funcionarios.AddAsync(funcionario);
        }

        public Task<Funcionario> ObterFuncionarioPorId(Guid id)
        {
            return _databaseContext.Funcionarios.SingleOrDefaultAsync(c => c.Id == id);
        }

        public Task<List<Funcionario>> ObterListaFuncionarios()
        {
            return _databaseContext.Funcionarios.ToListAsync();
        }
    }
}
