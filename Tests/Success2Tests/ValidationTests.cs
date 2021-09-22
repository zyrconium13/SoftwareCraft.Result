namespace Tests.Success2Tests
{
	using System;
	using System.Linq;

	using Microsoft.VisualStudio.TestTools.UnitTesting;

	using SampleTypes.Reference;
	using SampleTypes.Value;

	using SoftwareCraft.Functional;

	[TestClass]
	public class ValidationTests
	{
		[TestMethod]
		public void CannotAssignDefaultValueToReferenceTypes()
		{
			Assert.ThrowsException<InvalidOperationException>
				(() => Result.Success<RedDragon, VioletIris>(default));
		}

		[TestMethod]
		public void CannotAssignDefaultValueToNullableValueTypes()
		{
			Assert.ThrowsException<InvalidOperationException>(() => Result.Success<int?, VioletIris>(default));
		}

		[TestMethod]
		public void CanAssignDefaultValueToValueTypes()
		{
			Assert.IsNotNull(Result.Success<int, VioletIris>(default));
		}
	}
}