﻿namespace Tests.Success2Tests
{
	using System;
	using System.Linq;

	using Microsoft.VisualStudio.TestTools.UnitTesting;

	using SampleTypes.Reference;
	using SampleTypes.Value;

	using SoftwareCraft.Functional;

	[TestClass]
	public sealed class SwitchingTests
	{
		private readonly Result<RedDragon, PinkLily> result;

		private readonly Spy spy;

		private readonly RedDragon successValue;

		public SwitchingTests()
		{
			successValue = new RedDragon();

			result = Result.Success<RedDragon, PinkLily>(successValue);

			spy = new Spy();
		}

		[TestMethod]
		public void SwitchesToResult1AndChangesTheErrorType()
		{
			// Result<RedDragon, PinkLily> -> Result<GreenTurtle>

			var mappedResult = result.SelectSwitch(
				e =>
				{
					spy.Trip(e);
					return new GreenTurtle();
				});

			Assert.IsInstanceOfType(mappedResult, typeof(Success<GreenTurtle>));
			spy.VerifyTrip(0);
		}

		[TestMethod]
		public void SwitchesToResult1ButDoesNotChangeTheErrorType()
		{
			// Result<RedDragon, PinkLily> -> Result<PinkLily>

			var mappedResult = result.SelectSwitch();

			Assert.IsInstanceOfType(mappedResult, typeof(Success<PinkLily>));
			spy.VerifyTrip(0);
		}

		[TestMethod]
		public void SwitchesToResult1AndChangesTheErrorTypeAndFlattens()
		{
			// Result<RedDragon, PinkLily> -> Result<GreenTurtle>

			var mappedResult = result.SelectMany(
				v =>
				{
					spy.Trip(v);
					return Result.Success<GreenTurtle>();
				},
				e =>
				{
					spy.Trip(e);
					return Result.Error(new GreenTurtle());
				});

			Assert.IsInstanceOfType(mappedResult, typeof(Success<GreenTurtle>));
			spy.VerifyTrip(1, successValue);
		}

		[TestMethod]
		public void SwitchesToResult1ButDoesNotChangeTheErrorTypeAndFlattens()
		{
			// Result<RedDragon, PinkLily> -> Result<PinkLily>

			var mappedResult = result.SelectMany(
				v =>
				{
					spy.Trip(v);
					return Result.Success<PinkLily>();
				});

			Assert.IsInstanceOfType(mappedResult, typeof(Success<PinkLily>));
			spy.VerifyTrip(1, successValue);
		}
	}
}