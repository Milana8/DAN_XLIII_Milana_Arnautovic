using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zadatak_1.Model;
using Zadatak_1.View;

namespace Zadatak_1.ViewModel
{
    class ReadOnlyViewModel: ViewModelBase
    {
        readonly ReadOnlyView employeee;

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
        private ReadOnlyView readOnlyView;

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

        public ReadOnlyViewModel(ReadOnlyView employeeOpen)
        {
            employeee = employeeOpen;

            Service.Service s = new Service.Service();
            employed = s.GetAllEmployee().ToList();
        }

       
    }
}
