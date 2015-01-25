using System;
using System.Windows.Input;
using Xamarin.Forms;
using System.Threading.Tasks;

namespace PresenationDemo
{
	public class LoginViewModel : BaseViewModel
	{
		#region Properties

		string _username;
		string _password;
		Guid _token;

		public string Username {
			get { return _username; }
			set {
				_username = value; 
				OnPropertyChanged ("username");
			}
		}

		public string Password { 
			get { return _password; }
			set {
				_password = value; 
				OnPropertyChanged ("password");
			}
		}

		public Guid Token { 
			get { return _token; }
			set {
				_token = value; 
				OnPropertyChanged ("token");
			}
		}

		#endregion

		public LoginViewModel (INavigationService navigation) : base (navigation)
		{
		}

		public ICommand DoLogin { 
			get {
				return new DelegateCommand (CanLogin, async t => {
					await _Navigation.DisplayAlert ("Login", "You succesfully logged in", "Enter Monkey Island");
					await _Navigation.PushAsync (new Monkeys (_Navigation));
				});
//				return new DelegateCommand (CanLogin, OnLogin);
			}
		}

		public bool CanLogin (object obj)
		{
			return true;
		}

		//		public void OnLogin (object obj)
		//		{
		//			_Navigation.DisplayAlert ("Login", "You succesfully logged in", "Enter Monkey Island");
		//			_Navigation.PushAsync (new Monkeys (_Navigation));
		//		}
	}
}

