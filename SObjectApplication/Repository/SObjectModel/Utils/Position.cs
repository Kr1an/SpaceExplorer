using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SObjectRepository.Repository.SObjectModel.Utils
{
	public class Position : IEquatable<Position>
	{
		private DateTime _rightAscension;
		private Int32 _declination;


		
		public void SetRightAscension(DateTime value)
		{
			_rightAscension = new DateTime(
					hour: value.Hour,
					minute: value.Minute,
					second: value.Second,
					year: 1, month: 1, day: 1);
		}
		public void SetRightAscension(String dateTimeString)
		{
			_rightAscension = DateTime.ParseExact(dateTimeString, "dd.MM.yyyy HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture);
		}
		public DateTime GetRightAscension()
		{
			return new DateTime(
					hour: _rightAscension.Hour,
					minute: _rightAscension.Minute,
					second: _rightAscension.Second,
					year: 1, month: 1, day: 1);
		}
		public void SetDeclination(String value)
		{
			SetDeclination(Convert.ToInt32(value));
		}
		public void SetDeclination(Int32 value)
		{
			if (value > 90)
				_declination = 90;
			else if (value < -90)
				_declination = -90;
			else
				_declination = value;
		}
		public Int32 GetDeclination()
		{
			return _declination;
		}
		
		public Position()
		{
			this.SetDeclination(0);
			this.SetRightAscension(new DateTime(1, 1, 1, 0, 0, 0));
		}

		public bool Equals(Position Other)
		{
			if (this.GetDeclination() == Other.GetDeclination() &&
				this.GetRightAscension() == Other.GetRightAscension())
				return true;
			else
				return false;
		}
		public String StrFormat {
			get
			{
				return ToString();			
			}
		}
		public String ToString
		{
			get
			{
				return String.Format("{0}h{1}m{2}s, {3}°", _rightAscension.Hour, _rightAscension.Minute, _rightAscension.Second, _declination);
			}
		}
		
	}
}
