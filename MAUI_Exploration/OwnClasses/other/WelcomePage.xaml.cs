using System;
using System.Collections.Generic;
using Microsoft.Maui;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Controls.Xaml;
using System.Threading.Tasks;

namespace Example1
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class WelcomePage : ContentPage, IPage
	{
		public WelcomePage()
		{
			InitializeComponent();
		}
		private uint counter = 0;
		private void MyBasicClickEvent(object sender, EventArgs e){
			//some stuff			
			Dialogs myDialogs = new Dialogs();
			string myOption = myDialogs.getOption(counter);
			++counter;
			myOutput.Text = myOption;		
		}


		private void checkControls(){
					Grid myGrid = new Grid();
					myGrid.IsVisible=false;
				DatePicker mypicker = new DatePicker();
				mypicker.Date = DateTime.MinValue;
		}

		private void checkHandler(object sender, EventArgs e){
			try{
				if(((CheckBox)sender).IsChecked)
					rememberOutput.Text = "You will be remembered.";
				else
					rememberOutput.Text = "You won't be remembered.";

			}catch{}
		}

		private void updateRating(object sender, EventArgs e){
			PleaseRate.Text = "Thank you.";
			double myValue = (double) Rate.Value;
			int formattedValue = (int) (myValue*100);
			YourRating.Text = formattedValue.ToString();
		}

		public IView View { get => (IView)Content; set => Content = (View)value; }
	}
}
