using System;
using KulGen.Core;
using MvvmCross.Core.ViewModels;
using MvvmCross.FieldBinding;

namespace KulGen.ViewModels
{
	public class BaseViewModel : MvxViewModel
	{
		public readonly INC<bool> Loading = new NC<bool>();
		public readonly INC<string> ErrorMessage = new NC<string>();

		protected readonly ILocalSettings settings;

		public BaseViewModel(ILocalSettings settings)
		{
			this.settings = settings;
		}
	}
}
