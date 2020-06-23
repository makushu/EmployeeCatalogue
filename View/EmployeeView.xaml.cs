using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
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

        }

        private void bindDataGrid()
        {
            DataContext = new ShowEmployees(grdEmployee);
        }

        private void btnAddEmployee_Click(object sender, RoutedEventArgs e)
        {
           
            // DataContext = new AddEmployee(grdEmployee, btnShowEdit, txtAddName, txtAddSurname, dpAddDateOfBirth, cboAddGender, txtAddHomeAddress);
            MessageBox.Show(employee.Name + " " + employee.Surname);

        }

        private void btnEditEmployee_Click(object sender, RoutedEventArgs e)
        {
            this.DataContext = employee;

            // DataContext = new EditEmployee(grdEmployee, btnShowAdd, txtEditName, txtEditSurname, dpEditDateOfBirth, cboEditGender, txtEditHomeAddress, txtEditEmployeeId);
            //  DataContext = new EditEmployee();//(grdEmployee, btnShowAdd);

            // Employee employee = new Employee();
            MessageBox.Show(employee.Name + " " + employee.Surname + " " + employee.DateOfBirth + " " + employee.Gender + " " + employee.HomeAddress);

          
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

            // DataContext = new buttonShowGrid(grdEdit);
            DataContext = new ContextMenuEdit(grdEdit, txtEditEmployeeId);
           
            DataRowView dataRowView = (DataRowView)grdEmployee.SelectedItem;
            /*  binding.Source = (dataRowView["EmployeeId"]).ToString();
              id.SetBinding(Label.ContentProperty, binding);
  */
            Employee employee = new Employee
            {
                Id = (dataRowView["EmployeeId"]).ToString(),
                Name = (dataRowView["Name"]).ToString(),
                Surname = (dataRowView["Surname"]).ToString(),
                DateOfBirth = (dataRowView["DateOfBirth"]).ToString(),
                Gender = (dataRowView["Gender"]).ToString(),
                HomeAddress = (dataRowView["HomeAddress"]).ToString()
            };

            this.DataContext = employee;


            //            DataContext = new contextMenuEdit(grdEdit, employeeGrid, txtEditEmployeeId, txtEditName, txtEditSurname, dpEditDateOfBirth, cboEditGender, txtEditHomeAddress);

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