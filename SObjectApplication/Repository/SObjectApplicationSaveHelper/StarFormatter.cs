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
	static class StarFormatter
	{
		static public Chain<Star> GetStarList(String SavedFormatString)
		{
			Chain<Star> StarList = new Chain<Star>();
			MatchCollection MatchesList = Regex.Matches(SavedFormatString, @"<STAR>.*?</STAR>");
			foreach (Match constString in MatchesList)
			{
				StarList.Add(StarFromSaveFormat(constString.Value));
			}
			return StarList;

		}
		static public Star StarFromSaveFormat(string savedFormatString)
		{
			Star Star = new Star();

			Star.Name = GetTagInfo(savedFormatString, "NAME");
			Star.Feature.Mass = Convert.ToInt32(GetTagInfo(savedFormatString, "MASS"));
			Star.Feature.AbsMagnitude = Convert.ToInt32(GetTagInfo(savedFormatString, "ABSMAGNITYDE"));
			Star.Feature.OrbitPeriod = Convert.ToInt32(GetTagInfo(savedFormatString, "ORBITPERIOD"));
			Star.Feature.Radius = Convert.ToInt32(GetTagInfo(savedFormatString, "RADIUS"));
			Star.Feature.RotationPeriod = Convert.ToInt32(GetTagInfo(savedFormatString, "ROTATIONPERIOD"));
			Star.Feature.SpecClass = Convert.ToInt32(GetTagInfo(savedFormatString, "SPECCLASS"));
			Star.Feature.SpecSubclass = Convert.ToInt32(GetTagInfo(savedFormatString, "SPECSUBCLASS"));
			Star.Image.ImagePath = GetTagInfo(savedFormatString, "IMAGE");			
			return Star;
		}
		static public string StarToSaveFormat(Star formatObject)
		{
			return "<STAR>" + StarInnerToSaveFormat(formatObject) + "</STAR>";
		}

		static private string StarInnerToSaveFormat(Star formatObject)
		{
			return "<IMAGE>" + formatObject.Image.ToString() + "</IMAGE>" +
				"<FEATURE>" + StarFeatureToSaveFormat(formatObject) + "</FEATURE>" +
				"<NAME>" + formatObject.Name + "</NAME>";
		}
		static private string StarFeatureToSaveFormat(Star formatObject)
		{
			return "<RADIUS>" + formatObject.Feature.Radius.ToString() + "</RADIUS>" +
				"<MASS>" + formatObject.Feature.Mass.ToString() + "</MASS>" +
				"<ORBITPERIOD>" + formatObject.Feature.OrbitPeriod.ToString() + "</ORBITPERIOD>" +
				"<ROTATIONPERIOD>" + formatObject.Feature.RotationPeriod.ToString() + "</ROTATIONPERIOD>" +
				"<SPECCLASS>" + formatObject.Feature.SpecClass.ToString() + "</SPECCLASS>" +
				"<SPECSUBCLASS>" + formatObject.Feature.SpecSubclass.ToString() + "</SPECSUBCLASS>" +
				"<ABSMAGNITYDE>" + formatObject.Feature.AbsMagnitude.ToString() + "</ABSMAGNITYDE>";

		}

		static public string GetTagInfo(String saveFormatString, String tag)
		{
			return Regex.Match(saveFormatString, string.Format(@"(?<=<{0}>).*(?=</{0}>)", tag)).Value;
		}
	}
}
