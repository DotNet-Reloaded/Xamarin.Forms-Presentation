using System;
using System.Windows.Input;

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

		public ICommand DoLogin { get; set; }

		#endregion

		public LoginViewModel ()
		{
			DoLogin = new DelegateCommand (CanLogin, OnLogin);
		}

		public bool CanLogin (object obj)
		{
			return true;
		}

		public void OnLogin (object obj)
		{
			if (CanLogin (null)) {
				return;
			}
		}
	}
}

