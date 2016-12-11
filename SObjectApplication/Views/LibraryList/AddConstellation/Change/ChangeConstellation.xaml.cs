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
	/// Interaction logic for ChangeConstellation.xaml
	/// </summary>
	public partial class ChangeConstellation : Window
	{
		public MainWindow rootElement;
		public Constellation ChangeCond;
		public ChangeConstellation()
		{
			InitializeComponent();

		}

		public ChangeConstellation(MainWindow rootElement, Constellation ChangeCond = null)
		{
			this.ChangeCond = ChangeCond;
			this.rootElement = rootElement;
			InitializeComponent();
			ComponentInit();
		}
		private  void ComponentInit()
		{
			name_text.Text = ChangeCond.Name;

			h_text.Text = ChangeCond.Position.GetRightAscension().Hour.ToString();
			m_text.Text = ChangeCond.Position.GetRightAscension().Minute.ToString();
			s_text.Text = ChangeCond.Position.GetRightAscension().Second.ToString();
			degree_text.Text = ChangeCond.Position.GetDeclination().ToString();
		}
		private void imgBack_MouseUp(object sender, MouseButtonEventArgs e)
		{
			rootElement.Content = new ListConstellation(rootElement).Content;
		}
		private void imgNext_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
		{
			if (!(name_text.Text == "NAME" || name_text.Text.Length <= 1 ||
				Convert.ToInt32(h_text.Text) < 0 || Convert.ToInt32(h_text.Text) > 24 ||
				Convert.ToInt32(m_text.Text) < 0 || Convert.ToInt32(m_text.Text) > 60 ||
				Convert.ToInt32(s_text.Text) < 0 || Convert.ToInt32(s_text.Text) > 60 ||
				Convert.ToInt32(degree_text.Text) < -90 || Convert.ToInt32(degree_text.Text) > 90))
			{
				Position newPosition = new Position();
				newPosition.SetDeclination(Convert.ToInt32(degree_text.Text));
				newPosition.SetRightAscension(new DateTime(1, 1, 1, Convert.ToInt32(h_text.Text), Convert.ToInt32(m_text.Text), Convert.ToInt32(s_text.Text)));
				ChangeCond.Name = name_text.Text;
				ChangeCond.Position = newPosition;
				rootElement.Content = new ListConstellation(rootElement).Content;
			}
			else
			{

			}





		}
	}
		
}
