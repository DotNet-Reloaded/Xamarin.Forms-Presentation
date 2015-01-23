using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace PresenationDemo
{
	public partial class Login : ContentPage
	{
		LoginViewModel _LoginViewModel = new LoginViewModel ();

		public Login ()
		{
			InitializeComponent (); 
			BindingContext = _LoginViewModel;
		}

		async void OnButtonClicked (object sender, EventArgs args)
		{
			await DisplayAlert ("Login", "You succesfully logged in", "Enter Monkey Island");
			await Navigation.PushAsync (new Monkeys ());
		}
	}
}

