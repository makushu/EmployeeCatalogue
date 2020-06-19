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

        public EmployeeView()
        {

            InitializeComponent();
            bindDataGrid();
            //   EmployeeViewModel employeeViewModel = new EmployeeViewModel();
            // MessageBox.Show(employeeViewModel.Hey());
            //EmployeeViewModel.StillVoid();
            //    employeeViewModel.bindDataGrid();
            //    CheckVM checkVM = new CheckVM();


        }


        private void bindDataGrid()
        {
            DataContext = new gridShow(employeeGrid);
        }


        private void btnShowAdd_Click(object sender, RoutedEventArgs e)
        {
            DataContext = new buttonShowGrid(grdAdd);
        }

        private void btnShowEdit_Click(object sender, RoutedEventArgs e)
        {
            DataContext = new buttonShowGrid(grdEdit);
        }



        private void btnAddEmployee_Click(object sender, RoutedEventArgs e)
        {


            DataContext = new addEmployee(employeeGrid, btnShowEdit, txtAddName, txtAddSurname, dpAddDateOfBirth, cboAddGender, txtAddHomeAddress);




        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {


            DataContext = new editEmployee(employeeGrid, btnShowAdd, txtEditName, txtEditSurname, dpEditDateOfBirth, cboEditGender, txtEditHomeAddress, txtEditEmployeeId);



        }

        private void ctmView(object sender, RoutedEventArgs e)
        {

            DataContext = new contextMenuView(employeeGrid);
        }

        /*   private void Button_Click_3(object sender, RoutedEventArgs e)
           {

           }
           */

        private void ctmEdit(object sender, RoutedEventArgs e)
        {

            DataContext = new buttonShowGrid(grdEdit);
            Binding binding = new Binding();

            //  string id;

            DataRowView dataRowView = (DataRowView)employeeGrid.SelectedItem;
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


        private void txtEmployeeSearch(object sender, KeyEventArgs e)
        {
            DataContext = new searchEmployee(employeeGrid, btnShowAdd, btnShowEdit, txtSearchEmployeee);
        }

        private void btnCloseAddGrid_Click(object sender, RoutedEventArgs e)
        {
            DataContext = new closeGrid(grdAdd);

        }

        private void btnCloseEditGrid_Click(object sender, RoutedEventArgs e)
        {
            DataContext = new closeGrid(grdEdit);
        }
    }
}