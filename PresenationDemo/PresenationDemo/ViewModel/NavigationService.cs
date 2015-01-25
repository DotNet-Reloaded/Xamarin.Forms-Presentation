using System;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace PresenationDemo
{
	public class NavigationService : INavigationService
	{
		#region Public Properties

		public INavigation Navigation { get; internal set; }

		public Page CurrentPage { get; set; }

		#endregion

		#region INavigation

		public void RemovePage (Page page)
		{
			Navigation.RemovePage (page);
		}

		public void InsertPageBefore (Page page, Page before)
		{
			Navigation.InsertPageBefore (page, before);
		}

		public Task PushAsync (Page page)
		{
			return Navigation.PushAsync (page);
		}

		public Task<Page> PopAsync ()
		{
			return Navigation.PopAsync ();
		}

		public Task PopToRootAsync ()
		{
			return Navigation.PopToRootAsync ();
		}

		public Task PushModalAsync (Page page)
		{
			return Navigation.PushModalAsync (page);
		}

		public Task<Page> PopModalAsync ()
		{
			return Navigation.PopModalAsync ();
		}

		public Task PushAsync (Page page, bool animated)
		{
			return Navigation.PushAsync (page, animated);
		}

		public Task<Page> PopAsync (bool animated)
		{
			return Navigation.PopAsync (animated);
		}

		public Task PopToRootAsync (bool animated)
		{
			return Navigation.PopToRootAsync (animated);
		}

		public Task PushModalAsync (Page page, bool animated)
		{
			return Navigation.PushModalAsync (page, animated);
		}

		public Task<Page> PopModalAsync (bool animated)
		{
			return Navigation.PopModalAsync (animated);
		}

		public System.Collections.Generic.IReadOnlyList<Page> NavigationStack {
			get {
				return Navigation.NavigationStack;
			}
		}

		public System.Collections.Generic.IReadOnlyList<Page> ModalStack {
			get {
				return Navigation.ModalStack;
			}
		}

		#endregion

		#region INavigationService

		public Task DisplayAlert (string title, string message, string cancel)
		{
			return CurrentPage.DisplayAlert (title, message, cancel);
		}

		public Task<bool> DisplayAlert (string title, string message, string accept, string cancel)
		{
			return CurrentPage.DisplayAlert (title, message, accept, cancel);
		}

		#endregion
	}
}

