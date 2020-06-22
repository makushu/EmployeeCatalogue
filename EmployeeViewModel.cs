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
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;


namespace EmployeeCatalogue3
{
    class EmployeeViewModel
    {


        public class showEmployees
        {
            public showEmployees(DataGrid dataGrid)
            {

                SqlConnection sqlConnection = new SqlConnection();
                sqlConnection.ConnectionString = ConfigurationManager.ConnectionStrings["employeeConnection"].ConnectionString;
                sqlConnection.Open();
                try
                {
                    
                    SqlCommand sqlCommand = new SqlCommand();

                    sqlCommand.CommandText = "SELECT * FROM [Employee]";
                    sqlCommand.Connection = sqlConnection;
                    SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
                    DataTable dataTable = new DataTable("employee");
                    sqlDataAdapter.Fill(dataTable);

                    dataGrid.ItemsSource = dataTable.DefaultView;

                }

                catch (Exception exception)
                {
                    MessageBox.Show(exception.Message.ToString());
                }

                finally
                {
                    sqlConnection.Close();
                }

            }
        }








       




        public class addEmployee
        {
            public addEmployee(DataGrid dataGrid, Button button, TextBox name, TextBox surname, DatePicker dateOfBirth, ComboBox gender, TextBox homeAddress)
            {
                SqlConnection sqlConnection = new SqlConnection();
                sqlConnection.ConnectionString = ConfigurationManager.ConnectionStrings["employeeConnection"].ConnectionString;
                sqlConnection.Open();

                try
                {
                    if (!Regex.IsMatch(name.Text, @"[a-zA-Z,.-]{3,30}"))
                    {
                        MessageBox.Show("Please enter the employee's correct name");
                    }
                    else if (!Regex.IsMatch(surname.Text, @"[a-zA-Z,.-]{3,30}"))
                    {
                        MessageBox.Show("Please enter the employee's correct surname");
                    }
                    else if (dateOfBirth.Text.Length == 0)
                    {
                        MessageBox.Show("Please select the employee's date of birth");
                    }
                    else if (gender.Text.Length == 0)
                    {
                        MessageBox.Show("Please select the employee's gender");
                    }
                    else if (!Regex.IsMatch(homeAddress.Text, @"[a-zA-Z,.-]{3,100}"))
                    {
                        MessageBox.Show("Please enter the employee's correct home address");
                    }
                    else
                    {

                        SqlCommand sqlCommand = new SqlCommand();

                        button.IsEnabled = false;
                        sqlCommand.CommandText = "INSERT INTO Employee(Name, Surname, DateOfBirth, Gender, HomeAddress) VALUES('" + name.Text.ToString() + "', '" + surname.Text.ToString() + "' , '" + dateOfBirth.Text.ToString() + "', '" + gender.Text.ToString() + "',  '" + homeAddress.Text.ToString() + "')";

                        sqlCommand.Connection = sqlConnection;
                        sqlCommand.ExecuteNonQuery();
                        SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
                        DataTable dataTable = new DataTable("employee");
                        sqlDataAdapter.Fill(dataTable);

                        dataGrid.ItemsSource = dataTable.DefaultView;
                        MessageBox.Show(name.Text.ToString() + " " + surname.Text.ToString() + " has been successfully added");
                        name.Text = "";
                        surname.Text = "";
                        dateOfBirth.Text = "";
                        gender.Text = "";
                        homeAddress.Text = "";
                    }   
                }

                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }

                finally
                {
                    sqlConnection.Close();
                }

            }

        }


        public class editEmployee
        {
            public editEmployee(DataGrid dataGrid, Button button, TextBox name, TextBox surname, DatePicker dateOfBirth, ComboBox gender, TextBox homeAddress, TextBox id)
            {
                SqlConnection sqlConnection = new SqlConnection();
                sqlConnection.ConnectionString = ConfigurationManager.ConnectionStrings["employeeConnection"].ConnectionString;
                sqlConnection.Open();

                try
                {

                    if (!Regex.IsMatch(name.Text, @"[a-zA-Z,.-]{3,30}"))
                    {

                        MessageBox.Show("Please enter the employee's correct name");

                    }


                    else if (!Regex.IsMatch(surname.Text, @"[a-zA-Z,.-]{3,30}"))
                    {
                        MessageBox.Show("Please enter the employee's correct surname");
                    }
                    else if (dateOfBirth.Text.Length == 0)
                    {
                        MessageBox.Show("Please select the employee's date of birth");
                    }
                    else if (gender.Text.Length == 0)
                    {
                        MessageBox.Show("Please select the employee's gender");
                    }
                    else if (!Regex.IsMatch(homeAddress.Text, @"[a-zA-Z,.-]{3,100}"))
                    {
                        MessageBox.Show("Please enter the employee's correct home address");
                    }
                    else
                    {
                        SqlCommand sqlCommand = new SqlCommand();

                        button.IsEnabled = false;
                        sqlCommand.CommandText = "UPDATE Employee SET Name='" + name.Text.ToString() + "',Surname='" + surname.Text.ToString() + "',DateOfBirth='" + dateOfBirth.Text.ToString() + "',Gender='" + gender.Text.ToString() + "',HomeAddress='" + homeAddress.Text.ToString() + "' WHERE EmployeeId ='" + id.Text.ToString() + "' ";

                        sqlCommand.Connection = sqlConnection;
                        sqlCommand.ExecuteNonQuery();
                        SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
                        DataTable dataTable = new DataTable("employee");
                        sqlDataAdapter.Fill(dataTable);

                        dataGrid.ItemsSource = dataTable.DefaultView;
                        MessageBox.Show(name.Text.ToString() + " " + surname.Text.ToString() + " has been successfully edited");
                    }
                }

                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }

                finally
                {
                    sqlConnection.Close();
                }

            }
        }



        public class searchEmployee
        {
            public searchEmployee(DataGrid dataGrid, Button add, Button edit, TextBox textBox)
            {
                SqlConnection sqlConnection = new SqlConnection();
                sqlConnection.ConnectionString = ConfigurationManager.ConnectionStrings["employeeConnection"].ConnectionString;
                sqlConnection.Open();

                try
                {
                    /*
                    if(textBox.Text != null)
                    {
                        add.IsEnabled = false;
                        edit.IsEnabled = false;
                    }
                    */

                    SqlCommand sqlCommand = new SqlCommand();

                    sqlCommand.CommandText = "SELECT * FROM Employee WHERE Name LIKE'" + "%" + textBox.Text.ToString() + "%" + "' OR Surname LIKE '" + "%" + textBox.Text.ToString() + "%" + "' OR HomeAddress LIKE '" + "%" + textBox.Text.ToString() + "%" + "' ";

                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.ExecuteNonQuery();
                    SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
                    DataTable dataTable = new DataTable("employee");
                    sqlDataAdapter.Fill(dataTable);

                    dataGrid.ItemsSource = dataTable.DefaultView;

                }

                catch (Exception exception)
                {
                    MessageBox.Show(exception.Message.ToString());
                }

                finally
                {
                    sqlConnection.Close();

                }



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
            //  public contextMenuEdit(Grid grid, DataGrid dataGrid, TextBox id, TextBox name, TextBox surname, DatePicker dateOfBirth, ComboBox gender, TextBox homeAddress)
            public contextMenuEdit(Grid grid, TextBox txtId)
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

                txtId.IsEnabled = false;
                
            }
        }



        public class closeGrid
        {
            public closeGrid(Grid grid)
            {
                grid.Visibility = Visibility.Collapsed;
            }
        }

    }

}
