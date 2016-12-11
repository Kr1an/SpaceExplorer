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
using System.Windows.Shapes;
using SObjectApplication.Views.LibraryList;

namespace SObjectApplication
{
	/// <summary>
	/// Interaction logic for Library.xaml
	/// </summary>
	public partial class Library : Window
	{
		private MainWindow rootElement;
		public Library(MainWindow rootElement)
		{
			this.rootElement = rootElement;
			InitializeComponent();
		}


		private void BackToMainWindow()
		{
			rootElement.Content = new MainWindow(rootElement).Content;
		}

		private void imgBack_MouseUp(object sender, MouseButtonEventArgs e)
		{
			BackToMainWindow();
		}

		private void btnListCon_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
		{
			rootElement.Content = new ListConstellation(rootElement).Content;
		}
		private void btnListStar_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
		{
			rootElement.Content = new ListStar(rootElement).Content;
		}
		private void btnListPlanet_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
		{
			
			rootElement.Content = new ListPlanet(rootElement).Content;
		}
	}
}
