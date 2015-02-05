using System;
using System.Collections.Generic;
using System.Windows.Input;
using System.Net.Http;
using Newtonsoft.Json;
using System.Text;

namespace PresenationDemo
{
	public class WidgetsViewModel : BaseViewModel
	{
		List<Widget> _widgetList;

		public List<Widget> WidgetList {
			get { return _widgetList; }
			set {
				_widgetList = value; 
				OnPropertyChanged ("widgetList");
			}
		}

		public WidgetsViewModel (INavigationService navigation) : base (navigation)
		{
		}

		public ICommand GetWidgets { 
			get {
				return new DelegateCommand (CanLogin, async t => {
					using (var client = new HttpClient ()) {
						client.BaseAddress = App.WidgetService;
						client.DefaultRequestHeaders.Add ("Auth", App.TokenBag.Token.ToString ());
						var response = await client.PostAsync ("Widget/", null);
						if (response.IsSuccessStatusCode) {
							var content = await response.Content.ReadAsStringAsync ();
							WidgetList = JsonConvert.DeserializeObject<List<Widget>> (content);
						}
					}
				});
			}
		}

		public bool CanLogin (object obj)
		{
			return true;
		}

	}
}

