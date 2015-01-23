using System;
using System.ComponentModel;

namespace PresenationDemo
{
	public class BaseViewModel : INotifyPropertyChanged
	{
		public event PropertyChangedEventHandler PropertyChanged;

		public void OnPropertyChanged (string name)
		{
			if (PropertyChanged == null) {
				return;
			}

			PropertyChanged (this, new PropertyChangedEventArgs (name));
		}
	}
}

