using System;
using Microsoft.Maui;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Controls.Xaml;
using System.Collections.Generic;

namespace Example1
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class AddContactSite : ContentPage, IPage
	{
		public AddContactSite()
		{
			InitializeComponent();
		}

        List<User> contactList = new List<User>();

        private void saveNewUser(object sender, EventArgs e){
            //write values to user instance
            User newUser = new User();
            newUser.Birthday = birthdayDatePicker.Date;
            newUser.PhoneNumber = phonenumberField.Text;
            newUser.FirstName = firstNameField.Text;
            newUser.LastName = surNameField.Text;

            //save user instance to list
            contactList.Add(newUser);
            userAmount.Text = contactList.Count.ToString();
        }

		public IView View { get => (IView)Content; set => Content = (View)value; }
	}
}
