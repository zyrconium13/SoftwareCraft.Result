namespace Tests.Success1Tests
{
	using System;
	using System.Linq;

	using Microsoft.VisualStudio.TestTools.UnitTesting;

	using SoftwareCraft.Functional;

	[TestClass]
	public sealed class MappingTests
	{
		private readonly Result<string> result;

		private readonly Spy spy;

		public MappingTests()
		{
			result = Result.Success<string>();
			spy = new Spy();
		}

		[TestMethod]
		public void DoesNotMapErrorValue()
		{
			var newResult = result.Select(e =>
			{
				spy.Trip(e);
				return new Dummy();
			});

			spy.VerifyTrip(0);
			Assert.IsInstanceOfType(newResult, typeof(Result<Dummy>));
			Assert.IsInstanceOfType(newResult, typeof(Success<Dummy>));
		}

		[TestMethod]
		public void DoesNotMapErrorValue2()
		{
			var newResult = result.SelectMany(e =>
			{
				spy.Trip(e);
				return Result.Success<Dummy>();
			});

			spy.VerifyTrip(0);
			Assert.IsInstanceOfType(newResult, typeof(Result<Dummy>));
			Assert.IsInstanceOfType(newResult, typeof(Success<Dummy>));
		}
	}
}