using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using Zadatak_1.Command;
using Zadatak_1.Model;
using Zadatak_1.View;

namespace Zadatak_1.ViewModel
{
    class AddEmployeeViewModel : ViewModelBase
    {
        readonly AddEmployeeView addEmployee;


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




        private bool isUpdateEmployee;
        public bool IsUpdateEmployee
        {
            get
            {
                return isUpdateEmployee;
            }
            set
            {
                isUpdateEmployee = value;
            }
        }

        private List<tblEmployee> allEmployeeList;
        public List<tblEmployee> AllEmplyeeList
        {
            get
            {
                return allEmployeeList;
            }
            set
            {
                allEmployeeList = value;
                OnPropertyChanged("AllEmployeeList");
            }

        }


        private List<tblEmployee> employeeList;
        public List<tblEmployee> EmployeeList
        {
            get
            {
                return employeeList;
            }
            set
            {
                employeeList = value;
                OnPropertyChanged("EmployeeList");
            }
        }



        public AddEmployeeViewModel(AddEmployeeView addEmployee)
        {
            Service.Service s = new Service.Service();

        }

        public AddEmployeeViewModel(AddEmployeeView addEmployee, tblEmployee tblEmployee)
        {

        }

        private ICommand save;
        public ICommand Save
        {
            get
            {
                if (save == null)
                {
                    save = new RelayCommand(param => AddEmployeExecute(), param => CanAddEmployeeExecute());
                }
                return save;
            }
        }


        private void AddEmployeExecute()
        {
            try
            {

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }


        private bool CanAddEmployeeExecute()
        {
            return true;
        }



    }
}
    

