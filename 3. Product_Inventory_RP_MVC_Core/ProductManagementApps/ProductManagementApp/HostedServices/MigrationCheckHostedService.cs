namespace ProductManagementApp.HostedServices
{
    public class MigrationCheckHostedService : IHostedService
    {
        private readonly IServiceProvider serviceProvider;
        public MigrationCheckHostedService(IServiceProvider serviceProvider)
        {
            this.serviceProvider = serviceProvider;
        }
        public async Task StartAsync(CancellationToken cancellationToken)
        {
            using (var scope = serviceProvider.CreateScope())
            {

                var service = scope.ServiceProvider.GetRequiredService<ApplyMigrationService>();
                if (service == null) { }
                else
                {
                    await service.ApplyAsync();
                }


            }
        }

        public async Task StopAsync(CancellationToken cancellationToken)
        {
            await Task.CompletedTask;
        }
    }
}
