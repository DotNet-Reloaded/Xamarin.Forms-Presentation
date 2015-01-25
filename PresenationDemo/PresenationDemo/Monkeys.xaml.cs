using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace PresenationDemo
{
	public partial class Monkeys : ContentPage
	{
		public Monkeys (INavigationService navigation)
		{
			InitializeComponent ();
			BindingContext = new LoginViewModel (navigation);
		}
	}
}

