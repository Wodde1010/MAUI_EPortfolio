using Microsoft.Maui;

namespace Example1
{
	public class MainWindow : IWindow
	{
		public MainWindow()
		{
			//	Page = new AddContactSite();
			//	Page = new WelcomePage();
			// Page = new Calc();


			// Page = new SnakePage();
			//	Page = new testing();
			Page = new SnakePage();

			//snake
			//music - android music player intregatable
			//Taschenrechner mit Buttons als Felder
			//tic tac toe
			//timer
		}

		public IPage Page { get; set; }

		public IMauiContext MauiContext { get; set; }
	}
}