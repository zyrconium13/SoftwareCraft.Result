namespace Tests.Error1Tests
{
	using System;
	using System.Linq;

	using Microsoft.VisualStudio.TestTools.UnitTesting;

	using SoftwareCraft.Functional;

	[TestClass]
	public class OnMethodsTests
	{
		private readonly string errorValue;

		private readonly Result<string> result;

		private readonly Spy spy;

		public OnMethodsTests()
		{
			errorValue = "error";

			result = Result.Error(errorValue);

			spy = new Spy();
		}

		[TestMethod]
		public void OnSuccessIsNotCalled()
		{
			var forwardedResult = result.OnSuccess(() => { spy.Trip(); });

			spy.VerifyTrip(0);

			Assert.AreSame(result, forwardedResult);
		}

		[TestMethod]
		public void OnErrorIsCalled()
		{
			var forwardedResult = result.OnError(e => { spy.Trip(e); });

			spy.VerifyTrip(1, errorValue);

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