using System;
using Android.Views;
using KulGen.Source.ViewModels.Dialogs;
using MvvmCross.Binding.BindingContext;

namespace KulGen.Droid.Source.Views.Dialogs
{
	public class AddCombatItemView : BaseDialogFragment<AddCombatItemView, AddCombatItemViewModel>
	{
		protected override int LayoutId => Resource.Layout.add_combat_item_layout;

		protected override void OnInitializeComponents(View view)
		{
			
		}

		protected override void SetupBindings(MvxFluentBindingDescriptionSet<AddCombatItemView, AddCombatItemViewModel> bindingSet, View view)
		{
			
		}
	}
}
