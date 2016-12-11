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

using SObjectRepository.Repository.ChainCollection;
using SObjectRepository.Repository.Tests;
using SObjectRepository.Repository.SObjectModel;
using SObjectRepository.Repository.SObjectModel.Utils;
using System.ComponentModel;

namespace SObjectApplication.Views.LibraryList
{
	/// <summary>
	/// Interaction logic for ListPlanet.xaml
	/// </summary>
	public partial class ListPlanet : Window
	{
		private MainWindow rootElement;
		private Star ParentStar;
		GridViewColumnHeader _lastHeaderClicked = null;
		ListSortDirection _lastDirection = ListSortDirection.Ascending;
		public ListPlanet(MainWindow rootElement, Star ParentStar = null)
		{
			this.rootElement = rootElement;
			this.ParentStar = ParentStar;

			InitializeComponent();
			listView.ItemsSource = Storage.Planets.Where(x => (x.ParentStar == this.ParentStar || this.ParentStar == null));
			if (ParentStar == null)
			{
				buttonLayout.Effect = new System.Windows.Media.Effects.BlurEffect();
				btn_info.Effect = new System.Windows.Media.Effects.BlurEffect();
				btn_add.Effect = new System.Windows.Media.Effects.BlurEffect();
				btn_delete.Effect = new System.Windows.Media.Effects.BlurEffect();
				btn_delete.IsEnabled = false;
				btn_add.IsEnabled = false;
				btn_info.IsEnabled = false;
			}

		}
		private void imgBack_MouseUp(object sender, MouseButtonEventArgs e)
		{
			if (ParentStar == null)
				BackToMainWindow();
			else
				BackToListStar();

		}

		private void BackToMainWindow()
		{
			rootElement.Content = new Library(rootElement).Content;
		}
		private void BackToListStar()
		{
			rootElement.Content = new ListStar(rootElement, ParentStar.ParentConstellation).Content;
		}

		private void imgNext_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
		{
			if (e.ClickCount == 2)
			{
			}


		}
		private void listViewItem_MouseDoubleClick(object sender, MouseButtonEventArgs e)
		{
		}


		private void listView_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
		{
		}
		private void btn_add_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
		{
			rootElement.Content = new AddConstellation.AddPlanet(rootElement, ParentStar).Content;
		}

		private void btn_delete_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
		{
			Planet Selected = (Planet)listView.SelectedItem;
			if (Storage.Planets.IsIncluded(((Planet)listView.SelectedItem)))
			{
				ParentStar.Planets.Delete(Selected);
				Storage.Planets.Delete(Selected);
				listView.ItemsSource = ParentStar.Planets.items;
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
					if ((headerClicked.Column.Header as string) == "Name")
						header = "Name";
					else if ((headerClicked.Column.Header as string) == "Type")
						header = "Feature.PlanetTypeString";
					else if((headerClicked.Column.Header as String) == "Parent Star")
						header = "ParentStar.Name";
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
			if (listView.SelectedIndex != -1)
			{
				rootElement.Content = new AddConstellation.Change.ChangePlanet(rootElement, (Planet)(listView.SelectedItem), ParentStar, ParentStar.ParentConstellation).Content;
			}
			else
			{

			}
		}
	}
}
