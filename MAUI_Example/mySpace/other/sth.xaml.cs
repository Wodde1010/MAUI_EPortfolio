using System;
using System.Collections.Generic;
using Microsoft.Maui;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Controls.Xaml;
using System.Threading.Tasks;
using System.Threading;

namespace Example1
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class sth : ContentPage, IPage
	{
		private bool shouldRun = false;
		public sth()
		{
			this.View = new myView();
			InitializeComponent();
		}
		private void startGame(object sender, EventArgs e){
			setBtnStateDependingOnState(false);
			//start simulation of Snake - call async runGame() function
			runGameAsync();
		}
		private void pauseGame(object sender, EventArgs e){
			setBtnStateDependingOnState(true);
			//await end of runGameAsync() function
		}

		private void setBtnStateDependingOnState(bool shouldPause){
			BtnStartGame.IsVisible = shouldPause;
			BtnStartGame.IsEnabled = shouldPause;		
		//	BtnStartGame.Arrange(new Rectangle(){Width=0,Height=0});	
			shouldRun = !shouldPause;
			BtnPauseGame.IsVisible = !shouldPause;
			BtnPauseGame.IsEnabled = !shouldPause;
		}


		private async void runGameAsync(){
			int count = 0;
			Task.Run(()=>{
				while(shouldRun){
					TempOutput2.Text = count.ToString();
					++count;
					Thread.Sleep(200);
					if(count%2==0)
						//View.thisCount = "now even";
						count = count;
					else
						//View.thisCount = "now uneven";
						count = count;
				}
			});
		}



		private void runGameSameThread(){
			//Sample and show why it won't work (app is single threaded per default - gui interaction and code behind by same thread executed)
			//no input accessible => loop won't ever finish
			int count = 0;
			while(shouldRun){
				TempOutput2.Text = count.ToString();
				++count;
				Thread.Sleep(200);
			}
		}


		private void changeDirection(object sender, EventArgs e){		
			//set Snake.Direction to the new value depending on sender.Name
			Button btn = (Button)sender;

			TempOutput.Text = btn.Id.ToString();
			//TempOutput2.Text = btn.AutomationId;
			string newDirection = "";
		}

		public IView View { get => (IView)Content; set => Content = (View)value; }
	}

	public class myView : View{
		private string count = "some nice val";
		public string thisCount{get {return count;} set {count = value;}}
	}
}
