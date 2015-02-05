using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace PresenationDemo
{
	public partial class Widgets : ContentPage
	{
		public Widgets (INavigationService navigation)
		{
			InitializeComponent ();
			BindingContext = new LoginViewModel (navigation);
		}
	}
}

