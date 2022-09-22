using WebApi_EF_Test.Models;

namespace WebApi_EF_Test.DAL
{
    public class EmployeesRepository : IRepository<Employee>
    {
        private readonly DataContext dataContext;

        public EmployeesRepository(DataContext DataContext)
        {
            dataContext = DataContext;
        }

        public int Create(Employee entity)
        {
            var tmp = dataContext.Employees.Add(entity);
            try
            {
                dataContext.SaveChanges();
                return tmp.Entity.Id;
            }
            catch (Exception e)
            {
                return -1;
            }
        }

        public bool Delete(int id)
        {
            Employee employee = Get(id);
            if (employee != null)
            {
                try
                {
                    dataContext.Remove(employee);
                    dataContext.SaveChanges();
                    return true;
                }
                catch (Exception e)
                {

                }
            }
            return false;
        }

        public Employee Get(int id)
        {
            var tmp = dataContext.Employees.Find(id);
            return tmp;
        }

        public bool Update(int id, Employee employee)
        {
            employee.Id = id;
            try
            {
                dataContext.Employees.Update(employee);
                dataContext.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }
    }
}
