using RecetasLucrecia.Application.Contracts.Persistance;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecetasLucrecia.Persistance.Shared
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly IRecetasLucreciaDatabaseContext _dbContext;

        public UnitOfWork(IRecetasLucreciaDatabaseContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Dispose()
        {
            _dbContext.Dispose();
        }

        public void Save()
        {
            _dbContext.SaveChanges();
        }

        public async Task SaveAsync()
        {
            await _dbContext.SaveAsync();
        }
    }
}
