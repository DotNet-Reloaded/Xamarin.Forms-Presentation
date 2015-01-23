using System;
using System.Windows.Input;

namespace PresenationDemo
{
	public class DelegateCommand : ICommand
	{
		Predicate<object> _canExecute { get; set; }

		Action<object> _execute { get; set; }

		public DelegateCommand (Predicate<object> canExecute, Action<object> execute)
		{
			_canExecute = canExecute;
			_execute = execute;
		}

		#region ICommand implementation

		public event EventHandler CanExecuteChanged;

		public bool CanExecute (object parameter)
		{
			return _canExecute == null || _canExecute (parameter);
		}

		public void Execute (object parameter)
		{
			if (_execute != null)
				_execute (parameter);
		}

		#endregion
	}
}

