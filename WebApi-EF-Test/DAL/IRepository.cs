using WebApi_EF_Test.Models;

namespace WebApi_EF_Test.DAL
{
    public interface IRepository<T> where T : Employee
    {
        int Create(T entity);
        T Get(int id);
        bool Delete(int id);
        bool Update(int id, T entity);

    }
}
