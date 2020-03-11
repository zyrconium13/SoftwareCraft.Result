namespace Tests.Error1Tests
{
	using System;
	using System.Linq;

	using Microsoft.VisualStudio.TestTools.UnitTesting;

	using SoftwareCraft.Functional;

	[TestClass]
	public class MatchingTests
	{
		[TestMethod]
		public void ActionMatchingOverloadInvokesTheErrorBranchWithTheProvidedErrorValue()
		{
			const string errorValue = "error";

			var result = Result.Error(errorValue);

			var spy = new Spy();

			result.Match(
				() => { spy.Trip(); },
				e => { spy.Trip(e); }
			);

			spy.VerifyTrip(1, errorValue);
		}

		[TestMethod]
		public void FunctionMatchingOverloadInvokesTheErrorBranchWithTheProvidedErrorValue()
		{
			const string errorValue = "error";

			var result = Result.Error(errorValue);

			var matchResult = result.Match(
				() => null,
				e => e);

			Assert.AreEqual(errorValue, matchResult);
		}
	}
}