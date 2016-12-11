using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SObjectRepository.Repository.ChainCollection;
using SObjectRepository.Repository.SObjectModel;
using SObjectRepository.Repository.SObjectModel.Utils;

namespace SObjectRepository.Repository.Tests
{
	class UTests
	{
		private bool flag;
		public UTests()
		{
			flag = true;
		}
		public void UnitTests()
		{
			//Test#1(Constructor)
			{
				float[] testFloatMass = new float[] { 1, 2, 3, 4, 5, 6, 7 };
				using (Chain<float> chain = new Chain<float>(testFloatMass))
				{
					for (int i = 0; i < chain.Length; i++)
						if (testFloatMass[i] != chain[i])
						{
							Console.WriteLine("Test#1 Faild(Constructor)");
							flag = false;
						}
				}
			}

			//Test#2(Add method)
			{
				float[] testFloatMass = new float[] { 1, 2, 3, 4, 5, 6, 7, 8 };
				using (Chain<float> chain = new Chain<float>(new float[]{ 1, 2, 3, 4, 5, 6, 7 }))
				{
					chain.Add(8);
					for (int i = 0; i < chain.Length; i++)
						if (testFloatMass[i] != chain[i])
						{
							Console.WriteLine("");
							flag = false;
						}
				}
			}

			//Test#3(Model hierarchy)
			{
				using (Chain<Constellation> chain = new Chain<Constellation>())
				{
					chain.Add(new Constellation());
					chain[0].Stars = new Chain<Star>();
					chain[0].Stars.Add(new Star());
					chain[0].Stars[0].Planets = new Chain<Planet>();
					chain[0].Stars[0].Planets.Add(new Planet());
					chain[0].Stars[0].Planets[0].ParentStar = chain[0].Stars[0];
					chain[0].Stars[0].Planets[0].ParentStar.ParentConstellation = chain[0];

					if (chain[0] != chain[0].Stars[0].Planets[0].ParentStar.ParentConstellation)
					{
						Console.WriteLine("Test#3 Faild(Model hierarchy)");
						flag = false;
					}
				}
			}
			PrintResult();
		}

		private void PrintResult()
		{
			if (flag == true)
				Console.WriteLine("Test run successful.");
		}
		
	}
}
