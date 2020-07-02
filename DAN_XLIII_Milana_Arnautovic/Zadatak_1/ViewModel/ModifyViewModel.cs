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
    class ModifyViewModel : ViewModelBase
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

        public ModifyViewModel(tblEmployee employeeOpen)
        {
            employeee = employeeOpen;

            Service.Service s = new Service.Service();
            employed = s.GetAllEmployee().ToList();
        }

        private ICommand addEmployee;
        public ICommand AddEmployee
        {
            get
            {
                if (addEmployee == null)
                {
                    addEmployee = new RelayCommand(param => AddEmployeExecute(), param => CanAddEmployeeExecute());
                }
                return addEmployee;
            }
        }

       
        private void AddEmployeExecute()
        {
            try
            {
                AddEmployeeView addEmployee = new AddEmployeeView();
                addEmployee.ShowDialog();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        /// <summary>
        /// Can add IdCard command
        /// </summary>
        /// <returns>True or false</returns>
        private bool CanAddEmployeeExecute()
        {
            return true;
        }





        private ICommand deleteEmployee;
        public ICommand DeleteEmployee
        {
            get
            {
                if (deleteEmployee == null)
                {
                    deleteEmployee = new RelayCommand(param => DeletedEmployeeExecute(), param => CanDeletedEmployeeExecute());
                }
                return deleteEmployee;
            }
        }

        public void DeletedEmployeeExecute()
        {
            try
            {
                if (Employed != null)
                {
                    Service.Service s = new Service.Service();

                    int employeeID = AllEmployeeV.EmployeeID;
                    string message = "Deleted employee: " + AllEmployeeV.Surname;
                    bool isEmployee = s.IsEmployeeID(employeeID);

                    if (isEmployee == true)
                    {
                        s.DeleteEmployee(employeeID);
                        Employed = s.GetAllEmployee().ToList();

                        
                    }
                    else
                    {
                        MessageBox.Show("Unable to delete employee");
                    }


                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        public bool CanDeletedEmployeeExecute()
        {
            if (Employed == null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}
