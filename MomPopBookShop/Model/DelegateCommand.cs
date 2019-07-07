using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MomPopBookShop.Model
{
	//Based on MVVM Sample Using DataGrid Control in WPF found: https://wpftution.blogspot.com/2012/05/mvvm-sample-using-datagrid-control-in.html

	public class DelegateCommand : ICommand
	{

		Predicate<object> canExecute;
		Action<object> execute;

		public DelegateCommand(Predicate<object> _canexecute, Action<object> _execute)
			: this()
		{
			canExecute = _canexecute;
			execute = _execute;
		}

		public DelegateCommand()
		{

		}

		public bool CanExecute(object parameter)
		{
			return canExecute == null ? true : canExecute(parameter);
		}

		public event EventHandler CanExecuteChanged;

		//The function to execute
		public void Execute(object parameter)
		{
			execute(parameter);
		}
	}
}
