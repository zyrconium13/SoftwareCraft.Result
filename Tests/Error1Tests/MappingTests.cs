﻿namespace Tests.Error1Tests
{
	using System;
	using System.Collections.Generic;
	using System.Linq;

	using Microsoft.VisualStudio.TestTools.UnitTesting;

	using SampleTypes.Value;

	using SoftwareCraft.Functional;

	[TestClass]
	public sealed class MappingTests : IDisposable
	{
		private readonly PinkLily errorValue;

		private readonly Result<PinkLily> result;

		private readonly Spy spy;

		public MappingTests()
		{
			errorValue = new();
			result     = Result.Error(errorValue);
			spy        = new();
		}

		public void Dispose()
		{
			spy?.VerifyTrip(1, errorValue);
		}

		[TestMethod]
		public void MapsAndWrapsErrorValue()
		{
			var newResult = result.Select(
				() => { },
				e =>
				{
					spy.Trip(e);
					return new VioletIris();
				});

			Assert.IsInstanceOfType(newResult, typeof(Result<VioletIris>));
			Assert.IsInstanceOfType(newResult, typeof(Error<VioletIris>));
		}

		[TestMethod]
		public void MapsAndFlattensErrorValue()
		{
			var newResult = result.SelectMany(
				Result.Success<VioletIris>,
				e =>
				{
					spy.Trip(e);
					return Result.Error(new VioletIris());
				});

			Assert.IsInstanceOfType(newResult, typeof(Result<VioletIris>));
			Assert.IsInstanceOfType(newResult, typeof(Error<VioletIris>));
		}
	}
}