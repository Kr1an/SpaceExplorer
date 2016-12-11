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
using SObjectApplication.Views.LibraryList;

namespace SObjectApplication.Views.LibraryList.AddConstellation
{
	/// <summary>
	/// Interaction logic for AddStar.xaml
	/// </summary>
	public partial class AddStar : Window
	{
		private MainWindow rootElement;
		private Constellation ParentConstellation;
		public AddStar()
		{
			InitializeComponent();
		}
		public AddStar(MainWindow rootElement, Constellation ParentConstellation=null)
		{
			this.rootElement = rootElement;
			this.ParentConstellation = ParentConstellation;
			InitializeComponent();

		}
		private void imgBack_MouseUp(object sender, MouseButtonEventArgs e)
		{
			rootElement.Content = new ListStar(rootElement, ParentConstellation).Content;
		}
		private void imgNext_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
		{
			if( !(name_text.Text == "" || name_text.Text == "NAME"))
			{
				Star tmpStar = new Star() { Name = name_text.Text, Feature = new StarFeature() { SpecClass = (int)c_slider.Value } , ParentConstellation = this.ParentConstellation};
				ParentConstellation.Stars.Add(tmpStar);
				Storage.Stars.Add(tmpStar);
				rootElement.Content = new ListStar(rootElement, ParentConstellation).Content;
			}else
			{

			}
			





		}

		private void c_slider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
		{
			String tmp = "";
			switch ((int)c_slider.Value)
			{
				case 0  : tmp = "O spectrum"; break;
				case 1  : tmp = "B spectrum";  break;
				case 2  : tmp = "A spectrum";  break;
				case 3  : tmp = "F spectrum";  break;
				case 4  : tmp = "G spectrum";  break;
				case 5  : tmp = "K spectrum";  break;
				case 6  : tmp = "W spectrum";  break;
				case 7  : tmp = "L spectrum";  break;
				case 8  : tmp = "T spectrum";  break;
				case 9  : tmp = "Y spectrum";  break;
				case 10 : tmp = "C spectrum";  break;
				case 11 : tmp = "S spectrum";  break;
				case 12 : tmp = "D spectrum";  break;
				case 13 : tmp = "Q spectrum";  break;
				case 14 : tmp = "P spectrum";  break;
			}
			spec_class.Content = tmp + " " + c_slider.Value;

		}
	}
}
