﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeCatalogue3
{
    class EmployeeModel
    {

        private int employeeId;
        private string name;
        private string surname;
        private string dateOfBirth;
        private string gender;
        private string homeAddress;

        public int EmployeeId
        {
            get;
            set;
        }

        public string Name
        {
            get;
            set;
        }

        public string Surname
        {
            get;
            set;
        }


        public DateTime DateOfBirth
        {
            get;
            set;
        }


        public string Gender
        {
            get;
            set;
        }
        public string HomeAddress
        {
            get;
            set;

        }
    




        /*
         * 
         * 
        public string Name
        {
            get => this.name;
            set
            {
                if (name == value) // check if value changed
                    return; // do nothing if value same

                name = value; // change value
                OnPropertyChanged("name"); // pass changed property name
            }
        }

        public string Surname
        {
            get => this.surname;
            set
            {
                if (surname == value) // check if value changed
                    return; // do nothing if value same

                surname = value; // change value
                OnPropertyChanged("surname"); // pass changed property name
            }
        }

        public string DateOfBirth
        {
            get => this.dateOfBirth;
            set
            {
                if (dateOfBirth == value) // check if value changed
                    return; // do nothing if value same

                dateOfBirth = value; // change value
                OnPropertyChanged("dateOfBirth"); // pass changed property name
            }
        }

        public string Gender
        {
            get => this.gender;
            set
            {
                if (gender == value) // check if value changed
                    return; // do nothing if value same

                gender = value; // change value
                OnPropertyChanged("gender"); // pass changed property name
            }
        }

        /*
       public enum Gender
        {
            Male,
            Female
        }
        

        public string HomeAddress
        {
            get => this.homeAddress;
            set
            {
                if (homeAddress == value) // check if value changed
                    return; // do nothing if value same

                homeAddress = value; // change value
                OnPropertyChanged("homeAddress"); // pass changed property name
            }
        }



        public event PropertyChangedEventHandler PropertyChanged;
        // this method raises PropertyChanged event
        protected void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null) // if there is any subscribers 
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }




         */
    }
}