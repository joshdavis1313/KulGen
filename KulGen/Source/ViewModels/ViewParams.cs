using System;
using System.Collections.Generic;
using KulGen.Source.ViewModels;
using MvvmCross.Core.ViewModels;

namespace KulGen.Source.ViewModels
{
	public class ViewParams
	{
		public const string ChildViewModel = "childViewModel";
		public const string DialogViewModel = "dialogViewModel";
		public const string DismissChildViewModels = "dismissChildren";
		public const string ClearAllButDashboardView = "dismissToDashboard";
		public const string OverlayToolbar = "overlayToolbar";
		public const string AnimatedIn = "animatedIn";
		public const string AnimatedClose = "animatedClose";

		public static MvxBundle ChildView<T>() where T : BaseViewModel
		{
			var type = typeof(T).FullName;
			return ChildView(type);
		}

		public static MvxBundle ChildView(string type)
		{
			return new MvxBundle(new Dictionary<string, string> { { ChildViewModel, type } });
		}

		public static MvxBundle DialogView<T>(bool overlayToolbar = false) where T : BaseViewModel
		{
			var type = typeof(T).FullName;
			return new MvxBundle(new Dictionary<string, string> { { DialogViewModel, type }, { OverlayToolbar, overlayToolbar.ToString() } });
		}

		public static MvxBundle DismissChildren()
		{
			return new MvxBundle(new Dictionary<string, string> { { DismissChildViewModels, null } });
		}

		public static MvxBundle ClearStackToDashboard()
		{
			return new MvxBundle(new Dictionary<string, string> { { ClearAllButDashboardView, null } });
		}

		public static MvxBundle AnimateTransition(bool isAnimated = true, MvxBundle existingParams = null)
		{
			return new MvxBundle(new Dictionary<string, string> { { AnimatedIn, isAnimated ? "true" : "false" } });
		}

		public static MvxBundle AnimateClose(bool isAnimated = true, MvxBundle existingParams = null)
		{
			return new MvxBundle(new Dictionary<string, string> { { AnimatedClose, isAnimated ? "true" : "false" } });
		}

	}
}
