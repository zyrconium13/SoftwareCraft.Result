namespace Tests.Error1Tests
{
	using System;
	using System.Linq;

	using Microsoft.VisualStudio.TestTools.UnitTesting;

	using SoftwareCraft.Functional;

	[TestClass]
	public sealed class MappingTests : IDisposable
	{
		private readonly string errorValue;

		private readonly Result<string> result;

		private readonly Spy spy;

		public MappingTests()
		{
			errorValue = "error";
			result = Result.Error(errorValue);
			spy = new Spy();
		}

		public void Dispose()
		{
			spy?.VerifyTrip(1, errorValue);
		}

		[TestMethod]
		public void MapsAndWrapsErrorValue()
		{
			var newResult = result.Select(e =>
			{
				spy.Trip(e);
				return new Dummy();
			});

			Assert.IsInstanceOfType(newResult, typeof(Result<Dummy>));
		}

		[TestMethod]
		public void MapsAndFlattensErrorValue()
		{
			var newResult = result.SelectMany(e =>
			{
				spy.Trip(e);
				return Result.Error(new Dummy());
			});

			Assert.IsInstanceOfType(newResult, typeof(Result<Dummy>));
		}
	}

	public class Dummy { }
}