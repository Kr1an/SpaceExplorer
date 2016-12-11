using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SObjectRepository.Repository.SObjectModel.Utils
{
	public class PlanetFeature
	{
		public Int32 Radius { get; set; }//mesures in km
		public Int32 OrbitRadius { get; set; }//mesures in km
		public Int32 Mass { get; set; }//mesures in kg
		public Int32 OrbitPeriod { get; set; }// mesures in earth days
		public Int32 RotationPeriod { get; set; }// mesures in earth days
		public Int32 PlanetClass { get; set; }//info in PlanetClass class


		public String PlanetTypeString {
			get
			{
				switch (this.PlanetClass)
				{
					case 0: return "Carbon class"; 
					case 1: return "Coreless class"; 
					case 2: return "Desert class"; 
					case 3: return "Dwarf class"; 
					case 4: return "Earth class"; 
					case 5: return "Jupitor class"; 
					case 6: return "Exoplanet class"; 
					case 7: return "GasGiant class"; 
					case 8: return "IceGiant class"; 
					case 9: return "Iron class"; 
					case 10: return "Lava class"; 
					case 11: return "Plutoid class"; 
					case 12: return "Trojan class"; 
					case 13: return "Terrastrian class"; 
					case 14: return "Outer class";
					default: return "<UNKNOWN>";
				}
			}
		}
	}

	public static class PlanetClass
	{
		public static int Carbon_class = 0;
		public static int Coreless_class = 1;
		public static int Desert_class = 2;
		public static int Dwarf_class = 3;
		public static int Earth_class = 4;
		public static int Jupitor_class = 5;
		public static int Exoplanet_class = 6;
		public static int GasGiant_class = 7;
		public static int IceGiant_class = 8;
		public static int Iron_class = 9;
		public static int Lava_class = 10;
		public static int Plutoid_class =11;
		public static int Trojan_class =12;
		public static int Terrastrian_class = 13;
		public static int Outer_class = 14;
	}
}
