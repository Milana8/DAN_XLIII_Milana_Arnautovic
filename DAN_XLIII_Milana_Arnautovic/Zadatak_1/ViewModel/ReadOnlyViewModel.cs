using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zadatak_1.Model;

namespace Zadatak_1.ViewModel
{
    class ReadOnlyViewModel: ViewModelBase
    {
        readonly tblEmployee employeee;

        private tblEmployee allEmployeeV;
        public tblEmployee AllEmployeeV
        {
            get
            {
                return allEmployeeV;
            }
            set
            {
                allEmployeeV = value;
                OnPropertyChanged("AllEmployeeV");
            }
        }

        private List<tblEmployee> employed;
        public List<tblEmployee> Employed
        {
            get
            {
                return employed;
            }
            set
            {
                employed = value;
                OnPropertyChanged("Employed");
            }
        }

        private tblEmployee employee;
        public tblEmployee Employee
        {
            get
            {
                return employee;
            }
            set
            {
                employee = value;
                OnPropertyChanged("Employee");
            }
        }

        public ReadOnlyViewModel(tblEmployee employeeOpen)
        {
            employeee = employeeOpen;

            Service.Service s = new Service.Service();
            employed = s.GetAllEmployee().ToList();
        }
    }
}
