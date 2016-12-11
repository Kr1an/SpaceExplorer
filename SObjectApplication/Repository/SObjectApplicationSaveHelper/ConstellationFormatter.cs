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
	static class ConstellationFormatter
	{
		static public Chain<Constellation> GetConstellationList(String SavedFormatString)
		{
			Chain<Constellation> ConstellationList = new Chain<Constellation>();
			MatchCollection MatchesList = Regex.Matches(SavedFormatString, @"<CONSTELLATION>.*?</CONSTELLATION>");
			foreach(Match constString in MatchesList)
			{
				ConstellationList.Add(ConstellationFromSaveFormat(constString.Value));
			}				
			return ConstellationList;

		}
		static public Constellation ConstellationFromSaveFormat(string savedFormatString)
		{
			Constellation Constellation = new Constellation();
			Constellation.Name = GetTagInfo(savedFormatString, "NAME");
			Constellation.Image.ImagePath = GetTagInfo(savedFormatString, "IMAGE");
			Constellation.Position.SetRightAscension(GetTagInfo(savedFormatString, "RIGHTASCENSION"));
			Constellation.Position.SetDeclination(GetTagInfo(savedFormatString, "DECLINATION"));
			Constellation.ExInfo.Description = GetTagInfo(savedFormatString, "DESCRIPTION");
			Constellation.ExInfo.ShortName = GetTagInfo(savedFormatString, "SHORTNAME");
			Constellation.ExInfo.Histroy = GetTagInfo(savedFormatString, "HISTORY");
			Constellation.ExInfo.Research = GetTagInfo(savedFormatString, "RESEARCH");
			return Constellation;
		}
		static public string ConstellationToSaveFormat(Constellation formatObject)
		{
			return "<CONSTELLATION>" + ConstellationInnerToSaveFormat(formatObject) + "</CONSTELLATION>";
		}

		static private string ConstellationInnerToSaveFormat(Constellation formatObject)
		{
			return "<IMAGE>" + formatObject.Image.ToString() + "</IMAGE>" +
				"<POSITION>" + ConstellationPositionToSaveFormat(formatObject) + "</POSITION>" +
				"<EXINFO>" + ConstellationExInfoToSaveFormat(formatObject) + "</EXINFO>" +
				"<NAME>" + formatObject.Name + "</NAME>";
		}

		static private string ConstellationPositionToSaveFormat(Constellation formatObject)
		{
			return "<RIGHTASCENSION>" + formatObject.Position.GetRightAscension().ToString("dd.MM.yyyy HH:mm:ss") +"</RIGHTASCENSION>" +
				"<DECLINATION>" + formatObject.Position.GetDeclination().ToString() + "</DECLINATION>";
		}

		static private string ConstellationExInfoToSaveFormat(Constellation formatObject)
		{
			return "<DESCRIPTION>" + formatObject.ExInfo.Description + "</DESCRIPTION>" +
				"<SHORTNAME>" + formatObject.ExInfo.ShortName + "</SHORTNAME>" +
				"<HISTORY>" + formatObject.ExInfo.Histroy + "</HISTORY>" +
				"<RESEARCH>" + formatObject.ExInfo.Research + "</RESEARCH>";
		}

		static public string GetTagInfo(String saveFormatString, String tag)
		{
			return Regex.Match(saveFormatString, string.Format(@"(?<=<{0}>).*(?=</{0}>)", tag)).Value;
		}		
	}
}
