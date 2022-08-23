using Notella.Data;
using Notella.Contracts;
using Microsoft.EntityFrameworkCore;

namespace Notella.Repositories
{
    public class BaseRepository<T> : IBaseRepository<T>
        where T : class
    {
        private readonly ApplicationDbContext _db;
        private readonly DbSet<T> _table;

        public BaseRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task Create(T t)
        {
            await _table.AddAsync(t);
            await _db.SaveChangesAsync();
        }

        public async Task<IEnumerable<T>> GetAll()
        {
            return await _table.ToListAsync();
        }

        public async Task<T> GetOne(object id)
        {
            return await _table.FindAsync(id);
        }

        public async Task Update(object id, object model)
        {
            var t = await GetOne(id);
            if (t != null)
            {
                _db.Entry(t).CurrentValues.SetValues(model);
                await _db.SaveChangesAsync();
            }
        }

        public async Task Delete(object id)
        {
            var t = await GetOne(id);
            if (t != null)
            {
                _table.Remove(t);
                await _db.SaveChangesAsync();
            }
        }

    }
}

