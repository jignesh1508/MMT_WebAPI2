using ApplicationCore.Interface;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Infrastructure
{
    public class EfRepository<T> : IRepository<T> where T : class
    {
        private readonly ApplicationDbContext _dbContext;
        public EfRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<T> GetById(int id)
        {
            return await _dbContext.Set<T>().FindAsync(id);
        }

        public async Task<IEnumerable<T>> ListAll(string procedure)
        {
            return await _dbContext.Set<T>().FromSql(procedure).ToListAsync(); // using stored procedure
                                                                    // return _dbContext.Set<T>().AsEnumerable(); // using linq
        }
        public async Task<IEnumerable<T>> ListAllById(int id, string procedure)
        {
            return await _dbContext.Set<T>().FromSql(procedure + " " + id).ToListAsync(); // using stored procedure
        }

    }
}
