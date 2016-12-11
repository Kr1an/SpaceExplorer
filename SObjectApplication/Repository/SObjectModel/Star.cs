using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SObjectRepository.Repository.ChainCollection;
using SObjectRepository.Repository.SObjectModel.Utils;

namespace SObjectRepository.Repository.SObjectModel
{
	public class Star : IEquatable<Star>
	{
		public Constellation ParentConstellation { get; set; }
		public String Name { get; set; }
		public StarFeature Feature { get; set; }
		public ImageHelper Image { get; set; }
		public Chain<Planet> Planets { get; set; }

		public Star()
		{
			Feature = new StarFeature();
			Image = new ImageHelper();
			Planets = new Chain<Planet>();
			ParentConstellation = new Constellation() { Name = "" };
			Name = "";
		}
		
		public bool Equals(Star Other)
		{
			if (this.Name == Other.Name)
				return true;
			else
				return false;
		}
	}
}
