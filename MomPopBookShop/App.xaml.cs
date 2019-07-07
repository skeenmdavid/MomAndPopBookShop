using MomPopBookShop.ViewModel;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace MomPopBookShop
{
	/// <summary>
	/// Interaction logic for App.xaml
	/// </summary>
	public partial class App : Application
	{
		protected override void OnStartup(StartupEventArgs e)
		{
			base.OnStartup(e);
			MomPopBookShop.MainWindow window = new MainWindow();
			window.DataContext = new InventoryViewModel();
			window.Show();
		}
	}
}
