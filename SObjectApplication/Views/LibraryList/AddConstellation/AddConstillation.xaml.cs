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
	/// Interaction logic for AddConstillation.xaml
	/// </summary>
	public partial class AddConstillation : Window
	{
		public MainWindow rootElement;
		public AddConstillation()
		{
			InitializeComponent();
		}
		public AddConstillation(MainWindow rootElement)
		{
			this.rootElement = rootElement;
			InitializeComponent();
		}
		private void imgBack_MouseUp(object sender, MouseButtonEventArgs e)
		{
			rootElement.Content = new ListConstellation(rootElement).Content;
		}
		private void imgNext_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
		{
			if(!(name_text.Text == "NAME" || name_text.Text.Length <= 1 ||
				Convert.ToInt32(h_text.Text) < 0 || Convert.ToInt32(h_text.Text) > 24 ||
				Convert.ToInt32(m_text.Text) < 0 || Convert.ToInt32(m_text.Text) > 60 ||
				Convert.ToInt32(s_text.Text) < 0 || Convert.ToInt32(s_text.Text) > 60 ||
				Convert.ToInt32(degree_text.Text) < -90 || Convert.ToInt32(degree_text.Text) > 90))
			{
				Position newPosition = new Position();
				newPosition.SetDeclination(Convert.ToInt32(degree_text.Text));
				newPosition.SetRightAscension(new DateTime(1, 1, 1, Convert.ToInt32(h_text.Text), Convert.ToInt32(m_text.Text), Convert.ToInt32(s_text.Text)));
				Storage.Constellations.Add(new Constellation() {ExInfo = new InfoHelper() {ShortName = name_text.Text[0].ToString() + name_text.Text[name_text.Text.Length-1].ToString() }, Name = name_text.Text, Position = newPosition});
				rootElement.Content = new ListConstellation(rootElement).Content;
			}
			else
			{

			}
			




		}
	}
}
