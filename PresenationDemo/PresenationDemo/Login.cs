using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace PresenationDemo
{
	public partial class Login : ContentPage
	{
		public Login (INavigationService navigation)
		{
			InitializeComponent (); 
			BindingContext = new LoginViewModel (navigation);
		}
	}
}

