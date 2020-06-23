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


        public class ShowEmployees
        {
            public ShowEmployees(DataGrid dataGrid)
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













        public class AddEmployee
        {
            public AddEmployee(DataGrid dataGrid, Button button, TextBox name, TextBox surname, DatePicker dateOfBirth, ComboBox gender, TextBox homeAddress)
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


        public class EditEmployee
        {
            
            //public EditEmployee(DataGrid dataGrid, Button button, TextBox name, TextBox surname, DatePicker dateOfBirth, ComboBox gender, TextBox homeAddress, TextBox id)

            public EditEmployee()//(DataGrid dataGrid, Button button)
            {
                // Employee employee = new Employee();
                // MessageBox.Show(employee.Name + " " + employee.Surname + " " + employee.DateOfBirth + " " + employee.Gender + " " + employee.HomeAddress);

                //   SqlConnection sqlConnection = new SqlConnection();
                //  sqlConnection.ConnectionString = ConfigurationManager.ConnectionStrings["employeeConnection"].ConnectionString;
                //  sqlConnection.Open();
                //
                //  try
                // {
                //  Employee employee = new Employee();

                //  if (!Regex.IsMatch(employee.Name, @"[a-zA-Z,.-]{3,30}"))
                //  {

                //     MessageBox.Show("Please enter the employee's correct name");

                // }


                //   else if (!Regex.IsMatch(employee.Surname, @"[a-zA-Z,.-]{3,30}"))
                //  {
                //      MessageBox.Show("Please enter the employee's correct surname");
                //  }
                //  else if (employee.DateOfBirth.Length == 0)
                //  {
                //    MessageBox.Show("Please select the employee's date of birth");
                //  }
                //  else if (employee.Gender.Length == 0)
                //  {
                //      MessageBox.Show("Please select the employee's gender");
                //   }
                //  else if (!Regex.IsMatch(employee.HomeAddress, @"[a-zA-Z,.-]{3,100}"))
                //  {
                //      MessageBox.Show("Please enter the employee's correct home address");
                // }
                // else
                //  {
                //    SqlCommand sqlCommand = new SqlCommand();

                //   button.IsEnabled = false;
                //   sqlCommand.CommandText = "UPDATE Employee SET Name='" + employee.Name + "',Surname='" + employee.Surname + "',DateOfBirth='" + employee.DateOfBirth + "',Gender='" + employee.Gender + "',HomeAddress='" + employee.HomeAddress + "' WHERE EmployeeId ='" + employee.Id + "' ";

                //  sqlCommand.Connection = sqlConnection;
                //   sqlCommand.ExecuteNonQuery();
                ////     SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
                //    DataTable dataTable = new DataTable("employee");
                //    sqlDataAdapter.Fill(dataTable);

                //   dataGrid.ItemsSource = dataTable.DefaultView;
                //   MessageBox.Show(employee.Name + " " + employee.Surname + " has been successfully edited");
                // }
                // }

                //  catch (Exception ex)
                //  {
                //     MessageBox.Show(ex.Message.ToString());
                //  }

                //  finally
                //   {
                //       sqlConnection.Close();
                //   }

            }

        }
    

            public class SearchEmployee
            {
                public SearchEmployee(DataGrid dataGrid, Button add, Button edit, TextBox textBox)
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


            public class ButtonShowGrid
            {
                public ButtonShowGrid(Grid grid)
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




            public class ContextMenuView
            {
                public ContextMenuView(DataGrid dataGrid)
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




            public class ContextMenuEdit
            {
                //  public contextMenuEdit(Grid grid, DataGrid dataGrid, TextBox id, TextBox name, TextBox surname, DatePicker dateOfBirth, ComboBox gender, TextBox homeAddress)
                public ContextMenuEdit(Grid grid, TextBox txtId)
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



            public class CloseGrid
            {
                public CloseGrid(Grid grid)
                {
                    grid.Visibility = Visibility.Collapsed;
                }
            }

        }

    }
