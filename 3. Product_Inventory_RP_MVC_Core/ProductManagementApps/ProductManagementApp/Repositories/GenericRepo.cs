using Microsoft.EntityFrameworkCore.Query;
using Microsoft.EntityFrameworkCore;
using ProductManagementApp.Repositories.Interfaces;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;

namespace ProductManagementApp.Repositories
{
    public class GenericRepo<T> : IGenericRepo<T> where T : class, new()
    {
        DbContext db;
        DbSet<T> dbSet;
        public GenericRepo(DbContext db)
        {
            this.db = db;
            this.dbSet = this.db.Set<T>();
        }
        public async Task<IEnumerable<T>> GetAllAsync(Func<IQueryable<T>, IIncludableQueryable<T, object>>? includes = null)
        {
            IQueryable<T> data = this.dbSet;
            if (includes != null)
            {
                data = includes(data);
            }
            return await data.ToListAsync();
        }

        public async Task<T?> GetByIdAsync(Expression<Func<T, bool>> predicate, Func<IQueryable<T>, IIncludableQueryable<T, object>>? includes = null)
        {
            IQueryable<T> data = this.dbSet;
            if (includes != null)
            {
                data = includes(data);
            }
            return await data.FirstOrDefaultAsync(predicate);
        }

        public async Task InsertAsync(T entity)
        {
            await this.dbSet.AddAsync(entity);
        }

        public async Task UpdateAsync(T entity)
        {
            db.Entry(entity).State = EntityState.Modified;
            await Task.CompletedTask;
        }
        public async Task DeleteAsync(Expression<Func<T, bool>> predicate)
        {
            var entity = await this.dbSet.FirstOrDefaultAsync(predicate);
            if (entity != null)
            {
                dbSet.Remove(entity);
            }
        }

        public async Task<IEnumerable<K>> ExecuteSqlCollection<K>(string sql) where K : class, new()
        {
            FormattableString q = FormattableStringFactory.Create(sql);
            var data = await this.db.Set<K>()
                .FromSql(q)
                .ToListAsync();
            return data;
        }

        public async Task<K?> ExecuteSqlSingle<K>(string sql) where K : class, new()
        {
            FormattableString q = FormattableStringFactory.Create(sql);
            var data = await this.db.Set<K>()
                .FromSql(q)
                .FirstOrDefaultAsync();
            return data;
        }

        public async Task<int> ExecuteCommand(string sql)
        {
            FormattableString q = FormattableStringFactory.Create(sql);
            return await this.db.Database.ExecuteSqlAsync(q);
        }
    }
}
