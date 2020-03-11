namespace Tests.Error1Tests
{
	using System;
	using System.Linq;

	using Microsoft.VisualStudio.TestTools.UnitTesting;

	using SoftwareCraft.Functional;

	[TestClass]
	public class ValidationTests
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