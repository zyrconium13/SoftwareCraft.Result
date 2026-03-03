namespace Tests.LiftingTests;

using System.Collections;
using SampleTypes.Reference;
using SampleTypes.Value;
using Shouldly;
using SoftwareCraft.Functional;
using TestData;

public sealed class Result2Lifting2Tests
{
  #region Lift

  [Fact(DisplayName = "Lifting over two successes returns success")]
  public void Test11()
  {
    var r1 = Result.Success<RedDragon, PinkLily>(new RedDragon());
    var r2 = Result.Success<RedDragon, PinkLily>(new RedDragon());

    var lift = Result.Lifting.Lift(r1, r2);

    lift.IsSuccess.ShouldBeTrue();
  }

  [Theory(DisplayName = "Lifting over error results returns an error")]
  [ClassData(typeof(Result2_Lift2ErrorTestData))]
  public void Test12(
    Result<RedDragon, string> r1,
    Result<RedDragon, string> r2)
  {
    var lift = Result.Lifting.Lift(r1, r2);

    lift.IsSuccess.ShouldBeFalse();
    lift.OnError(e => e.ShouldBe("error"));
  }

  #endregion

  #region LiftLazy

  [Fact(DisplayName = "Lifting lazy over two successes returns success")]
  public void Test21()
  {
    var fr1 = () => Result.Success<RedDragon, string>(new RedDragon());
    var fr2 = () => Result.Success<RedDragon, string>(new RedDragon());

    var lift = Result.Lifting.LiftLazy(fr1, fr2);

    lift.IsSuccess.ShouldBeTrue();
  }

  [Theory(DisplayName = "Lifting lazy over error results returns an error")]
  [ClassData(typeof(Result2_LiftLazy2ErrorTestData))]
  public void Test22(
    Func<Result<RedDragon, string>> r1,
    Func<Result<RedDragon, string>> r2)
  {
    var lift = Result.Lifting.LiftLazy(r1, r2);

    lift.IsSuccess.ShouldBeFalse();
    lift.OnError(e => e.ShouldBe("error"));
  }

  #endregion

  #region LiftAsync

  [Fact(DisplayName = "Lifting async over two successes returns success")]
  public async Task Test31()
  {
    var tr1 = Task.FromResult(Result.Success<RedDragon, string>(new RedDragon()));
    var tr2 = Task.FromResult(Result.Success<RedDragon, string>(new RedDragon()));

    var lift = await Result.Lifting.LiftAsync(tr1, tr2);

    lift.IsSuccess.ShouldBeTrue();
  }

  [Theory(DisplayName = "Lifting async over error results returns an error")]
  [ClassData(typeof(Result2_LiftAsync2ErrorTestData))]
  public async Task Test32(
    Task<Result<RedDragon, string>> r1,
    Task<Result<RedDragon, string>> r2)
  {
    var lift = await Result.Lifting.LiftAsync(r1, r2);

    lift.IsSuccess.ShouldBeFalse();
    lift.OnError(e => e.ShouldBe("error"));
  }

  #endregion

  #region LiftLazyAsync

  [Fact(DisplayName = "Lifting lazy async over two successes returns success")]
  public async Task Test41()
  {
    var ftr1 = () => Task.FromResult(Result.Success<RedDragon, string>(new RedDragon()));
    var ftr2 = () => Task.FromResult(Result.Success<RedDragon, string>(new RedDragon()));

    var lift = await Result.Lifting.LiftLazyAsync(ftr1, ftr2);

    lift.IsSuccess.ShouldBeTrue();
  }

  [Theory(DisplayName = "Lifting lazy async over error results returns an error")]
  [ClassData(typeof(Result2_LiftLazyAsync2ErrorTestData))]
  public async Task Test42(
    Func<Task<Result<RedDragon, string>>> r1,
    Func<Task<Result<RedDragon, string>>> r2)
  {
    var lift = await Result.Lifting.LiftLazyAsync(r1, r2);

    lift.IsSuccess.ShouldBeFalse();
    lift.OnError(e => e.ShouldBe("error"));
  }

  #endregion
}

public sealed class Result2_Lift2ErrorTestData : IEnumerable<object[]>
{
  private readonly IGenerator g = Result2TestDataGenerator.AsResults();

  public IEnumerator<object[]> GetEnumerator()
  {
    yield return g.Generate(2, 0);
    yield return g.Generate(2, 1);
  }

  IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
}

public sealed class Result2_LiftLazy2ErrorTestData : IEnumerable<object[]>
{
  private readonly IGenerator g = Result2TestDataGenerator.AsFunctions();

  public IEnumerator<object[]> GetEnumerator()
  {
    yield return g.Generate(2, 0);
    yield return g.Generate(2, 1);
  }

  IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
}

public sealed class Result2_LiftAsync2ErrorTestData : IEnumerable<object[]>
{
  private readonly IGenerator g = Result2TestDataGenerator.AsTasks();

  public IEnumerator<object[]> GetEnumerator()
  {
    yield return g.Generate(2, 0);
    yield return g.Generate(2, 1);
  }

  IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
}

public sealed class Result2_LiftLazyAsync2ErrorTestData : IEnumerable<object[]>
{
  private readonly IGenerator g = Result2TestDataGenerator.AsFunctionTasks();

  public IEnumerator<object[]> GetEnumerator()
  {
    yield return g.Generate(2, 0);
    yield return g.Generate(2, 1);
  }

  IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
}