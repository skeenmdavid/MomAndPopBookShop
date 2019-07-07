using MomPopBookShop.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace MomPopBookShop.ViewModel
{
	public class InventoryViewModel : ViewModelBase
	{
		//Build initial inventory
		public InventoryViewModel()
		{
			//On change to persistant data source, _inventory would be set to be equivalent to a SELCT * FROM Table statement
			_inventory = new ObservableCollection<Book>();
			_inventory.Add(new Book
			{
				Isbn = 1,
				Title = "Introduction to Algorithms",
				Author = "Thomas H. Cormen",
				Genre = "TextBook",
				NumberInStock = 3
			});
			_inventory.Add(new Book
			{
				Isbn = 2,
				Title = "The Fellowship of The Ring",
				Author = "JRR Tolkein",
				Genre = "Fantasy",
				NumberInStock = 3
			});
			_inventory.Add(new Book
			{
				Isbn = 3,
				Title = "The Two Towers",
				Author = "JRR Tolkein",
				Genre = "Fantasy",
				NumberInStock = 3
			});
		}
		
		//Setup necessary collection
		private ObservableCollection<Book> _inventory;
		private ObservableCollection<Book> tempInventory;
		public ObservableCollection<Book> inventory
		{
			get { return _inventory; }
			set
			{
				_inventory = value;
				NotifyPropertyChanged("InventoryUpdated");
			}
		}

		//Book for adding new books
		private Book _newBook = new Book();
		public Book newBook
		{
			get
			{
				return _newBook;
			}
			set
			{
				_newBook = value;
				NotifyPropertyChanged("NewBookAdded");
			}
		}

		//Create SearchPhrase
		private string searchPhrase = "";
		public string SearchPhrase
		{
			get
			{
				return searchPhrase;
			}
			set
			{
				searchPhrase = value;
				NotifyPropertyChanged("NewSearchPhrase");
			}
		}

		//Based on MVVM Sample Using DataGrid Control in WPF found: https://wpftution.blogspot.com/2012/05/mvvm-sample-using-datagrid-control-in.html
		ICommand _Removecommand;
		ICommand _Updatecommand;
		ICommand _Addcommand;
		ICommand _SearchCommand;
		public ICommand RemoveCommand
		{
			get
			{
				if (_Removecommand == null)
				{
					_Removecommand = new DelegateCommand(CanExecute, ExecuteRemoval);
				}
				return _Removecommand;
			}
		}

		public ICommand UpdateCommand
		{
			get
			{
				if (_Updatecommand == null)
				{
					_Updatecommand = new DelegateCommand(CanExecute, ExecuteUpdate);
				}
				return _Updatecommand;
			}
		}

		public ICommand AddCommand
		{
			get
			{
				if (_Addcommand == null)
				{
					_Addcommand = new DelegateCommand(CanExecute, ExecuteAdd);
				}
				return _Addcommand;
			}
		}

		public ICommand SearchCommand
		{
			get
			{
				if(_SearchCommand == null)
				{
					_SearchCommand = new DelegateCommand(CanExecute, ExecuteSearch);
				}
				return _SearchCommand;
			}
		}

		//To change to persistant data source. Would initially need a DataConnection Model

		//This function would be changed to insert into a DB table.
		private void ExecuteAdd(object paramater)
		{
			var InvCheck = inventory.Where(x => x.Isbn == newBook.Isbn).ToList();
			if (InvCheck.Count > 0)
			{
				MessageBox.Show("A book with the corresponding Isbn already exists in the inventory. Please find it and update the stock count.");
			}
			else
			{
				inventory.Add(newBook);
				tempInventory = inventory;
				MessageBox.Show("Book has been added");
			}
		}

		//This function would be changed to remove a row from a table in the db
		private void ExecuteRemoval(object parameter)
		{
			var book = parameter as Book;
			if (inventory.Contains(book))
			{
				inventory.Remove(book);
				tempInventory = inventory;
				MessageBox.Show("Book has been removed");
			}

		}

		//This function would be made to execute an update
		private void ExecuteUpdate(object parameter)
		{
			var book = parameter as Book;
			var currentbook = inventory.Where(x => x.Isbn == book.Isbn).First();
			inventory[inventory.IndexOf(currentbook)] = book;
			tempInventory = inventory;
			MessageBox.Show("Update Complete");
		}

		//This would be made to execute a basic select
		private void ExecuteSearch(object parameter)
		{
			//Return full inventory
			if(SearchPhrase == "*" || SearchPhrase == "")
			{
				inventory = tempInventory;
			}
			else
			{
				inventory = tempInventory;
				inventory = new ObservableCollection<Book>(inventory.Where(x => x.Title == searchPhrase || x.Author == searchPhrase || x.Genre == searchPhrase));
			}

		}
		

		private bool CanExecute(object parameter)
		{
			//Should be some error checking in here to approve that it can execute
			return true;
		}
	}
}
