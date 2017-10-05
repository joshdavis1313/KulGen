using System;
using System.Collections.Generic;

namespace KulGen.Core.PropertyDependency
{
	[AttributeUsage(AttributeTargets.Property | AttributeTargets.Method)]
	public class DependsOnAttribute : Attribute
	{
		public IEnumerable<string> DependProperties
		{
			get;
			set;
		}

		public DependsOnAttribute(params string[] otherProperties)
		{
			DependProperties = otherProperties;
		}
	}
}