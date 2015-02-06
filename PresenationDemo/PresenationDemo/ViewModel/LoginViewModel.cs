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

		string _Username;
		string _Password;
		bool _IsNotLoggingIn = true;

		public string Username {
			get { return _Username; }
			set {
				_Username = value; 
				OnPropertyChanged ("Username");
			}
		}

		public string Password { 
			get { return _Password; }
			set {
				_Password = value; 
				OnPropertyChanged ("Password");
			}
		}

		public bool IsNotLoggingIn {
			get{ return _IsNotLoggingIn; }
			set {
				_IsNotLoggingIn = value;
				OnPropertyChanged ("IsNotLoggingIn");
			}
		}

		#endregion

		public LoginViewModel (INavigationService navigation) : base (navigation)
		{
		}

		public ICommand DoLogin { 
			get {
				return new DelegateCommand (CanLogin, async t => {
					IsNotLoggingIn = false;
					await System.Threading.Tasks.Task.Delay (1000);
					using (var client = new HttpClient ()) {
						client.BaseAddress = App.WidgetService;

						var str = JsonConvert.SerializeObject (new { username = _Username, password = _Password });
						var content = new StringContent (str, Encoding.UTF8, "application/json");

						var response = await client.PostAsync ("Auth/", content);
						if (response.IsSuccessStatusCode) {
							var token = await response.Content.ReadAsStringAsync ();
							App.TokenBag = JsonConvert.DeserializeObject<TokenBag> (token);
							var success = string.Format ("You succesfully logged in!!{0}Auth Token:{1}{2}", Environment.NewLine, Environment.NewLine, token);
							await _Navigation.DisplayAlert ("Login", success, "Enter Widget World");
							await _Navigation.PushAsync (new Widgets (_Navigation));
							IsNotLoggingIn = true;
							return;
						}
					}

					IsNotLoggingIn = true;
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

