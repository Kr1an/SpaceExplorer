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

namespace SObjectApplication.Views.LibraryList.AddConstellation
{
	/// <summary>
	/// Interaction logic for AddPlanet.xaml
	/// </summary>
	public partial class AddPlanet : Window
	{
		private MainWindow rootElement;
		private Star ParentStar;
		public AddPlanet()
		{
			InitializeComponent();
		}
		public AddPlanet(MainWindow rootElement, Star ParentStar = null)
		{
			this.rootElement = rootElement;
			this.ParentStar = ParentStar;
			InitializeComponent();
		}
		private void imgBack_MouseUp(object sender, MouseButtonEventArgs e)
		{
			rootElement.Content = new ListPlanet(rootElement, ParentStar).Content;
		}
		private void imgNext_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
		{
			if (!(name_text.Text == "" || name_text.Text == "NAME"))
			{
				Planet tmpPlanet = new Planet() { Name = name_text.Text, Feature = new PlanetFeature() { PlanetClass = (int)c_slider.Value }, ParentStar = this.ParentStar };
				ParentStar.Planets.Add(tmpPlanet);
				Storage.Planets.Add(tmpPlanet);
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
				case 0: tmp = "Carbon class ";break;
				case 1: tmp = "Coreless clas ";break;
				case 2: tmp = "Desert class ";break;
				case 3: tmp = "Dwarf class ";break;
				case 4: tmp = "Earth class ";break;
				case 5: tmp = "Jupitor class ";break;
				case 6: tmp = "Exoplanet class ";break;
				case 7: tmp = "GasGiant class ";break;
				case 8: tmp = "IceGiant class ";break;
				case 9: tmp = "Iron class ";break;
				case 10: tmp = "Lava class ";break;
				case 11: tmp = "Plutoid class ";break;
				case 12: tmp = "Trojan class ";break;
				case 13: tmp = "Terrastrian class ";break;
				case 14: tmp = "Outer class ";break;
			}
			spec_class.Content = tmp;

		}
	}
}
