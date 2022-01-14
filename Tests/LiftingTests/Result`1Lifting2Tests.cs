﻿namespace Tests.LiftingTests;

using System;
using System.Collections.Generic;

using FluentAssertions;

using System.Linq;
using System.Threading.Tasks;

using SampleTypes.Value;

using SoftwareCraft.Functional;

using Xunit;

public class Result1Lifting2Tests
{
	#region Lift

	[Fact(DisplayName = "Lifting over two successes returns success")]
	public void Test11()
	{
		var r1 = Result.Success<PinkLily>();
		var r2 = Result.Success<PinkLily>();

		var lift = Result.Lifting.Lift(r1, r2);

		lift.IsSuccess.Should().BeTrue();
	}

	[Fact(DisplayName = "Lifting over the first error returns an error")]
	public void Test12()
	{
		var r1 = Result.Error("A");
		var r2 = Result.Success<string>();

		var lift = Result.Lifting.Lift(r1, r2);

		lift.IsSuccess.Should().BeFalse();
		lift.OnError(error => error.Should().Be("A"));
	}

	[Fact(DisplayName = "Lifting over the second error returns an error")]
	public void Test13()
	{
		var r1 = Result.Success<string>();
		var r2 = Result.Error("B");

		var lift = Result.Lifting.Lift(r1, r2);

		lift.IsSuccess.Should().BeFalse();
		lift.OnError(error => error.Should().Be("B"));
	}

	#endregion

	#region LiftAsync

	[Fact(DisplayName = "Lifting async over two successes returns success")]
	public async Task Test21()
	{
		var tr1 = Task.FromResult(Result.Success<PinkLily>());
		var tr2 = Task.FromResult(Result.Success<PinkLily>());

		var lift = await Result.Lifting.LiftAsync(tr1, tr2);

		lift.IsSuccess.Should().BeTrue();
	}

	[Fact(DisplayName = "Lifting async over the first error returns an error")]
	public async Task Test22()
	{
		var tr1 = Task.FromResult(Result.Error("A"));
		var tr2 = Task.FromResult(Result.Success<string>());

		var lift = await Result.Lifting.LiftAsync(tr1, tr2);

		lift.IsSuccess.Should().BeFalse();
		lift.OnError(error => error.Should().Be("A"));
	}

	[Fact(DisplayName = "Lifting async over the second error returns an error")]
	public async Task Test23()
	{
		var tr1 = Task.FromResult(Result.Success<string>());
		var tr2 = Task.FromResult(Result.Error("B"));

		var lift = await Result.Lifting.LiftAsync(tr1, tr2);

		lift.IsSuccess.Should().BeFalse();
		lift.OnError(error => error.Should().Be("B"));
	}

	#endregion

	#region LiftLazy

	[Fact(DisplayName = "Lifting lazy over two successes returns success")]
	public void Test31()
	{
		var fr1 = Result.Success<PinkLily>;
		var fr2 = Result.Success<PinkLily>;

		var lift = Result.Lifting.LiftLazy(fr1, fr2);

		lift.IsSuccess.Should().BeTrue();
	}

	[Fact(DisplayName = "Lifting lazy over the first error returns an error")]
	public void Test32()
	{
		var fr1 = () => Result.Error("A");
		var fr2 = Result.Success<string>;

		var lift = Result.Lifting.LiftLazy(fr1, fr2);

		lift.IsSuccess.Should().BeFalse();
		lift.OnError(error => error.Should().Be("A"));
	}

	[Fact(DisplayName = "Lifting lazy over the second error returns an error")]
	public void Test33()
	{
		var fr1 = Result.Success<string>;
		var fr2 = () => Result.Error("B");

		var lift = Result.Lifting.LiftLazy(fr1, fr2);

		lift.IsSuccess.Should().BeFalse();
		lift.OnError(error => error.Should().Be("B"));
	}

	#endregion

	#region LiftLazyAsync

	[Fact(DisplayName = "Lifting lazy async over two successes returns success")]
	public async Task Test41()
	{
		var ftr1 = () => Task.FromResult(Result.Success<PinkLily>());
		var ftr2 = () => Task.FromResult(Result.Success<PinkLily>());

		var lift = await Result.Lifting.LiftLazyAsync(ftr1, ftr2);

		lift.IsSuccess.Should().BeTrue();
	}

	[Fact(DisplayName = "Lifting lazy async over the first error returns an error")]
	public async Task Test42()
	{
		var ftr1 = () => Task.FromResult(Result.Error("A"));
		var ftr2 = () => Task.FromResult(Result.Success<string>());

		var lift = await Result.Lifting.LiftLazyAsync(ftr1, ftr2);

		lift.IsSuccess.Should().BeFalse();
		lift.OnError(error => error.Should().Be("A"));
	}

	[Fact(DisplayName = "Lifting lazy async over the second error returns an error")]
	public async Task Test43()
	{
		var ftr1 = () => Task.FromResult(Result.Success<string>());
		var ftr2 = () => Task.FromResult(Result.Error("B"));

		var lift = await Result.Lifting.LiftLazyAsync(ftr1, ftr2);

		lift.IsSuccess.Should().BeFalse();
		lift.OnError(error => error.Should().Be("B"));
	}

	#endregion
}