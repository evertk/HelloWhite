using System;
using System.ComponentModel;
using System.Threading;
using System.Windows.Input;

namespace HelloWhite
{
	class MainVM : INotifyPropertyChanged
	{
		private bool mCanExecute;
		public MainVM()
		{
			mCanExecute = true;
		}

		#region Start Command

		private ICommand mStartCommand;
		public ICommand StartCommand
		{
			get
			{
				return mStartCommand ?? (mStartCommand = new CommandHandler(() => StartAction(), mCanExecute));
			}
		}

		public void StartAction()
		{
			Thread.Sleep(3000);
			TaskText = "Task Finished!";
		}

		#endregion Start Command

		private string mTaskText;

		public event PropertyChangedEventHandler PropertyChanged;

		public string TaskText
		{
			get { return mTaskText; }
			set
			{
				mTaskText = value;
				OnPropertyChanged("TaskText");
			}
		}

		// Raise the propchanged event.
		protected void OnPropertyChanged(string name)
		{
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
		}

	}
}

public class CommandHandler : ICommand
{
	private Action _action;
	private bool _canExecute;
	public CommandHandler(Action action, bool canExecute)
	{
		_action = action;
		_canExecute = canExecute;
	}

	public bool CanExecute(object parameter)
	{
		return _canExecute;
	}

	public event EventHandler CanExecuteChanged;

	public void Execute(object parameter)
	{
		_action();
	}
}