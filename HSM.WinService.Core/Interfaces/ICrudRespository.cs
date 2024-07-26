namespace HSM.WinService.Core.Interfaces
{
    public interface ICrudRespository<T>where T : class
    {
        Task<bool> CreateAsync(T entity);
        Task<bool> UpdateAsync(T entity);
        Task<IEnumerable<T>> GetAllAsync();
    }
}
