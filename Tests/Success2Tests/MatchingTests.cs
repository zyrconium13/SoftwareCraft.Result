namespace Tests.Success2Tests
{
	using System;
	using System.Linq;

	using Microsoft.VisualStudio.TestTools.UnitTesting;

	using SampleTypes.Reference;
	using SampleTypes.Value;

	using SoftwareCraft.Functional;

	[TestClass]
	public class MatchingTests
	{
		[TestMethod]
		public void ActionMatchingOverloadInvokesTheSuccessBranch()
		{
			var value = new RedDragon();

			var result = Result.Success<RedDragon, string>(value);

			var spy = new Spy();

			result.Match(
				v => { spy.Trip(v); },
				e => { spy.Trip(e); }
			);

			spy.VerifyTrip(1, value);
		}

		[TestMethod]
		public void FunctionMatchingOverloadInvokesTheSuccessBranch()
		{
			var successDummy = new VioletIris();
			var errorDummy = new VioletIris();

			var result = Result.Success<RedDragon, string>(new RedDragon());

			var matchResult = result.Match(
				v => successDummy,
				e => errorDummy);

			Assert.AreEqual(successDummy, matchResult);
			Assert.AreNotSame(errorDummy, matchResult);
		}
	}
}