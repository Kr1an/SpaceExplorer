using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SObjectRepository.Repository.SObjectModel.Utils
{
	public class InfoHelper
	{
		public String Description { get; set; }
		public String ShortName { get; set; }
		public String Histroy { get; set; }
		public String Research { get; set; }
		public InfoHelper()
		{
			Description = "";
			ShortName = "";
			Histroy = "";
			Research = "";
		}
	}
}
