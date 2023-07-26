using Microsoft.EntityFrameworkCore;
using DotNetAuthApp.Core.Repositories.Command.Base;
using DotNetAuthApp.Infrastructure.Data;
using System.Threading.Tasks;

namespace DotNetAuthApp.Infrastructure.Repository.Command.Base
{
    public class CommandRepository<T> : ICommandRepository<T> where T : class
    {
        protected readonly DotNetAuthAppContext _context;

        public CommandRepository(DotNetAuthAppContext context)
        {
            _context = context;
        }
        public async Task<T> AddAsync(T entity)
        {
            await _context.Set<T>().AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task UpdateAsync(T entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(T entity)
        {
            _context.Set<T>().Remove(entity);
            await _context.SaveChangesAsync();
        }
    }
}
