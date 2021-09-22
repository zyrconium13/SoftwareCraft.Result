namespace Tests.Success1Tests
{
	using System;
	using System.Collections.Generic;
	using System.Linq;

	using Microsoft.VisualStudio.TestTools.UnitTesting;

	using SampleTypes.Value;

	using SoftwareCraft.Functional;

	[TestClass]
	public sealed class MappingTests
	{
		private readonly Result<VioletIris> result;

		private readonly Spy spy;

		public MappingTests()
		{
			result = Result.Success<VioletIris>();
			spy    = new();
		}

		[TestMethod]
		public void DoesNotMapErrorValue()
		{
			var newResult = result.Select(
				() => { },
				e =>
				{
					spy.Trip(e);
					return new PinkLily();
				});

			spy.VerifyTrip(0);
			Assert.IsInstanceOfType(newResult, typeof(Success<PinkLily>));
		}

		[TestMethod]
		public void DoesNotMapErrorValue2()
		{
			var newResult = result.SelectMany(
				Result.Success<PinkLily>,
				e =>
				{
					spy.Trip(e);
					return Result.Success<PinkLily>();
				});

			spy.VerifyTrip(0);
			Assert.IsInstanceOfType(newResult, typeof(Success<PinkLily>));
		}
	}
}