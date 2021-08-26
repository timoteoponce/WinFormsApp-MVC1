using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WinFormsApp_helloworld.Controller;
using WinFormsApp_helloworld.Model;
using WinFormsApp_helloworld.ViewModel;

namespace WinFormsApp_helloworld
{
    public partial class MainForm : Form
    {
        private readonly MainController mainController;
        public MainForm()
        {
            InitializeComponent();
            mainController = new MainController(new MemoryRepository());
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            mainController.Load();
            setupEmployeeList();
        }

        private void setupEmployeeList()
        {
            lsbEmployees.Items.Clear();
            foreach (var it in mainController.List) {
                lsbEmployees.Items.Add(it);
            }            
            lsbEmployees.DisplayMember = "Fullname";
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (mainController.HasSelected())
            {                
                mainController.Delete();
                setupEmployeeList();
                setupFields();
            }
        }

        private void btnSave_Click_1(object sender, EventArgs e)
        {
            if (mainController.HasSelected())
            {
                mainController.Persist();
            }
        }

        private void lsbEmployees_ValueChanged(object sender, EventArgs e)
        {
            Debug.WriteLine($"Selected from list {lsbEmployees.SelectedItem}");
            mainController.ClearSelected();
            mainController.Selected = (Employee) lsbEmployees.SelectedItem;
            if (mainController.HasSelected()) {
                setupFields();            
            }
        }

        private void setupFields()
        {
            if (mainController.Selected is Employee it)
            {
                txtFirstname.Text = it.Firstname;
                txtLastname.Text = it.Lastname;
            }
            else {
                txtFirstname.Text = "";
                txtLastname.Text = "";
            }
        }
    }
}
