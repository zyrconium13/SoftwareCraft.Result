namespace Tests.LiftingTests;

using System;

using FluentAssertions;

using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using SampleTypes.Reference;
using SampleTypes.Value;

using SoftwareCraft.Functional;

using Xunit;

public class Result2Lifting2Tests
{
	#region Lift

	[Fact(DisplayName = "Lifting over two successes returns success")]
	public void Test11()
	{
		var r1 = Result.Success<RedDragon, PinkLily>(new());
		var r2 = Result.Success<RedDragon, PinkLily>(new());

		var lift = Result.Lifting.Lift(r1, r2);

		lift.IsSuccess.Should().BeTrue();
	}

	[Fact(DisplayName = " Lifting over the first error returns an error")]
	public void Test12()
	{
		var r1 = Result.Error<RedDragon, string>("A");
		var r2 = Result.Success<RedDragon, string>(new());

		var lift = Result.Lifting.Lift(r1, r2);

		lift.IsSuccess.Should().BeFalse();
		lift.OnError(e => e.Should().Be("A"));
	}

	[Fact(DisplayName = " Lifting over the second error returns an error")]
	public void Test13()
	{
		var r1 = Result.Success<RedDragon, string>(new());
		var r2 = Result.Error<RedDragon, string>("B");

		var lift = Result.Lifting.Lift(r1, r2);

		lift.IsSuccess.Should().BeFalse();
		lift.OnError(e => e.Should().Be("B"));
	}

	#endregion

	#region LiftLazy

	[Fact(DisplayName = "Lifting lazy over two successes returns success")]
	public void Test21()
	{
		var fr1 = () => Result.Success<RedDragon, string>(new());
		var fr2 = () => Result.Success<RedDragon, string>(new());

		var lift = Result.Lifting.LiftLazy(fr1, fr2);

		lift.IsSuccess.Should().BeTrue();
	}

	[Fact(DisplayName = " Lifting lazy over the first error returns an error")]
	public void Test22()
	{
		var fr1 = () => Result.Error<RedDragon, string>("A");
		var fr2 = () => Result.Success<RedDragon, string>(new());

		var lift = Result.Lifting.LiftLazy(fr1, fr2);

		lift.IsSuccess.Should().BeFalse();
		lift.OnError(e => e.Should().Be("A"));
	}

	[Fact(DisplayName = " Lifting lazy over the second error returns an error")]
	public void Test23()
	{
		var fr1 = () => Result.Success<RedDragon, string>(new());
		var fr2 = () => Result.Error<RedDragon, string>("B");

		var lift = Result.Lifting.LiftLazy(fr1, fr2);

		lift.IsSuccess.Should().BeFalse();
		lift.OnError(e => e.Should().Be("B"));
	}

	#endregion

	#region LiftAsync

	[Fact(DisplayName = "Lifting async over two successes returns success")]
	public async Task Test31()
	{
		var tr1 = Task.FromResult(Result.Success<RedDragon, string>(new()));
		var tr2 = Task.FromResult(Result.Success<RedDragon, string>(new()));

		var lift = await Result.Lifting.LiftAsync(tr1, tr2);

		lift.IsSuccess.Should().BeTrue();
	}

	[Fact(DisplayName = " Lifting async over the first error returns an error")]
	public async Task Test32()
	{
		var tr1 = Task.FromResult(Result.Error<RedDragon, string>("A"));
		var tr2 = Task.FromResult(Result.Success<RedDragon, string>(new()));

		var lift = await Result.Lifting.LiftAsync(tr1, tr2);

		lift.IsSuccess.Should().BeFalse();
		lift.OnError(e => e.Should().Be("A"));
	}

	[Fact(DisplayName = " Lifting async over the second error returns an error")]
	public async Task Test33()
	{
		var tr1 = Task.FromResult(Result.Success<RedDragon, string>(new()));
		var tr2 = Task.FromResult(Result.Error<RedDragon, string>("B"));

		var lift = await Result.Lifting.LiftAsync(tr1, tr2);

		lift.IsSuccess.Should().BeFalse();
		lift.OnError(e => e.Should().Be("B"));
	}

	#endregion

	#region LiftLazyAsync

	[Fact(DisplayName = "Lifting lazy async over two successes returns success")]
	public async Task Test41()
	{
		var ftr1 = () => Task.FromResult(Result.Success<RedDragon, string>(new()));
		var ftr2 = () => Task.FromResult(Result.Success<RedDragon, string>(new()));

		var lift = await Result.Lifting.LiftLazyAsync(ftr1, ftr2);

		lift.IsSuccess.Should().BeTrue();
	}

	[Fact(DisplayName = " Lifting lazy async over the first error returns an error")]
	public async Task Test42()
	{
		var ftr1 = () => Task.FromResult(Result.Error<RedDragon, string>("A"));
		var ftr2 = () => Task.FromResult(Result.Success<RedDragon, string>(new()));

		var lift = await Result.Lifting.LiftLazyAsync(ftr1, ftr2);

		lift.IsSuccess.Should().BeFalse();
		lift.OnError(e => e.Should().Be("A"));
	}

	[Fact(DisplayName = " Lifting lazy async over the second error returns an error")]
	public async Task Test43()
	{
		var ftr1 = () => Task.FromResult(Result.Success<RedDragon, string>(new()));
		var ftr2 = () => Task.FromResult(Result.Error<RedDragon, string>("B"));

		var lift = await Result.Lifting.LiftLazyAsync(ftr1, ftr2);

		lift.IsSuccess.Should().BeFalse();
		lift.OnError(e => e.Should().Be("B"));
	}

	#endregion
}