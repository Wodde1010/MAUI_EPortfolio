using System;
using System.Collections.Generic;
using Microsoft.Maui;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Controls.Xaml;
using Microsoft;
  
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Diagnostics;
using Microsoft.Extensions.Configuration;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;


namespace Example1
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class testing : ContentPage, IPage
    {
		Binder myContext;

		public testing(){
			InitializeComponent();
			myContext = new Binder();
			BindingContext = myContext;
			buff[0] = "first";
			buff[1] = "sec";
			buff[2] = "3";
			BindingContextChanged += changedContext;
		}
		private string[] buff = new string[3];
		private int count = 0;

		private void changeBoundValue(object sender, EventArgs e){
			myContext.myBoundText = buff[count%3];
			OnPropertyChanging("myContext.myBoundText");
			OnPropertyChanged("myContext.myBoundText");
			OnPropertyChanged("myBoundText");
			++count;
			Out.Text = myContext.myBoundText.Length.ToString();
			OnBindingContextChanged();
			BindingContext = null;
			OnBindingContextChanged();
			BindingContext = myContext;
			OnBindingContextChanged();
		}
		private void changedContext(object sender, EventArgs e){
			Out2.Text = count.ToString();
		}
		public event PropertyChangedEventHandler PropertyChanged;
        public virtual void OnPropertyChanged([CallerMemberName] string propertyName = null) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

		public IView View { get => (IView)Content; set => Content = (View)value; }
	}

	class Binder {
		private string text="some bound text";
		public string myBoundText {get {return text;} set {text=value; OnPropertyChanged("myBoundText"); }}
		public event PropertyChangedEventHandler PropertyChanged;
        public virtual void OnPropertyChanged([CallerMemberName] string propertyName = null) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
	}
}