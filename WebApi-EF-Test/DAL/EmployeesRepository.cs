using WebApi_EF_Test.Models;

namespace WebApi_EF_Test.DAL
{
    public class EmployeesRepository : IRepository<Employee>
    {
        private readonly DataContext dataContext;

        public EmployeesRepository(DataContext DataContext)
        {
            //TODO добавить логирование если будет время
            dataContext = DataContext;
        }

        public int Create(Employee entity)
        {
            var tmp = dataContext.Employees.Add(entity);
            dataContext.SaveChanges();
            return tmp.Entity.Id;
        }

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Employee Get(int id)
        {
            throw new NotImplementedException();
        }

        public bool Update(Employee entity)
        {
            throw new NotImplementedException();
        }
    }
}
