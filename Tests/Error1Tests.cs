using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SoftwareCraft.Functional;

namespace Tests
{
	[TestClass]
	public class Error1Tests
	{
		[TestMethod]
		public void CannotAssignDefaultValueToReferenceTypes()
		{
			Assert.ThrowsException<InvalidOperationException>
				(() => Result.Error<SampleReferenceType>(default));
		}

		[TestMethod]
		public void CannotAssignDefaultValueToNullableValueTypes()
		{
			Assert.ThrowsException<InvalidOperationException>(() => Result.Error<int?>(default));
		}

		[TestMethod]
		public void CanAssignDefaultValueToValueTypes()
		{
			Assert.IsNotNull(Result.Error<int>(default));
		}
	}
}