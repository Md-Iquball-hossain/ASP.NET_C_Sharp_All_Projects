using ProductManagementApp.Models;
using ProductManagementApp.Repositories.Interfaces;

namespace ProductManagementApp.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ProductDbContext db;
        public UnitOfWork(ProductDbContext db)
        {
            this.db = db;
        }
        public IGenericRepo<T> GetRepo<T>() where T : class, new()
        {
            return new GenericRepo<T>(db);
        }

        public async Task<bool> SaveAsync()
        {
            int rowsEffected = await db.SaveChangesAsync();
            return rowsEffected > 0;
        }
    }
}
