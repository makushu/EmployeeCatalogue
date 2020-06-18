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

            //            DataContext = new showGridPlease();

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

        private void btnShowAdd_Click(object sender, RoutedEventArgs e)
        {

            var visibility = grdAdd.Visibility;

            switch (visibility)
            {
                case Visibility.Hidden: grdAdd.Visibility = Visibility.Collapsed; break;
                case Visibility.Visible: grdAdd.Visibility = Visibility.Hidden; break;
                case Visibility.Collapsed: grdAdd.Visibility = Visibility.Visible; break;
            }


        }

        private void btnShowEdit_Click(object sender, RoutedEventArgs e)
        {
            var visibility = grdEdit.Visibility;

            switch (visibility)
            {
                case Visibility.Hidden: grdEdit.Visibility = Visibility.Collapsed; break;
                case Visibility.Visible: grdEdit.Visibility = Visibility.Hidden; break;
                case Visibility.Collapsed: grdEdit.Visibility = Visibility.Visible; break;
            }
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



            SqlConnection con = new SqlConnection();
            con.ConnectionString = ConfigurationManager.ConnectionStrings["employeeConnection"].ConnectionString;
            con.Open();

            try
            {

                btnShowEdit.IsEnabled = false;
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

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {


            SqlConnection con = new SqlConnection();
            con.ConnectionString = ConfigurationManager.ConnectionStrings["employeeConnection"].ConnectionString;
            con.Open();

            try
            {
                btnShowAdd.IsEnabled = false;
                cmd.CommandText = "UPDATE Employee SET Name='" + txtEditName.Text.ToString() + "',Surname='" + txtEditSurname.Text.ToString() + "',DateOfBirth='" + dpEditDateOfBirth.Text.ToString() + "',Gender='" + cboEditGender.Text.ToString() + "',HomeAddress='" + txtEditHomeAddress.Text.ToString() + "' WHERE EmployeeId ='" + txtEditEmployeeId.Text.ToString() + "' ";

                cmd.Connection = con;
                cmd.ExecuteNonQuery();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                dt = new DataTable("employee");
                da.Fill(dt);

                employeeGrid.ItemsSource = dt.DefaultView;
                MessageBox.Show(txtEditName.Text.ToString() + " " + txtEditSurname.Text.ToString() + " has been successfully edited");
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

        private void ctmView(object sender, RoutedEventArgs e)
        {

            DataRowView dataRowView = (DataRowView)employeeGrid.SelectedItem;
            string name = (dataRowView["Name"]).ToString();
            string surname = (dataRowView["Surname"]).ToString();
            string dateOfBirth = (dataRowView["DateOfBirth"]).ToString();
            string gender = (dataRowView["Gender"]).ToString();
            string homeAddress = (dataRowView["HomeAddress"]).ToString();



            MessageBox.Show("Name : " + name + "\n" + "Surname : " + surname + "\n" + "Date Of Birth : " +
                dateOfBirth + "\n" + "Gender : " + gender + "\n" + "Home Address : " + homeAddress, name.ToUpper() + "'s DETAILS");


        }

        /*   private void Button_Click_3(object sender, RoutedEventArgs e)
           {

           }
           */

        private void ctmEdit(object sender, RoutedEventArgs e)
        {

            btnShowAdd.IsEnabled = false;

            var visibility = grdEdit.Visibility;

            switch (visibility)
            {
                case Visibility.Hidden: grdEdit.Visibility = Visibility.Collapsed; break;
                case Visibility.Visible: grdEdit.Visibility = Visibility.Hidden; break;
                case Visibility.Collapsed: grdEdit.Visibility = Visibility.Visible; break;
            }


            DataRowView dataRowView = (DataRowView)employeeGrid.SelectedItem;
            string id = (dataRowView["EmployeeId"]).ToString();
            string name = (dataRowView["Name"]).ToString();
            string surname = (dataRowView["Surname"]).ToString();
            string dateOfBirth = (dataRowView["DateOfBirth"]).ToString();
            string gender = (dataRowView["Gender"]).ToString();
            string homeAddress = (dataRowView["HomeAddress"]).ToString();

            txtEditEmployeeId.Text = id;
            txtEditName.Text = name;
            txtEditSurname.Text = surname;
            dpEditDateOfBirth.Text = dateOfBirth;
            cboEditGender.Text = gender;
            txtEditHomeAddress.Text = homeAddress;
        }



        private void txtEmployeeSearch(object sender, KeyEventArgs e)
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = ConfigurationManager.ConnectionStrings["employeeConnection"].ConnectionString;
            con.Open();

            try
            {
                btnShowAdd.IsEnabled = false;
                  SqlCommand cmd = new SqlCommand();

                cmd.CommandText = "SELECT * FROM Employee WHERE Name LIKE'" + "%" + txtSearchEmployeee.Text.ToString() + "%" + "' OR Surname LIKE '" + "%" + txtSearchEmployeee.Text.ToString() + "%" + "' OR HomeAddress LIKE '" + "%" + txtSearchEmployeee.Text.ToString() + "%" + "' ";

                cmd.Connection = con;
                cmd.ExecuteNonQuery();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                dt = new DataTable("employee");
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
    }
}