using System;
using System.Globalization;
using Android.Views;
using MvvmCross.Platform.Converters;

namespace KulGen.Android.Source.Converters
{
	public class VisibilityGoneValueConverter : MvxValueConverter<bool, ViewStates>
	{
		protected override ViewStates Convert(bool value, Type targetType, object parameter, CultureInfo culture)
		{
			return value ? ViewStates.Visible : ViewStates.Gone;
		}

		protected override bool ConvertBack(ViewStates value, Type targetType, object parameter, CultureInfo culture)
		{
			return value == ViewStates.Visible;
		}
	}
}