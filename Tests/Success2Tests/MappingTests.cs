namespace Tests.Success2Tests
{
	using System;
	using System.Linq;

	using Microsoft.VisualStudio.TestTools.UnitTesting;

	using SampleTypes.Reference;
	using SampleTypes.Value;

	using SoftwareCraft.Functional;

	[TestClass]
	public sealed class MappingTests
	{
		private readonly Result<RedDragon, PinkLily> result;

		private readonly Spy spy;

		private readonly RedDragon successValue;

		public MappingTests()
		{
			successValue = new RedDragon();

			result = Result.Success<RedDragon, PinkLily>(successValue);

			spy = new Spy();
		}

		[TestMethod]
		public void MapsAndWrapsTheValueAndChangesTheErrorType()
		{
			// Result<RedDragon, PinkLily> -> Result<VioletIris, GreenTurtle>

			var mappedResult = result.Select(
				v =>
				{
					spy.Trip(v);
					return new VioletIris();
				},
				e =>
				{
					spy.Trip(e);
					return new GreenTurtle();
				});

			Assert.IsInstanceOfType(mappedResult, typeof(Success<VioletIris, GreenTurtle>));
			spy.VerifyTrip(1, successValue);
		}

		[TestMethod]
		public void MapsAndFlattensTheValueAndChangesTheErrorType()
		{
			// Result<RedDragon, PinkLily> -> Result<VioletIris, GreenTurtle>

			var mappedResult = result.SelectMany(
				v =>
				{
					spy.Trip(v);
					return Result.Success<VioletIris, GreenTurtle>(new VioletIris());
				},
				e =>
				{
					spy.Trip(e);
					return Result.Error<VioletIris, GreenTurtle>(new GreenTurtle());
				});

			Assert.IsInstanceOfType(mappedResult, typeof(Success<VioletIris, GreenTurtle>));
			spy.VerifyTrip(1, successValue);
		}

		[TestMethod]
		public void MapsAndFlattensTheValueButDoesNotChangeTheErrorType()
		{
			// Result<RedDragon, PinkLily> -> Result<VioletIris, PinkLily>

			var mappedResult = result.SelectMany(
				v =>
				{
					spy.Trip(v);
					return Result.Success<VioletIris, PinkLily>(new VioletIris());
				});

			Assert.IsInstanceOfType(mappedResult, typeof(Success<VioletIris, PinkLily>));
			spy.VerifyTrip(1, successValue);
		}
	}
}