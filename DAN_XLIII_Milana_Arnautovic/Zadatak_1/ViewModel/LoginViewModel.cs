using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using Zadatak_1.Command;
using Zadatak_1.Model;
using Zadatak_1.View;

namespace Zadatak_1.ViewModel
{
    class LoginViewModel : ViewModelBase
    {
       

        LoginView logIn;
        
            private tblEmployee logged;
            public tblEmployee Logged
            {
                get { return logged; }
                set
                {
                    logged = value;
                    OnPropertyChanged("Logged");
                }
            }
        private tblRole role;
        public tblRole Role
        {
            get { return role; }
            set
            {
               role = value;
                OnPropertyChanged("Role");
            }
        }


        #region Constructor
        public LoginViewModel(LoginView logInOpen)
            {
                logIn = logInOpen;
                logged = new tblEmployee();
            }
            #endregion Constructor

           
            private ICommand login;
            public ICommand Login
            {
                get
                {
                    if (login == null)
                    {
                        login = new RelayCommand(param => LoginExecute(), param => CanLoginExecute());
                    }
                    return login;
                }
            }
           
            private void LoginExecute()
        { 
            try
                {
                    switch (role.RoleName)
                    {
                        case "WPFadmin":
                            WPFadminView adminMenu = new WPFadminView();
                            adminMenu.ShowDialog();
                            break;
                        case "Employee":
                            AddReportView addReport = new AddReportView();
                            addReport.ShowDialog();
                            break;
                        case "Manager":
                            tblManager manager = Service.Service.GetManagerById(logged.EmployeeID);
                            if (manager.AccessLevel == "Modify")
                            {
                                ModifyView modify = new ModifyView();
                                modify.ShowDialog();
                            }
                            else
                            {
                                ReadOnlyView readOnly = new ReadOnlyView();
                                readOnly.ShowDialog();
                            }
                            break;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }

           
            private bool CanLoginExecute()
            {
                return true;
            }

            
            private ICommand cancel;
            public ICommand Cancel
            {
                get
                {
                    if (cancel == null)
                    {
                        cancel = new RelayCommand(param => CancelExecute(), param => CanCancelExecute());
                    }
                    return cancel;
                }
            }

           
            private void CancelExecute()
            {
                try
                {
                    logIn.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }

           
            private bool CanCancelExecute()
            {
                return true;
            }
         

    }
}