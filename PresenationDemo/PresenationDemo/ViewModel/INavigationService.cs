using System;
using Xamarin.Forms;
using System.Threading.Tasks;

namespace PresenationDemo
{
	public interface INavigationService : INavigation
	{
		Task DisplayAlert (string title, string message, string cancel);

		Task<bool> DisplayAlert (string title, string message, string accept, string cancel);
	}
}

