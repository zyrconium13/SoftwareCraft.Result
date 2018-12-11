using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SoftwareCraft.Functional;

namespace Tests
{
	[TestClass]
	public class Success2Tests
	{
		[TestMethod]
		public void CannotAssignDefaultValueToReferenceTypes()
		{
			Assert.ThrowsException<InvalidOperationException>
				(() => Result.Success<SampleReferenceType, string>(default));
		}

		[TestMethod]
		public void CannotAssignDefaultValueToNullableValueTypes()
		{
			Assert.ThrowsException<InvalidOperationException>(() => Result.Success<int?, string>(default));
		}

		[TestMethod]
		public void CanAssignDefaultValueToValueTypes()
		{
			Assert.IsNotNull(Result.Success<int, string>(default));
		}
	}
}