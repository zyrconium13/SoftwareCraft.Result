namespace Tests.LiftingTests;

using System;
using System.Collections;

using FluentAssertions;

using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using SampleTypes.Reference;
using SampleTypes.Value;

using SoftwareCraft.Functional;

using Xunit;

public class Result2Lifting3Tests
{
	#region Lift

	[Fact(DisplayName = "Lifting over three successes returns success")]
	public void Test11()
	{
		var r1 = Result.Success<RedDragon, PinkLily>(new());
		var r2 = Result.Success<RedDragon, PinkLily>(new());
		var r3 = Result.Success<RedDragon, PinkLily>(new());

		var lift = Result.Lifting.Lift(r1, r2, r3);

		lift.IsSuccess.Should().BeTrue();
	}

	[Theory(DisplayName = "Lifting over error results returns an error")]
	[ClassData(typeof(Result2_Lift3ErrorTestData))]
	public void Test12(
		Result<RedDragon, string> r1,
		Result<RedDragon, string> r2,
		Result<RedDragon, string> r3)
	{
		var lift = Result.Lifting.Lift(r1, r2, r3);

		lift.IsSuccess.Should().BeFalse();
		lift.OnError(e => e.Should().Be("error"));
	}

	#endregion

	#region LiftLazy

	[Fact(DisplayName = "Lifting lazy over three successes returns success")]
	public void Test21()
	{
		var fr1 = () => Result.Success<RedDragon, string>(new());
		var fr2 = () => Result.Success<RedDragon, string>(new());
		var fr3 = () => Result.Success<RedDragon, string>(new());

		var lift = Result.Lifting.LiftLazy(fr1, fr2, fr3);

		lift.IsSuccess.Should().BeTrue();
	}

	[Theory(DisplayName = "Lifting lazy over error results returns an error")]
	[ClassData(typeof(Result2_LiftLazy3ErrorTestData))]
	public void Test22(
		Func<Result<RedDragon, string>> r1,
		Func<Result<RedDragon, string>> r2,
		Func<Result<RedDragon, string>> r3)
	{
		var lift = Result.Lifting.LiftLazy(r1, r2, r3);

		lift.IsSuccess.Should().BeFalse();
		lift.OnError(e => e.Should().Be("error"));
	}

	#endregion

	#region LiftAsync

	[Fact(DisplayName = "Lifting async over three successes returns success")]
	public async Task Test31()
	{
		var tr1 = Task.FromResult(Result.Success<RedDragon, string>(new()));
		var tr2 = Task.FromResult(Result.Success<RedDragon, string>(new()));
		var tr3 = Task.FromResult(Result.Success<RedDragon, string>(new()));

		var lift = await Result.Lifting.LiftAsync(tr1, tr2, tr3);

		lift.IsSuccess.Should().BeTrue();
	}

	[Theory(DisplayName = "Lifting async over error results returns an error")]
	[ClassData(typeof(Result2_LiftAsync3ErrorTestData))]
	public async Task Test32(
		Task<Result<RedDragon, string>> r1,
		Task<Result<RedDragon, string>> r2,
		Task<Result<RedDragon, string>> r3)
	{
		var lift = await Result.Lifting.LiftAsync(r1, r2, r3);

		lift.IsSuccess.Should().BeFalse();
		lift.OnError(e => e.Should().Be("error"));
	}

	#endregion

	#region LiftLazyAsync

	[Fact(DisplayName = "Lifting lazy async over three successes returns success")]
	public async Task Test41()
	{
		var ftr1 = () => Task.FromResult(Result.Success<RedDragon, string>(new()));
		var ftr2 = () => Task.FromResult(Result.Success<RedDragon, string>(new()));
		var ftr3 = () => Task.FromResult(Result.Success<RedDragon, string>(new()));

		var lift = await Result.Lifting.LiftLazyAsync(ftr1, ftr2, ftr3);

		lift.IsSuccess.Should().BeTrue();
	}

	[Theory(DisplayName = "Lifting lazy async over error results returns an error")]
	[ClassData(typeof(Result2_LiftLazyAsync3ErrorTestData))]
	public async Task Test42(
		Func<Task<Result<RedDragon, string>>> r1,
		Func<Task<Result<RedDragon, string>>> r2,
		Func<Task<Result<RedDragon, string>>> r3)
	{
		var lift = await Result.Lifting.LiftLazyAsync(r1, r2, r3);

		lift.IsSuccess.Should().BeFalse();
		lift.OnError(e => e.Should().Be("error"));
	}

	#endregion
}

public class Result2_Lift3ErrorTestData : IEnumerable<object[]>
{
	public IEnumerator<object[]> GetEnumerator()
	{
		yield return new object[]
		{
			Result.Error<RedDragon, string>("error"),
			Result.Success<RedDragon, string>(new()),
			Result.Success<RedDragon, string>(new())
		};

		yield return new object[]
		{
			Result.Success<RedDragon, string>(new()),
			Result.Error<RedDragon, string>("error"),
			Result.Success<RedDragon, string>(new())
		};

		yield return new object[]
		{
			Result.Success<RedDragon, string>(new()),
			Result.Success<RedDragon, string>(new()),
			Result.Error<RedDragon, string>("error")
		};
	}

	IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
}

public class Result2_LiftLazy3ErrorTestData : IEnumerable<object[]>
{
	public IEnumerator<object[]> GetEnumerator()
	{
		yield return new object[]
		{
			() => Result.Error<RedDragon, string>("error"),
			() => Result.Success<RedDragon, string>(new()),
			() => Result.Success<RedDragon, string>(new())
		};

		yield return new object[]
		{
			() => Result.Success<RedDragon, string>(new()),
			() => Result.Error<RedDragon, string>("error"),
			() => Result.Success<RedDragon, string>(new())
		};

		yield return new object[]
		{
			() => Result.Success<RedDragon, string>(new()),
			() => Result.Success<RedDragon, string>(new()),
			() => Result.Error<RedDragon, string>("error")
		};
	}

	IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
}

public class Result2_LiftAsync3ErrorTestData : IEnumerable<object[]>
{
	public IEnumerator<object[]> GetEnumerator()
	{
		yield return new object[]
		{
			Task.FromResult(Result.Error<RedDragon, string>("error")),
			Task.FromResult(Result.Success<RedDragon, string>(new())),
			Task.FromResult(Result.Success<RedDragon, string>(new()))
		};

		yield return new object[]
		{
			Task.FromResult(Result.Success<RedDragon, string>(new())),
			Task.FromResult(Result.Error<RedDragon, string>("error")),
			Task.FromResult(Result.Success<RedDragon, string>(new()))
		};

		yield return new object[]
		{
			Task.FromResult(Result.Success<RedDragon, string>(new())),
			Task.FromResult(Result.Success<RedDragon, string>(new())),
			Task.FromResult(Result.Error<RedDragon, string>("error"))
		};
	}

	IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
}

public class Result2_LiftLazyAsync3ErrorTestData : IEnumerable<object[]>
{
	public IEnumerator<object[]> GetEnumerator()
	{
		yield return new object[]
		{
			() => Task.FromResult(Result.Error<RedDragon, string>("error")),
			() => Task.FromResult(Result.Success<RedDragon, string>(new())),
			() => Task.FromResult(Result.Success<RedDragon, string>(new()))
		};

		yield return new object[]
		{
			() => Task.FromResult(Result.Success<RedDragon, string>(new())),
			() => Task.FromResult(Result.Error<RedDragon, string>("error")),
			() => Task.FromResult(Result.Success<RedDragon, string>(new()))
		};

		yield return new object[]
		{
			() => Task.FromResult(Result.Success<RedDragon, string>(new())),
			() => Task.FromResult(Result.Success<RedDragon, string>(new())),
			() => Task.FromResult(Result.Error<RedDragon, string>("error"))
		};
	}

	IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
}