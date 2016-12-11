using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SObjectRepository.Repository.SObjectModel.Utils;


namespace SObjectRepository.Repository.SObjectModel
{
	public class Planet : IEquatable<Planet>
	{
		public String Name { get; set; }
		public ImageHelper Image { get; set; }
		public PlanetFeature Feature { get; set; }
		public Star ParentStar { get; set; }

		public Planet()
		{
			this.Name = "";
			this.Image = new ImageHelper();
			this.Feature = new PlanetFeature();
			this.ParentStar = new SObjectModel.Star();
		}
		public bool Equals(Planet Other)
		{
			if (Name == Other.Name &&
				ParentStar == Other.ParentStar)
				return true;
			else
				return false;
		}
	}
}
