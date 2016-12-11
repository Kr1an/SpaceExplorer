using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using SObjectRepository.Repository.SObjectModel.Utils;
using SObjectRepository.Repository.SObjectModel;
using SObjectRepository.Repository.ChainCollection;
using SObjectApplication.Repository.SObjectApplicationSaveHelper;
using System.IO;

namespace SObjectApplication
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	
	public partial class MainWindow : Window
	{
		public MainWindow rootElement;
		public MainWindow()
		{
			Storage.StorageRead();
			rootElement = this;
			InitializeComponent();
		}
		public MainWindow(MainWindow rootElement)
		{
			this.rootElement = rootElement;
			InitializeComponent();
			
		}




		private void btnLibrary_MouseUp(object sender, MouseButtonEventArgs e)
		{
			rootElement.Content = new Library(rootElement).Content;
			
		}
		private void btnAdd_MouseUp(object sender, MouseButtonEventArgs e)
		{
			rootElement.Content = new Add(rootElement).Content;
		}

		private void name_text_TextChanged(object sender, TextChangedEventArgs e)
		{

		}

		private void btn_Exit_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
		{
			Storage.StorageWrite();
			Application.Current.Shutdown();
		}

	private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
		{
		}
	}
}
