using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zadatak_1.Model;

namespace Zadatak_1.Service
{
    class Service
    {
        public List<tblEmployee> GetAllEmployee()
        {
            try
            {
                using (DAN_XLIIIEntities1 context = new DAN_XLIIIEntities1())
                {
                    List<tblEmployee> list = new List<tblEmployee>();
                    list = (from e in context.tblEmployees select e).ToList();
                    return list;
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Exception" + ex.Message.ToString());
                return null;
            }
        }

        public void DeleteEmployee(int idEmployee)
        {
            try
            {
                using (DAN_XLIIIEntities1 context = new DAN_XLIIIEntities1())
                {
                    tblEmployee idEmployeeToDelete = (from e in context.tblEmployees where e.EmployeeID == idEmployee select e).First();
                    context.tblEmployees.Remove(idEmployeeToDelete);
                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Exception" + ex.Message.ToString());
            }
        }
        public List<vwReport> GetAllReportView()
        {
            try
            {
                using (DAN_XLIIIEntities1 context = new DAN_XLIIIEntities1())
                {
                    List<vwReport> list = new List<vwReport>();
                    list = (from e in context.vwReports select e).ToList();
                    return list;
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Exception" + ex.Message.ToString());
                return null;
            }
        }

        public static tblEmployee GetEmployeeByCredentials(string username, string password)
        {
            try
            {
                using (DAN_XLIIIEntities1 context = new DAN_XLIIIEntities1())
                {
                    tblEmployee employee = (from x in context.tblEmployees where x.Username == username && x.Pasword == password select x).FirstOrDefault();
                    return employee;
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Exception " + ex.Message.ToString());
                return null;
            }
        }


        public static bool IsManager(tblEmployee employee)
        {
            try
            {
                using (DAN_XLIIIEntities1 context = new DAN_XLIIIEntities1())
                {
                    tblManager manager = (from x in context.tblManagers where x.ManagerID == employee.EmployeeID select x).FirstOrDefault();
                    if (manager != null)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Exception " + ex.Message.ToString());
                return false;
            }
        }


        public static tblManager GetManagerById(int id)
        {
            try
            {
                using (DAN_XLIIIEntities1 context = new DAN_XLIIIEntities1())
                {
                    tblManager manager = (from x in context.tblManagers where x.ManagerID == id select x).FirstOrDefault();
                    return manager;
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Exception " + ex.Message.ToString());
                return null;
            }

        }


        public bool IsEmployeeID(int userID)
        {
            try
            {
                using (DAN_XLIIIEntities1 context = new DAN_XLIIIEntities1())
                {
                    int user = (from l in context.tblEmployees where l.EmployeeID == userID select l.EmployeeID).FirstOrDefault();

                    if (user != 0)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Exception " + ex.Message.ToString());
                return false;
            }
        }

        public List<tblRole> GetAllRole()
        {
            try
            {
                using (DAN_XLIIIEntities1 context = new DAN_XLIIIEntities1())
                {
                    List<tblRole> list = new List<tblRole>();
                    list = (from l in context.tblRoles select l).ToList();
                    return list;
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Exception" + ex.Message.ToString());
                return null;
            }
        }
    }

}