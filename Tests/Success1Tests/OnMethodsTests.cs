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
		private readonly Result<PinkLily> sut;

		private readonly Spy spy;

		public OnMethodsTests()
		{
			sut = Result.Success<PinkLily>();

			spy = new Spy();
		}

		[TestMethod]
		public void OnSuccessIsCalled()
		{
			var forwardedResult = sut.OnSuccess(() => { spy.Trip(); });

			spy.VerifyTrip(1);

			Assert.AreSame(sut, forwardedResult);
		}

		[TestMethod]
		public void OnErrorIsNotCalled()
		{
			var forwardedResult = sut.OnError(e => { spy.Trip(e); });

			spy.VerifyTrip(0);

			Assert.AreSame(sut, forwardedResult);
		}

		[TestMethod]
		public void OnBothIsCalled()
		{
			var forwardedResult = sut.OnBoth(() => { spy.Trip(); });

			spy.VerifyTrip(1);

			Assert.AreSame(sut, forwardedResult);
		}
	}
}