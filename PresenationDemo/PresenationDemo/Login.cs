using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace PresenationDemo
{
	public partial class Login : ContentPage
	{
		public Login ()
		{
			InitializeComponent ();
		}

		async void OnButtonClicked (object sender, EventArgs args)
		{
			await DisplayAlert ("Login", "You succesfully logged in", "Enter Monkey Island");
			await Navigation.PushAsync (new Monkeys ());
		}
	}
}

