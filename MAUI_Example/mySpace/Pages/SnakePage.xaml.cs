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
	public partial class SnakePage : ContentPage, IPage
	{
		SnakeModel mySnakeModel;
		public SnakePage()
		{
			mySnakeModel = new SnakeModel();
			BindingContext = mySnakeModel;
			InitializeComponent();
		}
		public IView View { get => (IView)Content; set => Content = (View)value; }
	}
}
