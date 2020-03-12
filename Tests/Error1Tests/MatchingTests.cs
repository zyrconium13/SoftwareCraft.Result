namespace Tests.Error1Tests
{
	using System;
	using System.Linq;

	using Microsoft.VisualStudio.TestTools.UnitTesting;

	using SampleTypes.Value;

	using SoftwareCraft.Functional;

	[TestClass]
	public class MatchingTests
	{
		[TestMethod]
		public void ActionMatchingOverloadInvokesTheErrorBranchWithTheProvidedErrorValue()
		{
			var result = Result.Error(new PinkLily());

			var spy = new Spy();

			var matchValue = new VioletIris();
			var matchError = new VioletIris();

			result.Match(
				() => { spy.Trip(matchValue); },
				e => { spy.Trip(matchError); }
			);

			spy.VerifyTrip(1, matchError);
		}

		[TestMethod]
		public void FunctionMatchingOverloadInvokesTheErrorBranchWithTheProvidedErrorValue()
		{
			var result = Result.Error(new PinkLily());

			var matchValue = new VioletIris();
			var matchError = new VioletIris();

			var matchResult = result.Match(
				() => matchValue,
				e => matchError);

			Assert.AreEqual(matchError, matchResult);
		}
	}
}