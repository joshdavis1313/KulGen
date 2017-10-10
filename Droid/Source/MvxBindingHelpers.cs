using Android.Views;
using Android.Widget;

namespace KulGen.Droid
{
	public static class MvxBindingHelpers
	{
		public static string ClickEvent(this View view)
		{
			return "Click";
		}

		public static string ItemClickEvent(this AdapterView view)
		{
			return "ItemClick";
		}

		public static string FocusChangedEvent(this View view)
		{
			return "FocusChanged";
		}

		public static string ItemClickEvent(this AutoCompleteTextView view)
		{
			return "ItemClick";
		}

		public static string Text(this View view)
		{
			return "Text";
		}
	}
}