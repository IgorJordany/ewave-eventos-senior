using System;
using System.Collections.Generic;
using System.Linq;
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

        public async Task<bool> ExisteFuncionarioPorId(Guid id)
        {
            return await _databaseContext.Funcionarios.AnyAsync(f => f.Id == id);
        }

        public bool ExisteFuncionariosPorIds(List<Guid> ids)
        {
            var existe = true;

            foreach (var item in ids)
            {
                existe = existe && _databaseContext.Funcionarios.AnyAsync(c => c.Id == item).Result;
            }
            
            return existe;
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
