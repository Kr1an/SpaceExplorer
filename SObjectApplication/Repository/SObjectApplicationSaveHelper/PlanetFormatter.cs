using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SObjectRepository.Repository.ChainCollection;
using SObjectRepository.Repository.SObjectModel.Utils;
using SObjectRepository.Repository.SObjectModel;
using System.Text.RegularExpressions;

namespace SObjectApplication.Repository.SObjectApplicationSaveHelper
{
	static class PlanetFormatter
	{
		static public Chain<Planet> GetPlanetList(String SavedFormatString)
		{
			Chain<Planet> PlanetList = new Chain<Planet>();
			MatchCollection MatchesList = Regex.Matches(SavedFormatString, @"<PLANET>.*?</PLANET>");
			foreach (Match matchString in MatchesList)
			{
				PlanetList.Add(PlanetFromSaveFormat(matchString.Value));
			}
			return PlanetList;

		}
		static public Planet PlanetFromSaveFormat(string savedFormatString)
		{
			Planet Planet = new Planet();

			Planet.Name = GetTagInfo(savedFormatString, "NAME");
			Planet.Image.ImagePath = GetTagInfo(savedFormatString, "IMAGE");
			
			

			Planet.Feature.Mass = Convert.ToInt32(GetTagInfo(savedFormatString, "MASS"));
			Planet.Feature.OrbitPeriod = Convert.ToInt32(GetTagInfo(savedFormatString, "ORBITPERIOD"));
			Planet.Feature.Radius = Convert.ToInt32(GetTagInfo(savedFormatString, "RADIUS"));
			Planet.Feature.OrbitRadius = Convert.ToInt32(GetTagInfo(savedFormatString, "ORBITRADIUS"));
			Planet.Feature.RotationPeriod = Convert.ToInt32(GetTagInfo(savedFormatString, "ROTATIONPERIOD"));
			Planet.Feature.Radius = Convert.ToInt32(GetTagInfo(savedFormatString, "RADIUS"));
			Planet.Feature.OrbitRadius = Convert.ToInt32(GetTagInfo(savedFormatString, "ORBITRADIUS"));
			Planet.Feature.RotationPeriod = Convert.ToInt32(GetTagInfo(savedFormatString, "ROTATIONPERIOD"));
			return Planet;
		}
		static public string PlanetToSaveFormat(Planet formatObject)
		{
			return "<PLANET>" + PlanetInnerToSaveFormat(formatObject) + "</PLANET>";
		}

		static private string PlanetInnerToSaveFormat(Planet formatObject)
		{
			return "<IMAGE>" + formatObject.Image.ToString() + "</IMAGE>" +
				"<FEATURE>" + PlanetFeatureToSaveFormat(formatObject) + "</FEATURE>" +
				"<NAME>" + formatObject.Name + "</NAME>";
		}
		static private string PlanetFeatureToSaveFormat(Planet formatObject)
		{
			return "<RADIUS>" + formatObject.Feature.Radius.ToString() + "</RADIUS>" +
				"<MASS>" + formatObject.Feature.Mass.ToString() + "</MASS>" +
				"<ORBITPERIOD>" + formatObject.Feature.OrbitPeriod.ToString() + "</ORBITPERIOD>" +
				"<ROTATIONPERIOD>" + formatObject.Feature.RotationPeriod.ToString() + "</ROTATIONPERIOD>" +
				"<ORBITRADIUS>" + formatObject.Feature.OrbitRadius.ToString() + "</ORBITRADIUS>" +
				"<PLANETCLASS>" + formatObject.Feature.PlanetClass.ToString() + "</PLANETCLASS>";
		}

		static public string GetTagInfo(String saveFormatString, String tag)
		{
			return Regex.Match(saveFormatString, string.Format(@"(?<=<{0}>).*(?=</{0}>)", tag)).Value;
		}
	}
}