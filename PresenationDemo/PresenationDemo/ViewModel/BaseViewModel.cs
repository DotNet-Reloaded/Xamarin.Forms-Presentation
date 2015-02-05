using System;
using System.ComponentModel;
using Xamarin.Forms;
using System.Windows.Input;

namespace PresenationDemo
{
	public class BaseViewModel : INotifyPropertyChanged
	{
		internal readonly INavigationService _Navigation;

		public BaseViewModel (INavigationService navigation)
		{
			_Navigation = navigation;
		}

		//		public ICommand GoToLoginPageCommand {
		//			get { return new DelegateCommand (() => _Navigation.PushAsync (App.LoginPage)); }
		//		}

		#region INotifyPropertyChanged

		public event PropertyChangedEventHandler PropertyChanged;

		public void OnPropertyChanged (string name)
		{
			if (PropertyChanged == null) {
				return;
			}

			PropertyChanged (this, new PropertyChangedEventArgs (name));
		}

		#endregion
	}
}

