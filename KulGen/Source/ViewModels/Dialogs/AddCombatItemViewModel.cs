using System;
using System.Windows.Input;
using KulGen.Core;
using MvvmCross.Core.ViewModels;

namespace KulGen.Source.ViewModels.Dialogs
{
	public class AddCombatItemViewModel : BaseViewModel
	{
		public string Title { get; }
		public string Description { get; }

		public ICommand AddClicked => new MvxCommand(DoAdd);
		public ICommand CloseClicked => new MvxCommand(DoClose);

		public AddCombatItemViewModel(ILocalSettings settings) : base(settings)
		{
		}

		void DoAdd()
		{
			
		}

		void DoClose()
		{
			
		}
	}
}
