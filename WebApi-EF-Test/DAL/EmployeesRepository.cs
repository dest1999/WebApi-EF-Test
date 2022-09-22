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
            try
            {
                var tmp = dataContext.Employees.Add(entity);
                dataContext.SaveChanges();
                return tmp.Entity.Id;
            }
            catch (Exception)
            {
                return -1;
            }
        }

        public bool Delete(int id)
        {
            Employee employee = Get(id);
            if (employee == null)
            {
                return false;
            }
            dataContext.Remove(employee);
            dataContext.SaveChanges();
            return true;
        }

        public Employee Get(int id)
        {
            var tmp = dataContext.Employees.Find(id);
            return tmp;
        }

        public bool Update(Employee entity)
        {
            throw new NotImplementedException();
        }
    }
}
