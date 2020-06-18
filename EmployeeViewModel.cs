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





        public class contextMenuView
        {
            public contextMenuView(DataGrid dataGrid)
            {
                DataRowView dataRowView = (DataRowView)dataGrid.SelectedItem;
                string name = (dataRowView["Name"]).ToString();
                string surname = (dataRowView["Surname"]).ToString();
                string dateOfBirth = (dataRowView["DateOfBirth"]).ToString();
                string gender = (dataRowView["Gender"]).ToString();
                string homeAddress = (dataRowView["HomeAddress"]).ToString();



                MessageBox.Show("Name : " + name + "\n" + "Surname : " + surname + "\n" + "Date Of Birth : " +
                    dateOfBirth + "\n" + "Gender : " + gender + "\n" + "Home Address : " + homeAddress, name.ToUpper() + "'s DETAILS");


                
            }
        }




        public class contextMenuEdit
        {
            public contextMenuEdit(Grid grid, DataGrid dataGrid, TextBox id, TextBox name, TextBox surname, DatePicker dateOfBirth, ComboBox gender, TextBox homeAddress)
            {

                var visibility = grid.Visibility;

                switch (visibility)
                {
                    case Visibility.Hidden: grid.Visibility = Visibility.Collapsed; break;
                    case Visibility.Visible: grid.Visibility = Visibility.Hidden; break;
                    case Visibility.Collapsed: grid.Visibility = Visibility.Visible; break;
                } 

                /*
                DataRowView dataRowView = (DataRowView)dataGrid.SelectedItem;
                id.Text = (dataRowView["EmployeeId"]).ToString();
                name.Text = (dataRowView["Name"]).ToString();
                surname.Text = (dataRowView["Surname"]).ToString();
                dateOfBirth.Text = (dataRowView["DateOfBirth"]).ToString();
                gender.Text = (dataRowView["Gender"]).ToString();
                homeAddress.Text = (dataRowView["HomeAddress"]).ToString();

                /*
                DataRowView dataRowView = (DataRowView)employeeGrid.SelectedItem;
                txtEditEmployeeId.Text = (dataRowView["EmployeeId"]).ToString();
                txtEditName.Text = (dataRowView["Name"]).ToString();
                txtEditSurname.Text = (dataRowView["Surname"]).ToString();
                dpEditDateOfBirth.Text = (dataRowView["DateOfBirth"]).ToString();
                cboEditGender.Text = (dataRowView["Gender"]).ToString();
                txtEditHomeAddress.Text = (dataRowView["HomeAddress"]).ToString();
                */

            }
        }


        public class buttonShowGrid
        {
            public buttonShowGrid(Grid grid)
            {
                var visibility = grid.Visibility;

                switch (visibility)
                {
                    case Visibility.Hidden: grid.Visibility = Visibility.Collapsed; break;
                    case Visibility.Visible: grid.Visibility = Visibility.Hidden; break;
                    case Visibility.Collapsed: grid.Visibility = Visibility.Visible; break;
                }

            }
        }


        public class searchEmployee
        {
            public searchEmployee(DataGrid dataGrid, Button add, Button edit, TextBox textBox)
            {
                SqlConnection con = new SqlConnection();
                con.ConnectionString = ConfigurationManager.ConnectionStrings["employeeConnection"].ConnectionString;
                con.Open();

                try
                {
                    /*
                    if(textBox.Text != null)
                    {
                        add.IsEnabled = false;
                        edit.IsEnabled = false;
                    }
                    */
                    
                    SqlCommand cmd = new SqlCommand();

                    cmd.CommandText = "SELECT * FROM Employee WHERE Name LIKE'" + "%" + textBox.Text.ToString() + "%" + "' OR Surname LIKE '" + "%" + textBox.Text.ToString() + "%" + "' OR HomeAddress LIKE '" + "%" + textBox.Text.ToString() + "%" + "' ";

                    cmd.Connection = con;
                    cmd.ExecuteNonQuery();
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
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





        public class addEmployee
        {
            public addEmployee(DataGrid dataGrid, Button button, TextBox name, TextBox surname, DatePicker dateOfBirth, ComboBox gender, TextBox homeAddress)
            {
                SqlConnection con = new SqlConnection();
                con.ConnectionString = ConfigurationManager.ConnectionStrings["employeeConnection"].ConnectionString;
                con.Open();

                try
                {
                    SqlCommand sqlCommand = new SqlCommand();

                    button.IsEnabled = false;
                    sqlCommand.CommandText = "INSERT INTO Employee(Name, Surname, DateOfBirth, Gender, HomeAddress) VALUES('" + name.Text.ToString() + "', '" + surname.Text.ToString() + "' , '" + dateOfBirth.Text.ToString() + "', '" + gender.Text.ToString() + "',  '" + homeAddress.Text.ToString() + "')";

                    sqlCommand.Connection = con;
                    sqlCommand.ExecuteNonQuery();
                    SqlDataAdapter da = new SqlDataAdapter(sqlCommand);
                    DataTable dataTable = new DataTable("employee");
                    da.Fill(dataTable);
                    
                    dataGrid.ItemsSource = dataTable.DefaultView;
                    MessageBox.Show(name.Text.ToString() + " " + surname.Text.ToString() + " has been successfully added");
                    name.Text = "";
                    surname.Text = "";
                    dateOfBirth.Text = "";
                    gender.Text = "";
                    homeAddress.Text = "";
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


        public class editEmployee
        {
            public editEmployee(DataGrid dataGrid, Button button, TextBox name, TextBox surname, DatePicker dateOfBirth, ComboBox gender, TextBox homeAddress, TextBox id)
            {
                SqlConnection con = new SqlConnection();
                con.ConnectionString = ConfigurationManager.ConnectionStrings["employeeConnection"].ConnectionString;
                con.Open();

                try
                {
                    SqlCommand sqlCommand = new SqlCommand();

                    button.IsEnabled = false;
                    sqlCommand.CommandText = "UPDATE Employee SET Name='" + name.Text.ToString() + "',Surname='" + surname.Text.ToString() + "',DateOfBirth='" + dateOfBirth.Text.ToString() + "',Gender='" + gender.Text.ToString() + "',HomeAddress='" + homeAddress.Text.ToString() + "' WHERE EmployeeId ='" + id.Text.ToString() + "' ";

                    sqlCommand.Connection = con;
                    sqlCommand.ExecuteNonQuery();
                    SqlDataAdapter da = new SqlDataAdapter(sqlCommand);
                    DataTable dataTable = new DataTable("employee");
                    da.Fill(dataTable);

                    dataGrid.ItemsSource = dataTable.DefaultView;
                    MessageBox.Show(name.Text.ToString() + " " + surname.Text.ToString() + " has been successfully edited");
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
