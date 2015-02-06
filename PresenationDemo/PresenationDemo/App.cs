using System;

using Xamarin.Forms;

namespace PresenationDemo
{
	public class App :Application
	{
        private static NavigationService nav = new NavigationService();
		public static Uri WidgetService {
			get {
				return new Uri ("http://widgetservice.azurewebsites.net/api/");
			}
		}

		public static TokenBag TokenBag { get; set; }

        public App ()
        {
            MainPage = new NavigationPage (new Login (nav));

            nav.Navigation = MainPage.Navigation;
            nav.CurrentPage = MainPage;
        }

		protected override void OnStart ()
		{
			// Handle when your app starts
		}

		protected override void OnSleep ()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume ()
		{
			// Handle when your app resumes
		}

        public static ContentPage GetMainPage()
        {
            return null;
        }
            
	}
}

