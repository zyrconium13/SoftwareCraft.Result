namespace Tests.Success1Tests
{
	using System;
	using System.Linq;

	using Microsoft.VisualStudio.TestTools.UnitTesting;

	using SampleTypes.Reference;

	using SoftwareCraft.Functional;

	[TestClass]
	public class MatchingTests
	{
		[TestMethod]
		public void ActionMatchingOverloadInvokesTheSuccessBranch()
		{
			var result = Result.Success<string>();

			var spy = new Spy();

			result.Match(
				() => { spy.Trip(); },
				e => { spy.Trip(e); }
			);

			spy.VerifyTrip(1);
		}

		[TestMethod]
		public void FunctionMatchingOverloadInvokesTheSuccessBranch()
		{
			var successDummy = new RedDragon();
			var errorDummy = new RedDragon();

			var result = Result.Success<string>();

			var matchResult = result.Match(
				() => successDummy,
				e => errorDummy);

			Assert.AreSame(successDummy, matchResult);
			Assert.AreNotSame(errorDummy, matchResult);
		}
	}
}