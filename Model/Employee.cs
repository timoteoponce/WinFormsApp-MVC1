using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsApp_helloworld.Model
{
    public class Employee
    {
        public int Id { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }

        public string Fullname => $"{Firstname} {Lastname}";

        public override string ToString()
        {
            return $"[:Id {Id} :Firstname '{Firstname}' :Lastname '{Lastname}']";            
        }
    }
}
