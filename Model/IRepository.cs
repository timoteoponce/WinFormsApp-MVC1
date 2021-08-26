using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsApp_helloworld.Model
{
    /// <summary>
    /// Interface defining the different operations of a data repository, specific implementations have to implement this interface
    /// </summary>
    public interface IRepository
    {
        public void Persist(Employee employee);

        public IEnumerable<Employee> FindEmployees();

        public void Delete(Employee it);
    }
}
