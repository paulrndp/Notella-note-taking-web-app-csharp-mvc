namespace Notella.Contracts
{
    public interface IBaseRepository<T>
    {
        //"T" is a generic type.

        Task Create(T t);
        Task<T> GetOne(object id);
        Task<IEnumerable<T>> GetAll();
        Task Update(object id, object model);
        Task Delete(object id);

    }
}
