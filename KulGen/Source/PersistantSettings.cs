using Plugin.Settings;
using Plugin.Settings.Abstractions;

namespace KulGen
{
	public static class PersistantSettings
	{
		static ISettings AppSettings
		{
			get {
				return CrossSettings.Current;
			}
		}

		const string MultipleNpcOptionKey = "multiple_npc_key";
		static readonly int MultipleNpcOptionDefault = 1;

		public static int PersistantMultipleNpcOption
		{
			get { return AppSettings.GetValueOrDefault (MultipleNpcOptionKey, MultipleNpcOptionDefault); }
			set { AppSettings.AddOrUpdateValue (MultipleNpcOptionKey, value); }
		}

		const string InitiativeSortKey = "initiative_sort_key";
		static readonly int InitiativeSortDefault = 1;

		public static int PersistantInitiativeSort
		{
			get { return AppSettings.GetValueOrDefault (InitiativeSortKey, InitiativeSortDefault); }
			set { AppSettings.AddOrUpdateValue (InitiativeSortKey, value); }
		}

		const string MultipleNpcCustomSuffixKey = "multiple_npc_custom_key";
		static readonly string MultipleNpcCustomSuffixDefault = "";

		public static string MultipleNpcCustomSuffix
		{
			get { return AppSettings.GetValueOrDefault (MultipleNpcCustomSuffixKey, MultipleNpcCustomSuffixDefault); }
			set { AppSettings.AddOrUpdateValue (MultipleNpcCustomSuffixKey, value); }
		}
	}
}
