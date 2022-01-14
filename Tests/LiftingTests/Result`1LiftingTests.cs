using System;
using System.Collections.Generic;

namespace Tests.LiftingTests;

using FluentAssertions;

using System.Linq;

using SampleTypes.Value;

using SoftwareCraft.Functional;

using Xunit;

public class Result1LiftingTests
{
	[Fact(DisplayName = "Lifting over two successes returns success")]
	public void Test1()
	{
		var r1 = Result.Success<PinkLily>();
		var r2 = Result.Success<PinkLily>();

		var lift = Result.Lifting.Lift(r1, r2);

		lift.IsSuccess.Should().BeTrue();
	}

	[Fact(DisplayName = "Lifting over the first error returns an error")]
	public void Test2()
	{
		var r1 = Result.Error("A");
		var r2 = Result.Success<string>();

		var lift = Result.Lifting.Lift(r1, r2);

		lift.IsSuccess.Should().BeFalse();
		lift.OnError(error => error.Should().Be("A"));
	}

	[Fact(DisplayName = "Lifting over the second error returns an error")]
	public void Test3()
	{
		var r1 = Result.Success<string>();
		var r2 = Result.Error("B");

		var lift = Result.Lifting.Lift(r1, r2);

		lift.IsSuccess.Should().BeFalse();
		lift.OnError(error => error.Should().Be("B"));
	}
}