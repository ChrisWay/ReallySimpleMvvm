using System;
using System.Windows.Input;

namespace ReallySimpleMvvm
{
	public abstract class SimpleCommandBase : ICommand
	{
		private readonly Action<object> _execute;
		private readonly Func<object, bool> _canExecute;

		protected SimpleCommandBase(Action<object> execute, Func<object, bool> canExecute)
		{
			_execute = execute;
			_canExecute = canExecute;
		}

		protected SimpleCommandBase(Action<object> execute)
			: this(execute, o => true)
		{
		}

		public bool CanExecute(object parameter)
		{
			return _canExecute == null || _canExecute(parameter);
		}

		public void RaiseCanExecuteChanged()
		{
			var handler = CanExecuteChanged;
			if (handler != null)
				handler(this, EventArgs.Empty);
		}

		public event EventHandler CanExecuteChanged;

		public void Execute(object parameter)
		{
			_execute(parameter);
		}
	}

	public class SimpleCommand<T> : SimpleCommandBase
	{
		public SimpleCommand(Action<T> execute, Func<T, bool> canExecute)
			: base(o => execute((T)o), o => canExecute((T)o))
		{
		}

		public SimpleCommand(Action<T> execute)
			: base(o => execute((T)o))
		{
		}
	}

	public class SimpleCommand : SimpleCommandBase
	{
		public SimpleCommand(Action execute, Func<bool> canExecute)
			: base(o => execute(), o => canExecute())
		{
		}

		public SimpleCommand(Action execute)
			: base(o => execute())
		{
		}
	}
}