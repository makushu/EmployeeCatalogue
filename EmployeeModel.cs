using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeCatalogue3
{

    class EmployeeModel
    {
        public class Employee : INotifyPropertyChanged
        {
            private string id;
            private string name;
            private string surname;
            private string dateOfBirth;
            private string gender;
            private string homeAddress;

            public string Id
            {
                get { return id; }
                set
                {
                    id = value;
                    RaisePropertyChanged("id");
                }
            }
            public string Name
            {
                get { return name; }
                set
                {
                    name = value;
                    RaisePropertyChanged("name");
                }
            }

            public string Surname
            {
                get { return surname; }
                set
                {
                    surname = value;
                    RaisePropertyChanged("surname");
                }
            }

            public string DateOfBirth
            {
                get { return dateOfBirth; }
                set
                {
                    dateOfBirth = value;
                    RaisePropertyChanged("dateOfBirth");
                }
            }

            public string Gender
            {
                get { return gender; }
                set
                {
                    gender = value;
                    RaisePropertyChanged("gender");
                }
            }

            public string HomeAddress
            {
                get { return homeAddress; }
                set
                {
                    homeAddress = value;
                    RaisePropertyChanged("homeAddress");
                }
            }
            public event PropertyChangedEventHandler PropertyChanged;

            public void RaisePropertyChanged(string propertyName)
            {
                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
                }
            }
        }
    }

}