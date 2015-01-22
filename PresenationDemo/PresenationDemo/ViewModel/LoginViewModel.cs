using System;

namespace PresenationDemo
{
	public class LoginViewModel : BaseViewModel
	{
		string _username;
		string _password;

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

		public Guid Token { get; set; }
	}
}

