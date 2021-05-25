using System;
using Microsoft.Maui;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Controls.Xaml;

namespace LiveMauiDemo
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class MainPage : ContentPage, IPage
	{
		public MainPage()
		{
			SnakeViewModel myViewModel = new SnakeViewModel();
			BindingContext = myViewModel;
			InitializeComponent();
		}

		public IView View { get => (IView)Content; set => Content = (View)value; }
	}
}
