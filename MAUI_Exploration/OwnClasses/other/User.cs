using System;
using Microsoft.Maui;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Controls.Xaml;




namespace Example1{

    public class User{
        public User(){
            firstName="";
            lastName="";
            birthday= DateTime.MinValue;
        }   

        private string firstName;
        public string FirstName
        {
            get { return firstName; }
            set { firstName = value; }
        }
        private string lastName;
        public string LastName
        {
            get { return lastName; }
            set { lastName = value; }
        }
        
        private DateTime birthday;
        public DateTime Birthday
        {
            get { return birthday; }
            set { birthday = value; }
        }
        

        private string phoneNumber;
        public string PhoneNumber
        {
            get { return phoneNumber; }
            set { phoneNumber = value; }
        }
    }
}