using EmployeeCatalogue3;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace EmployeeCatalogue3
{
    class EmployeeViewModel
    {
        /*
         public void showTheGridPlease()
         {
             SqlCommand cmd = new SqlCommand();
             DataTable dt;

             SqlConnection con = new SqlConnection();
             con.ConnectionString = ConfigurationManager.ConnectionStrings["employeeConnection"].ConnectionString;
             con.Open();
             try
             {


                 cmd.CommandText = "SELECT * FROM [Employee]";
                 cmd.Connection = con;
                 SqlDataAdapter da = new SqlDataAdapter(cmd);
                 DataTable dt = new DataTable("employee");
                 da.Fill(dt);

                 employeeGrid.ItemsSource = dt.DefaultView;

             }

             catch (Exception ex)
             {
                 MessageBox.Show(ex.Message.ToString());
             }

             finally
             {
                 con.Close();
             }

         }


         public int EmployeeId
         {
             get => this.employeeId;
             set
             {
                 if (employeeId == value) // check if value changed
                     return; // do nothing if value same

                 employeeId = value; // change value
                 OnPropertyChanged("employeeId"); // pass changed property name
             }
         }




     public class MVVMButtonClickViewModel
     {
         private ICommand m_ButtonCommand;

         public ICommand MVVMClick
         {
             get { return m_ButtonCommand; }
             set { m_ButtonCommand = value; }
         }

         public void ShowMessage(object obj)
         {
             MessageBox.Show("Test");
         }
         public MVVMButtonClickViewModel()
         {
             MVVMClick = new RelayCommand(new Action<object>(ShowMessage));
         }
     }



     public class Button2//MVVMButtonClickViewModel
     {
         private ICommand m_ButtonCommand;

         public ICommand Click2
         {
             get { return m_ButtonCommand; }
             set { m_ButtonCommand = value; }
         }

         public void ShowMessage(object obj)
         {
             MessageBox.Show("Tesfdsdgst");
         }
         public Button2() //MVVMButtonClickViewModel()
         {
             Click2 = new RelayCommand(new Action<object>(ShowMessage));
         }
     }


     */
    }
  
   

}
