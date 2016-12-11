using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SObjectRepository.Repository.SObjectModel.Utils
{
	public class StarFeature
	{

		public Int32 Radius { get; set; }//mesures km
		public Int32 Mass { get; set; }//mesures in kg
		public Double AbsMagnitude { get; set; }//possitive or negative float number
		public Int32 SpecClass { get; set; }//info in SpectralClass class
		public Int32 SpecSubclass { get; set; }//number 0..9
		public Int32 OrbitPeriod { get; set; }// mesures in earth days
		public Int32 RotationPeriod { get; set; }// mesures in earth days


		public String SpectralClassString
		{
			get
			{
				switch (this.SpecClass)
				{
					case 0:  return "O spectrum";
					case 1:  return "B spectrum";
					case 2:  return "A spectrum";
					case 3:  return "F spectrum";
					case 4:  return "G spectrum";
					case 5:  return "K spectrum";
					case 6:  return "W spectrum";
					case 7:  return "L spectrum";
					case 8:  return "T spectrum";
					case 9:  return "Y spectrum";
					case 10: return "C spectrum";
					case 11: return "S spectrum";
					case 12: return "D spectrum";
					case 13: return "Q spectrum";
					case 14: return "P spectrum";
					default: return "<UNKNOWN>";
				}
			}
		}

	}
	public static class SpectralClass
	{
		public static int O_class = 0;
		public static int B_class = 1;
		public static int A_class = 2;
		public static int F_class = 3;
		public static int G_class = 4;
		public static int K_class = 5;
		public static int W_class = 6;
		public static int L_class = 7;
		public static int T_class = 8;
		public static int Y_class = 9;
		public static int C_class = 10;
		public static int S_class = 11;
		public static int D_class = 12;
		public static int Q_class = 13;
		public static int P_class = 14;
	}
}
