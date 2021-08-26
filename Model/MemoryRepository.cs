using System;
using System.Collections.Generic;
using System.Diagnostics;
using WinFormsApp_helloworld.Model;

namespace WinFormsApp_helloworld.ViewModel
{
    public class MemoryRepository : IRepository
    {
        private List<Employee> employees = new List<Employee> {
            new Employee{ Id = 1, Firstname ="Ulises", Lastname ="Ponce"}
            ,new Employee{Id = 2, Firstname ="Mario", Lastname ="Jimenez"}
            ,new Employee{Id = 3, Firstname ="Hugo", Lastname ="Ponce"}
            ,new Employee{Id = 4, Firstname ="Pedro", Lastname ="Ponce"}
            ,new Employee{Id = 5, Firstname ="Emilia", Lastname ="Ponce"}
        };
        public void Persist(Employee employee)
        {
            Debug.WriteLine($"Employee persisted {employee}");
        }

        public IEnumerable<Employee> FindEmployees()
        {
            return employees;
        }

        public void Delete(Employee it)
        {
            employees.Remove(it);
        }
    }
}