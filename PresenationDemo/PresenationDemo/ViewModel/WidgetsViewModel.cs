using System;
using System.Collections.Generic;
using System.Windows.Input;
using System.Net.Http;
using Newtonsoft.Json;
using System.Text;
using System.Collections.ObjectModel;

namespace PresenationDemo
{
	public class WidgetsViewModel : BaseViewModel
	{
		ObservableCollection<Widget> _widgetList = new ObservableCollection<Widget> ();

		public ObservableCollection<Widget> WidgetList {
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
				return new DelegateCommand (CanGetWidgets, async t => {
					using (var client = new HttpClient ()) {
						client.BaseAddress = App.WidgetService;
						client.DefaultRequestHeaders.Add ("Auth", App.TokenBag.Token.ToString ());
						var response = await client.PostAsync ("Widget/", null);
						if (response.IsSuccessStatusCode) {
							var content = await response.Content.ReadAsStringAsync ();

							WidgetList.Clear ();

							var lst = JsonConvert.DeserializeObject<ObservableCollection<Widget>> (content);
							foreach (var item in lst) {
								WidgetList.Add (item);
							}
							await _Navigation.DisplayAlert ("Widgets", "success", "Widget World");
						}
					}
				});
			}
		}

		public bool CanGetWidgets (object obj)
		{
			return true;
		}
	}
}
