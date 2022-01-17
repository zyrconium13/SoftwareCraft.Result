namespace Tests.LiftingTests;

using System;
using System.Collections;

using FluentAssertions;

using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using SampleTypes.Value;

using SoftwareCraft.Functional;

using TestData;

using Xunit;

public class Result1Lifting4Tests
{
	#region Lift

	[Fact(DisplayName = "Lifting over four successes returns success")]
	public void Test11()
	{
		var r1 = Result.Success<PinkLily>();
		var r2 = Result.Success<PinkLily>();
		var r3 = Result.Success<PinkLily>();
		var r4 = Result.Success<PinkLily>();

		var lift = Result.Lifting.Lift(r1, r2, r3, r4);

		lift.IsSuccess.Should().BeTrue();
	}

	[Theory(DisplayName = "Lifting over error results returns an error")]
	[ClassData(typeof(Result1_Lift4ErrorTestData))]
	public void Test12(
		Result<string> r1,
		Result<string> r2,
		Result<string> r3,
		Result<string> r4)
	{
		var lift = Result.Lifting.Lift(r1, r2, r3, r4);

		lift.IsSuccess.Should().BeFalse();
		lift.OnError(e => e.Should().Be("error"));
	}

	#endregion

	#region LiftAsync

	[Fact(DisplayName = "Lifting async over four successes returns success")]
	public async Task Test21()
	{
		var tr1 = Task.FromResult(Result.Success<PinkLily>());
		var tr2 = Task.FromResult(Result.Success<PinkLily>());
		var tr3 = Task.FromResult(Result.Success<PinkLily>());
		var tr4 = Task.FromResult(Result.Success<PinkLily>());

		var lift = await Result.Lifting.LiftAsync(tr1, tr2, tr3, tr4);

		lift.IsSuccess.Should().BeTrue();
	}

	[Theory(DisplayName = "Lifting async over error results returns an error")]
	[ClassData(typeof(Result1_LiftAsync4ErrorTestData))]
	public async Task Test22(
		Task<Result<string>> r1,
		Task<Result<string>> r2,
		Task<Result<string>> r3,
		Task<Result<string>> r4)
	{
		var lift = await Result.Lifting.LiftAsync(r1, r2, r3, r4);

		lift.IsSuccess.Should().BeFalse();
		lift.OnError(e => e.Should().Be("error"));
	}

	#endregion

	#region LiftLazy

	[Fact(DisplayName = "Lifting lazy over four successes returns success")]
	public void Test31()
	{
		var fr1 = Result.Success<PinkLily>;
		var fr2 = Result.Success<PinkLily>;
		var fr3 = Result.Success<PinkLily>;
		var fr4 = Result.Success<PinkLily>;

		var lift = Result.Lifting.LiftLazy(fr1, fr2, fr3, fr4);

		lift.IsSuccess.Should().BeTrue();
	}

	[Theory(DisplayName = "Lifting lazy over error results returns an error")]
	[ClassData(typeof(Result1_LiftLazy4ErrorTestData))]
	public void Test32(
		Func<Result<string>> r1,
		Func<Result<string>> r2,
		Func<Result<string>> r3,
		Func<Result<string>> r4)
	{
		var lift = Result.Lifting.LiftLazy(r1, r2, r3, r4);

		lift.IsSuccess.Should().BeFalse();
		lift.OnError(e => e.Should().Be("error"));
	}

	#endregion

	#region LiftLazyAsync

	[Fact(DisplayName = "Lifting lazy async over four successes returns success")]
	public async Task Test41()
	{
		var ftr1 = () => Task.FromResult(Result.Success<PinkLily>());
		var ftr2 = () => Task.FromResult(Result.Success<PinkLily>());
		var ftr3 = () => Task.FromResult(Result.Success<PinkLily>());
		var ftr4 = () => Task.FromResult(Result.Success<PinkLily>());

		var lift = await Result.Lifting.LiftLazyAsync(ftr1, ftr2, ftr3, ftr4);

		lift.IsSuccess.Should().BeTrue();
	}

	[Theory(DisplayName = "Lifting lazy async over error results returns an error")]
	[ClassData(typeof(Result1_LiftLazyAsync4ErrorTestData))]
	public async Task Test42(
		Func<Task<Result<string>>> r1,
		Func<Task<Result<string>>> r2,
		Func<Task<Result<string>>> r3,
		Func<Task<Result<string>>> r4)
	{
		var lift = await Result.Lifting.LiftLazyAsync(r1, r2, r3, r4);

		lift.IsSuccess.Should().BeFalse();
		lift.OnError(e => e.Should().Be("error"));
	}

	#endregion
}

public class Result1_Lift4ErrorTestData : IEnumerable<object[]>
{
	private readonly IGenerator g;

	public Result1_Lift4ErrorTestData()
		=> g = Result1TestDataGenerator.AsResults();

	public IEnumerator<object[]> GetEnumerator()
	{
		yield return g.Generate(4, 0);
		yield return g.Generate(4, 1);
		yield return g.Generate(4, 2);
		yield return g.Generate(4, 3);
	}

	IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
}

public class Result1_LiftAsync4ErrorTestData : IEnumerable<object[]>
{
	private readonly IGenerator g;

	public Result1_LiftAsync4ErrorTestData()
		=> g = Result1TestDataGenerator.AsTasks();

	public IEnumerator<object[]> GetEnumerator()
	{
		yield return g.Generate(4, 0);
		yield return g.Generate(4, 1);
		yield return g.Generate(4, 2);
		yield return g.Generate(4, 3);
	}

	IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
}

public class Result1_LiftLazy4ErrorTestData : IEnumerable<object[]>
{
	private readonly IGenerator g;

	public Result1_LiftLazy4ErrorTestData()
		=> g = Result1TestDataGenerator.AsFunctions();

	public IEnumerator<object[]> GetEnumerator()
	{
		yield return g.Generate(4, 0);
		yield return g.Generate(4, 1);
		yield return g.Generate(4, 2);
		yield return g.Generate(4, 3);
	}

	IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
}

public class Result1_LiftLazyAsync4ErrorTestData : IEnumerable<object[]>
{
	private readonly IGenerator g;

	public Result1_LiftLazyAsync4ErrorTestData()
		=> g = Result1TestDataGenerator.AsFunctionTasks();

	public IEnumerator<object[]> GetEnumerator()
	{
		yield return g.Generate(4, 0);
		yield return g.Generate(4, 1);
		yield return g.Generate(4, 2);
		yield return g.Generate(4, 3);
	}

	IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
}