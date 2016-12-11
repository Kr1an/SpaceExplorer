using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SObjectRepository.Repository.ChainCollection;
using SObjectRepository.Repository.SObjectModel.Utils;

namespace SObjectRepository.Repository.SObjectModel
{
	public class Constellation:IEquatable<Constellation>
	{
		public ImageHelper Image { get; set; }
		public Position Position { get; set; }
		public Chain<Star> Stars { get; set; }
		public InfoHelper ExInfo { get; set; }
		public String Name { get; set; }

		public Constellation()
		{
			Stars = new Chain<Star>();
			ExInfo = new InfoHelper();
			Position = new Position();
			Image = new ImageHelper();
			Name = "";

		}

		public bool Equals(Constellation Other)
		{
			if (this.Position == Other.Position &&
				this.Name == Other.Name)
				return true;
			else
				return false;
		}
	}
}
