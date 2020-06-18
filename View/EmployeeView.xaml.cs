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


        SqlCommand cmd = new SqlCommand();
        DataTable dt;
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

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //   DataContext = new MVVMButtonClickViewModel();

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            //   DataContext = new Button2();

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

            
            DataRowView dataRowView = (DataRowView)employeeGrid.SelectedItem;
            txtEditEmployeeId.Text = (dataRowView["EmployeeId"]).ToString();
            txtEditName.Text = (dataRowView["Name"]).ToString();
            txtEditSurname.Text = (dataRowView["Surname"]).ToString();
            dpEditDateOfBirth.Text = (dataRowView["DateOfBirth"]).ToString();
            cboEditGender.Text = (dataRowView["Gender"]).ToString();
            txtEditHomeAddress.Text = (dataRowView["HomeAddress"]).ToString();


            //            DataContext = new contextMenuEdit(grdEdit, employeeGrid, txtEditEmployeeId, txtEditName, txtEditSurname, dpEditDateOfBirth, cboEditGender, txtEditHomeAddress);



        }



        private void txtEmployeeSearch(object sender, KeyEventArgs e)
        {
            DataContext = new searchEmployee(employeeGrid, btnShowAdd, btnShowEdit, txtSearchEmployeee);
        }
    }
}