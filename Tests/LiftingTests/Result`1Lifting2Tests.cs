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

	[Theory(DisplayName = "Lifting over error results returns an error")]
	[ClassData(typeof(Result1_Lift2ErrorTestData))]
	public void Test12(
		Result<string> r1,
		Result<string> r2)
	{
		var lift = Result.Lifting.Lift(r1, r2);

		lift.IsSuccess.Should().BeFalse();
		lift.OnError(e => e.Should().Be("error"));
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

	[Theory(DisplayName = "Lifting async over error results returns an error")]
	[ClassData(typeof(Result1_LiftAsync2ErrorTestData))]
	public async Task Test22(
		Task<Result<string>> r1,
		Task<Result<string>> r2)
	{
		var lift = await Result.Lifting.LiftAsync(r1, r2);

		lift.IsSuccess.Should().BeFalse();
		lift.OnError(e => e.Should().Be("error"));
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

	[Theory(DisplayName = "Lifting lazy over error results returns an error")]
	[ClassData(typeof(Result1_LiftLazy2ErrorTestData))]
	public void Test32(
		Func<Result<string>> r1,
		Func<Result<string>> r2)
	{
		var lift = Result.Lifting.LiftLazy(r1, r2);

		lift.IsSuccess.Should().BeFalse();
		lift.OnError(e => e.Should().Be("error"));
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

	[Theory(DisplayName = "Lifting lazy async over error results returns an error")]
	[ClassData(typeof(Result1_LiftLazyAsync2ErrorTestData))]
	public async Task Test42(
		Func<Task<Result<string>>> r1,
		Func<Task<Result<string>>> r2)
	{
		var lift = await Result.Lifting.LiftLazyAsync(r1, r2);

		lift.IsSuccess.Should().BeFalse();
		lift.OnError(e => e.Should().Be("error"));
	}

	#endregion
}

public class Result1_Lift2ErrorTestData : IEnumerable<object[]>
{
	private readonly IGenerator g;

	public Result1_Lift2ErrorTestData()
		=> g = Result1TestDataGenerator.AsResults();

	public IEnumerator<object[]> GetEnumerator()
	{
		yield return g.Generate(2, 0);
		yield return g.Generate(2, 1);
	}

	IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
}

public class Result1_LiftAsync2ErrorTestData : IEnumerable<object[]>
{
	private readonly IGenerator g;

	public Result1_LiftAsync2ErrorTestData()
		=> g = Result1TestDataGenerator.AsTasks();

	public IEnumerator<object[]> GetEnumerator()
	{
		yield return g.Generate(2, 0);
		yield return g.Generate(2, 1);
	}

	IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
}

public class Result1_LiftLazy2ErrorTestData : IEnumerable<object[]>
{
	private readonly IGenerator g;

	public Result1_LiftLazy2ErrorTestData()
		=> g = Result1TestDataGenerator.AsFunctions();

	public IEnumerator<object[]> GetEnumerator()
	{
		yield return g.Generate(2, 0);
		yield return g.Generate(2, 1);
	}

	IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
}

public class Result1_LiftLazyAsync2ErrorTestData : IEnumerable<object[]>
{
	private readonly IGenerator g;

	public Result1_LiftLazyAsync2ErrorTestData()
		=> g = Result1TestDataGenerator.AsFunctionTasks();

	public IEnumerator<object[]> GetEnumerator()
	{
		yield return g.Generate(2, 0);
		yield return g.Generate(2, 1);
	}

	IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
}