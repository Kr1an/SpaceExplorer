using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SObjectRepository.Repository.SObjectModel.Utils;
using SObjectRepository.Repository.SObjectModel;
using SObjectRepository.Repository.ChainCollection;
using System.Text.RegularExpressions;

namespace SObjectApplication.Repository.SObjectApplicationSaveHelper
{
	static class EntitiesFormatter
	{
		public static void MakeEntity(String entitiesString)
		{
			MatchCollection MatchesList = Regex.Matches(entitiesString, @"(?<=<PLANETPARENT>).*?(?=</PLANETPARENT>)");
			for(int i = 0; i < Storage.Planets.Length; i++)
			{
				Storage.Planets[i].ParentStar = Storage.Stars[Convert.ToInt32(MatchesList[i].Value)];
				Storage.Stars[Convert.ToInt32(MatchesList[i].Value)].Planets.Add(Storage.Planets[i]);
			}

			MatchesList = Regex.Matches(entitiesString, @"(?<=<STARPARENT>).*?(?=</STARPARENT>)");
			for (int i = 0; i < Storage.Stars.Length; i++)
			{
				Storage.Stars[i].ParentConstellation = Storage.Constellations[Convert.ToInt32(MatchesList[i].Value)];
				Storage.Constellations[Convert.ToInt32(MatchesList[i].Value)].Stars.Add(Storage.Stars[i]);
			}
		}

		public static string EntitiesToStringFormat()
		{
			return getPlanetsParents() + 
				getStarParents() ;

		}
		public static string getPlanetsParents()
		{ 
			string planetParentsSaveString= "";
			foreach (Planet Planet in Storage.Planets)
				planetParentsSaveString+= getPlanetEntities(Planet);
			return "<PLANETPARENTS>" + planetParentsSaveString + "</PLANETPARENTS>";
		}
		public static string getPlanetEntities(Planet Planet)
		{
			return "<PLANETPARENT>" + Storage.Stars.IndexOf(Planet.ParentStar).ToString() + "</PLANETPARENT>";
		}

		public static string getStarParents()
		{
			string parentsSaveFormatString = "";
			foreach (Star Star in Storage.Stars)
				parentsSaveFormatString += getStarParent(Star);

			return "<STARPARENTS>" + parentsSaveFormatString + "</STARPARENTS>";
		}
		public static string getStarParent(Star Star)
		{
			return "<STARPARENT>" + Storage.Constellations.IndexOf(Star.ParentConstellation).ToString() + "</STARPARENT>";
		}
	}
}