namespace Tests.Success1Tests
{
	using System;
	using System.Linq;

	using Microsoft.VisualStudio.TestTools.UnitTesting;

	using SampleTypes.Value;

	using SoftwareCraft.Functional;

	[TestClass]
	public class OnMethodsTests
	{
		private readonly Result<PinkLily> result;

		private readonly Spy spy;

		public OnMethodsTests()
		{
			result = Result.Success<PinkLily>();

			spy = new Spy();
		}

		[TestMethod]
		public void OnSuccessIsCalled()
		{
			var forwardedResult = result.OnSuccess(() => { spy.Trip(); });

			spy.VerifyTrip(1);

			Assert.AreSame(result, forwardedResult);
		}

		[TestMethod]
		public void OnErrorIsNotCalled()
		{
			var forwardedResult = result.OnError(e => { spy.Trip(e); });

			spy.VerifyTrip(0);

			Assert.AreSame(result, forwardedResult);
		}

		[TestMethod]
		public void OnBothIsCalled()
		{
			var forwardedResult = result.OnBoth(() => { spy.Trip(); });

			spy.VerifyTrip(1);

			Assert.AreSame(result, forwardedResult);
		}
	}
}