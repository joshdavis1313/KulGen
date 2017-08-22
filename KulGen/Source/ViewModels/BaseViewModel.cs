using System;
using KulGen.Core;
using MvvmCross.Core.ViewModels;
using MvvmCross.FieldBinding;

namespace KulGen.Source.ViewModels
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

		protected void ShowChildViewModel<TViewModel, TChildViewModel>()
			where TViewModel : BaseViewModel
			where TChildViewModel : BaseViewModel
		{
			ShowChildViewModel<TChildViewModel>(typeof(TViewModel));
		}

		protected void ShowChildViewModel<TChildViewModel>()
			where TChildViewModel : BaseViewModel
		{
			ShowChildViewModel<TChildViewModel>(GetType());
		}

		void ShowChildViewModel<TChildViewModel>(Type parentType)
			where TChildViewModel : BaseViewModel
		{
			ShowViewModel(parentType, presentationBundle: ShireViewParams.ChildView<TChildViewModel>());
		}

		protected void ShowDialogViewModel<TViewModel, TChildViewModel>(object parametersObject = null)
			where TViewModel : BaseViewModel
			where TChildViewModel : BaseViewModel
		{
			ShowDialogViewModel<TChildViewModel>(typeof(TViewModel), parametersObject);
		}

		protected void ShowDialogViewModel<TChildViewModel>(object parametersObject = null)
			where TChildViewModel : BaseViewModel
		{
			ShowDialogViewModel<TChildViewModel>(GetType(), parametersObject);
		}

		void ShowDialogViewModel<TChildViewModel>(Type parentType, object parametersObject = null)
			where TChildViewModel : BaseViewModel
		{
			ShowViewModel(parentType, parameterValuesObject: parametersObject, presentationBundle: ShireViewParams.DialogView<TChildViewModel>());
		}
	}
}
