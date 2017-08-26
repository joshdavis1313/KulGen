using System;
using System.Globalization;
using MvvmCross.Platform.Converters;

namespace KulGen.Droid.Source.Converters
{
	public class StringToIntConverter : MvxValueConverter<string, int>
    {
        protected override int Convert(string value, Type targetType, object parameter, CultureInfo culture)
        {
            if (!string.IsNullOrEmpty(value))
            {
				return Int32.Parse (value);
            }
            return 0;
        }

		protected override string ConvertBack(int value, Type targetType, object parameter, CultureInfo culture)
		{
			return value.ToString ();
		}
    }
}
