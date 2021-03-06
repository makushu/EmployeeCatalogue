﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Xml.Linq;
using static EmployeeCatalogue3.EmployeeModel;
using static EmployeeCatalogue3.EmployeeViewModel;

namespace EmployeeCatalogue3.View

{
    /// <summary>
    /// Interaction logic for EmployeeView.xaml
    /// </summary>
    public partial class EmployeeView : Page
    {
        Employee employee = new Employee();
        public EmployeeView()
        {
            InitializeComponent();
            bindDataGrid();
            this.DataContext = employee;
        }


        private void bindDataGrid()
        {
            DataContext = new ShowEmployees(grdEmployee);
        }

        private void btnAddEmployee_Click(object sender, RoutedEventArgs e)
        {


       //    DataContext = new AddEmployee(grdEmployee, btnShowEdit);

            SqlConnection sqlConnection = new SqlConnection();
            sqlConnection.ConnectionString = ConfigurationManager.ConnectionStrings["employeeConnection"].ConnectionString;
            sqlConnection.Open();

            try
            {

                if (!Regex.IsMatch(employee.Name, @"[a-zA-Z,.-]{3,30}"))
                {
                    MessageBox.Show("Please enter the employee's correct name");
                }
                else if (!Regex.IsMatch(employee.Surname, @"[a-zA-Z,.-]{3,30}"))
                {
                    MessageBox.Show("Please enter the employee's correct surname");
                }
                else if (employee.DateOfBirth.Length == 0)
                {
                    MessageBox.Show("Please select the employee's date of birth");
                }
                else if (employee.Gender.Length == 0)
                {
                    MessageBox.Show("Please select the employee's gender");
                }
                else if (!Regex.IsMatch(employee.HomeAddress, @"[a-zA-Z,.-]{3,100}"))
                {
                    MessageBox.Show("Please enter the employee's correct home address");
                }
                else
                {

                    SqlCommand sqlCommand = new SqlCommand();

                    btnShowEdit.IsEnabled = false;
                    sqlCommand.CommandText = "INSERT INTO Employee(Name, Surname, DateOfBirth, Gender, HomeAddress) VALUES('" + employee.Name + "', '" + employee.Surname + "' , '" + employee.DateOfBirth + "', '" + employee.Gender + "',  '" + employee.HomeAddress + "')";

                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.ExecuteNonQuery();
                    SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
                    DataTable dataTable = new DataTable("employee");
                    sqlDataAdapter.Fill(dataTable);

                    grdEmployee.ItemsSource = dataTable.DefaultView;
                    MessageBox.Show(employee.Name + " " + employee.Surname + " has been successfully added");
                   
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

        private void btnEditEmployee_Click(object sender, RoutedEventArgs e)
        { 
               DataContext = new EditEmployee(grdEmployee, btnShowAdd);
        }




        private void txtEmployeeSearch(object sender, KeyEventArgs e)
        {
            DataContext = new SearchEmployee(grdEmployee, btnShowAdd, btnShowEdit, txtSearchEmployeee);
        }

        private void btnShowAdd_Click(object sender, RoutedEventArgs e)
        {
            DataContext = new ButtonShowGrid(grdAdd);
        }

        private void btnShowEdit_Click(object sender, RoutedEventArgs e)
        {
            DataContext = new ButtonShowGrid(grdEdit);
        }

        private void ctmView(object sender, RoutedEventArgs e)
        {

            DataContext = new ContextMenuView(grdEmployee);
        }

        private void ctmEdit(object sender, RoutedEventArgs e)
        {

      
            DataRowView dataRowView = (DataRowView)grdEmployee.SelectedItem;
          

            employee.Id = (dataRowView["EmployeeId"]).ToString();
            employee.Name = (dataRowView["Name"]).ToString();
            employee.Surname = (dataRowView["Surname"]).ToString();
            employee.DateOfBirth = (dataRowView["DateOfBirth"]).ToString();
            employee.Gender = (dataRowView["Gender"]).ToString();
            employee.HomeAddress = (dataRowView["HomeAddress"]).ToString();

        }

        private void btnCloseAddGrid_Click(object sender, RoutedEventArgs e)
        {
            DataContext = new CloseGrid(grdAdd);

        }

        private void btnCloseEditGrid_Click(object sender, RoutedEventArgs e)
        {
            DataContext = new CloseGrid(grdEdit);
        }


    }
}