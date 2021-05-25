using System;
using System.Collections.Generic;
using Microsoft.Maui;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Controls.Xaml;

namespace Example1
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Calc : ContentPage, IPage
	{
		public Calc()
		{
			InitializeComponent();
            num1.Text="1.12";
            num2.Text="3.25";
		}

		private uint counter = 0;

        private void add(object sender, EventArgs e){
            double numberOne;
            double numberTwo;
            
            
            result.Text="";
            bool success1 = double.TryParse(num1.Text, out numberOne);
            if(!success1)
                result.Text += "1-";
            bool success2 = double.TryParse(num2.Text, out numberTwo);
            if(!success2)
                result.Text += "2-";
            bool success3 = double.TryParse(((Editor)num1).Text, out numberOne);
            if(!success3)
                result.Text += "3-";
            bool success4 = double.TryParse(((Editor)num2).Text, out numberTwo);
            if(!success4)
                result.Text += "4-";

            if(!success1 || !success2 || !success3 || !success4)
            {
                result.Text += "Failure";
                return;
            }
            ++counter;
            result.Text = (numberOne+numberTwo).ToString() + "; " + counter.ToString();
        }

		public IView View { get => (IView)Content; set => Content = (View)value; }
	}
}
