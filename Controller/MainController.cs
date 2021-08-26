using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WinFormsApp_helloworld.Model;
using WinFormsApp_helloworld.ViewModel;

namespace WinFormsApp_helloworld.Controller
{
    public class MainController
    {
        private readonly IRepository repository;
        public List<Employee> List { get; } = new();
        public Employee Selected { get; set; }

        public MainController(IRepository _repository)
        {
            this.repository = _repository;
        }

        public void Load()
        {
            List.Clear();
            foreach (var it in repository.FindEmployees())
                List.Add(it);
        }

        public void Delete()
        {
            if (HasSelected())
            {
                repository.Delete(Selected);
                ClearSelected();
                Load();
            }
        }

        public void Persist()
        {
            if (HasSelected())
                repository.Persist(Selected);
        }

        public void ClearSelected()
        {
            Selected = null;
        }

        public bool HasSelected()
        {
            return Selected != null;
        }
    }
}
