using Microsoft.EntityFrameworkCore;
using ProductManagementApp.Models;

namespace ProductManagementApp.HostedServices
{
    public class ApplyMigrationService
    {
        private readonly ProductDbContext db;
        public ApplyMigrationService(ProductDbContext db)
        {
            this.db = db;
        }
        public async Task ApplyAsync()
        {
            var pendingMigrations = await db.Database.GetPendingMigrationsAsync();
            if (pendingMigrations.Any())
            {
                await db.Database.MigrateAsync();
            }
        }
    }
}
