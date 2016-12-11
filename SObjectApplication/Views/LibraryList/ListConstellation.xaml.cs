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
using SObjectRepository.Repository.SObjectModel;
using SObjectRepository.Repository.SObjectModel.Utils;
using System.Collections;
using System.ComponentModel;
using System.Collections.ObjectModel;
using SObjectApplication.Views.LibraryList.AddConstellation.Change;

namespace SObjectApplication.Views.LibraryList
{
	/// <summary>
	/// Interaction logic for ListConstellation.xaml
	/// </summary>
	public partial class ListConstellation : Window
	{
		GridViewColumnHeader _lastHeaderClicked = null;
		ListSortDirection _lastDirection = ListSortDirection.Ascending;

		private MainWindow rootElement;

		public ListConstellation( MainWindow rootElement)
		{
			this.rootElement = rootElement;
			InitializeComponent();
			listView.ItemsSource = Storage.Constellations.items;
			
		}
		private void imgBack_MouseUp(object sender, MouseButtonEventArgs e)
		{
			BackToMainWindow();
		}

		private void BackToMainWindow()
		{
			rootElement.Content = new Library(rootElement).Content;
		}

		private void imgNext_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
		{
			if (e.ClickCount == 2)
			{
				//textBox.Text = listView.SelectedIndex.ToString();
			}


		}
		private void listViewItem_MouseDoubleClick(object sender, MouseButtonEventArgs e)
		{
			ListViewItem item = sender as ListViewItem;
			object obj = item.Content;
			rootElement.Content = new ListStar(rootElement, ((Constellation)obj)).Content;
			
		}


		private void listView_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
		{
		}
		private void btn_add_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
		{
			rootElement.Content = new AddConstellation.AddConstillation(rootElement).Content;
		}

		private void btn_delete_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
		{
			Constellation Selected = (Constellation)listView.SelectedItem;
			if (Storage.Constellations.IsIncluded(((Constellation)listView.SelectedItem)))
			{
				for (int i = 0; i < Selected.Stars.Length; i++)
				{
					for (int j = 0; j < Selected.Stars[i].Planets.Length; j++)
						Storage.Planets.Delete(Selected.Stars[i].Planets[j]);
					Storage.Stars.Delete(Selected.Stars[i]);
				}
				Storage.Constellations.DeleteAt(Storage.Constellations.IndexOf(Selected));
				listView.ItemsSource = Storage.Constellations.items;
			} 
		}
		void GridViewColumnHeaderClickedHandler(object sender, RoutedEventArgs e)
		{
			GridViewColumnHeader headerClicked = e.OriginalSource as GridViewColumnHeader;
			ListSortDirection direction;

			if (headerClicked != null)
			{
				if (headerClicked.Role != GridViewColumnHeaderRole.Padding)
				{
					if (headerClicked != _lastHeaderClicked)
					{
						direction = ListSortDirection.Ascending;
					}
					else
					{
						if (_lastDirection == ListSortDirection.Ascending)
						{
							direction = ListSortDirection.Descending;
						}
						else
						{
							direction = ListSortDirection.Ascending;
						}
					}
					string header = "";
					if ((headerClicked.Column.Header as string) == "ShortName")
						header = "ExInfo.ShortName";
					else if ((headerClicked.Column.Header as string) == "Name")
						header = "Name";
					else if ((headerClicked.Column.Header as string) == "Stars")
						header = "Stars.Length";
					else if ((headerClicked.Column.Header as String) == "Position")
						header = "Position.ToString";
					else
						header = "Name";

					Sort(header, direction);

					_lastHeaderClicked = headerClicked;
					_lastDirection = direction;
				}
			}
		}
		private void Sort(string sortBy, ListSortDirection direction)
		{
			ICollectionView dataView =
			  CollectionViewSource.GetDefaultView(listView.ItemsSource);

			dataView.SortDescriptions.Clear();
			SortDescription sd = new SortDescription(sortBy, direction);
			dataView.SortDescriptions.Add(sd);
			dataView.Refresh();
		}

		private void btn_info_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
		{
			if(listView.SelectedIndex != -1)
			{
				rootElement.Content = new LibraryList.AddConstellation.Change.ChangeConstellation(rootElement, ((Constellation)listView.SelectedItem)).Content;
			}
			else
			{

			}
		}
	}
}
