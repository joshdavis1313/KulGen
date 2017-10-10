using System;
using System.Globalization;
using MvvmCross.Platform.Converters;

namespace KulGen.Droid.Converters
{
	public class IntToStringConverter : MvxValueConverter<int, string>
    {
        protected override string Convert(int value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == 0)
			{
				return "0";
			}

			return value.ToString();
        }

		protected override int ConvertBack(string value, Type targetType, object parameter, CultureInfo culture)
		{
			return Int32.Parse(value);
		}
    }
}
