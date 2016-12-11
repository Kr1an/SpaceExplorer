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

namespace SObjectApplication.Views.LibraryList.AddConstellation.Change
{
	/// <summary>
	/// Interaction logic for ChangePlanet.xaml
	/// </summary>
	public partial class ChangePlanet : Window
	{
		private MainWindow rootElement;
		private Planet ChangeCond;
		private Star ParentStar;
		private Constellation ParentConstellation;
		public ChangePlanet()
		{
			InitializeComponent();
			ComponentInit();
		}
		public ChangePlanet(MainWindow rootElement, Planet ChangeCond, Star ParentStar = null,Constellation ParentConstellation = null)
		{
			this.rootElement = rootElement;
			this.ChangeCond = ChangeCond;
			this.ParentStar = ParentStar;
			this.ParentConstellation = ParentConstellation;
			InitializeComponent();
			ComponentInit();
		}
		private void listViewItem_MouseDoubleClick(object sender, MouseButtonEventArgs e)
		{
			ListViewItem item = sender as ListViewItem;
			object obj = item.Content;
			const_text.Text = ((Star)obj).Name;

		}

		private void ComponentInit()
		{
			listView.ItemsSource = Storage.Stars.items;
			name_text.Text = ChangeCond.Name;
			c_slider.Value = ChangeCond.Feature.PlanetClass;
			const_text.Text = ChangeCond.ParentStar.Name;
		}

		private void imgBack_MouseUp(object sender, MouseButtonEventArgs e)
		{
			rootElement.Content = new ListStar(rootElement, ParentConstellation).Content;
		}
		private void imgNext_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
		{
			if (!(name_text.Text == "" || name_text.Text == "NAME"))
			{
				ChangeCond.Name = name_text.Text;
				ChangeCond.Feature.PlanetClass = (int)c_slider.Value;


				if (listView.SelectedIndex != -1)
				{
					ParentStar.Planets.Delete(ChangeCond);
					ChangeCond.ParentStar = ((Star)listView.SelectedItem);
					ChangeCond.ParentStar.Planets.Add(ChangeCond);
				}
				rootElement.Content = new ListPlanet(rootElement, ParentStar).Content;
			}
			else
			{

			}






		}

		private void c_slider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
		{
			String tmp = "";
			switch ((int)c_slider.Value)
			{
				case 0: tmp = "Carbon class"; break;
				case 1: tmp = "Coreless class"; break;
				case 2: tmp = "Desert class"; break;
				case 3: tmp = "Dwarf class"; break;
				case 4: tmp = "Earth class"; break;
				case 5: tmp = "Jupitor class"; break;
				case 6: tmp = "Exoplanet class"; break;
				case 7: tmp = "GasGiant class"; break;
				case 8: tmp = "IceGiant class"; break;
				case 9: tmp = "Iron class"; break;
				case 10: tmp ="Lava class"; break;
				case 11: tmp ="Plutoid class"; break;
				case 12: tmp ="Trojan class"; break;
				case 13: tmp ="Terrastrian class"; break;
				case 14: tmp ="Outer class"; break;
			}
			spec_class.Content = tmp;
		}
	}
}

