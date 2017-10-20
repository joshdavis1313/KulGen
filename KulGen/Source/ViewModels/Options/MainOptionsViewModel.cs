using System.Windows.Input;
using KulGen.Core;
using KulGen.Source.Util;
using KulGen.ViewModels;
using MvvmCross.Core.ViewModels;
using MvvmCross.FieldBinding;

namespace KulGen.Source.ViewModels.Options
{
	public class MainOptionsViewModel : NavigationBarViewModel
	{
		public readonly INC<InitiativeOptions> Initiative = new NC<InitiativeOptions> ();
		public readonly INC<MultiNpcSuffixOptions> MultiNpcSuffix = new NC<MultiNpcSuffixOptions> ();
		public readonly INC<bool> IsCustomNpcSuffix = new NC<bool> ();
		public readonly INC<string> MultiNpcCustomSuffix = new NC<string> ();

		public ICommand SaveOptions => new MvxCommand (DoSaveOptions);

		public MainOptionsViewModel (ILocalSettings settings) : base (settings)
		{
			Initiative.Value = settings.GetSavedInitiate ();
			MultiNpcSuffix.Value = settings.GetMultipleNpcOption ();
			IsCustomNpcSuffix.Value = MultiNpcSuffix.Value == MultiNpcSuffixOptions.Custom;
			MultiNpcCustomSuffix.Value = settings.MultiNpcCustomSuffix;
		}

		void DoSaveOptions ()
		{
			settings.SetSavedInitiate (Initiative.Value);
			settings.SetMultipleNpcOption (MultiNpcSuffix.Value);
			settings.SetMultiNpcCustomSuffix (MultiNpcCustomSuffix.Value);
			Close (this);
		}
	}
}
