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
		public void MapsAndWrapsTheValue()
		{
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
	}
}