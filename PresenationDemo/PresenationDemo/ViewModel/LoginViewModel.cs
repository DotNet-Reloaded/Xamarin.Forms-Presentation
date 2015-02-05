using System;
using System.Windows.Input;
using System.Net.Http;
using Newtonsoft.Json;
using System.Text;

namespace PresenationDemo
{
	public class LoginViewModel : BaseViewModel
	{
		#region Properties

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

		#endregion

		public LoginViewModel (INavigationService navigation) : base (navigation)
		{
		}

		public ICommand DoLogin { 
			get {
				return new DelegateCommand (CanLogin, async t => {
					using (var client = new HttpClient ()) {
						client.BaseAddress = new Uri ("http://widgetservice.azurewebsites.net/api/");

						var str = JsonConvert.SerializeObject (new { username = _username, password = _password });
						var content = new StringContent (str, Encoding.UTF8, "application/json");

						var response = await client.PostAsync ("Auth/", content);
						if (response.IsSuccessStatusCode) {
							var token = await response.Content.ReadAsStringAsync ();
							var success = string.Format ("You succesfully logged in!!{0}Auth Token:{1}{2}", Environment.NewLine, Environment.NewLine, token);
							await _Navigation.DisplayAlert ("Login", success, "Enter Widget World");
							await _Navigation.PushAsync (new Widgets (_Navigation));
							return;
						}
					}

					await _Navigation.DisplayAlert ("Login Failed", "Please Verify your username and password", "Try Again");
				});
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

