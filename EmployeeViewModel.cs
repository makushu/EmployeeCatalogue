using EmployeeCatalogue3;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace EmployeeCatalogue3
{
    class EmployeeViewModel
    {


        public class gridShow
        {
            public gridShow(DataGrid dataGrid)
            {

                SqlConnection con = new SqlConnection();
                con.ConnectionString = ConfigurationManager.ConnectionStrings["employeeConnection"].ConnectionString;
                con.Open();
                try
                {
                    SqlCommand sqlCommand = new SqlCommand();
                    // DataTable dt;

                    sqlCommand.CommandText = "SELECT * FROM [Employee]";
                    sqlCommand.Connection = con;
                    SqlDataAdapter da = new SqlDataAdapter(sqlCommand);
                    DataTable dt = new DataTable("employee");
                    da.Fill(dt);

                    dataGrid.ItemsSource = dt.DefaultView;

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
        }


        /*
        public class addEmployee
        {
            public addEmployee(DataGrid dataGrid)
            {

                SqlConnection con = new SqlConnection();
                con.ConnectionString = ConfigurationManager.ConnectionStrings["employeeConnection"].ConnectionString;
                con.Open();

                try
                {
                    SqlCommand cmd = new SqlCommand();
                    //   btnShowEdit.IsEnabled = false;
                    cmd.CommandText = "INSERT INTO Employee(Name, Surname, DateOfBirth, Gender, HomeAddress) VALUES('" + txtAddName.Text.ToString() + "', '" + txtAddSurname.Text.ToString() + "' , '" + dpAddDateOfBirth.Text.ToString() + "', '" + cboAddGender.Text.ToString() + "',  '" + txtAddHomeAddress.Text.ToString() + "')";

                    cmd.Connection = con;
                    cmd.ExecuteNonQuery();
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    dt = new DataTable("employee");
                    da.Fill(dt);

                    employeeGrid.ItemsSource = dt.DefaultView;
                    MessageBox.Show(txtAddName.Text.ToString() + " " + txtAddSurname.Text.ToString() + " has been successfully added");
                    txtAddName.Text = "";
                    txtAddSurname.Text = "";
                    dpAddDateOfBirth.Text = "";
                    cboAddGender.Text = "";
                    txtAddHomeAddress.Text = "";
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
        }
        */
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
