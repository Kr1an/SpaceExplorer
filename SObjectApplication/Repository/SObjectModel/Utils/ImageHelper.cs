using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SObjectRepository.Repository.SObjectModel.Utils
{
	public class ImageHelper
	{
		public String ImagePath { get; set; }

		public ImageHelper()
		{
			ImagePath = "";
		}		
		public override string ToString()
		{
			return ImagePath;
		}
		static public ImageHelper FromString(String stringRepresentation)
		{
			return new ImageHelper() { ImagePath = stringRepresentation };
		}
	}
}
