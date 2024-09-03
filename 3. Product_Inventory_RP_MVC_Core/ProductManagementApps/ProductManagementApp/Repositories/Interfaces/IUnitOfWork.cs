namespace ProductManagementApp.Repositories.Interfaces
{
    public interface IUnitOfWork
    {
        IGenericRepo<T> GetRepo<T>() where T : class, new();
        Task<bool> SaveAsync();
    }
}
