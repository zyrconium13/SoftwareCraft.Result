using Tests.SampleTypes.Reference;

namespace Tests.LiftingTests;

using System.Collections;
using SampleTypes.Value;
using Shouldly;
using SoftwareCraft.Functional;
using TestData;

public sealed class Result1Lifting2Tests
{
  #region Lift

  [Fact(DisplayName = "Lifting over two success results returns success")]
  public void Test11()
  {
    var r1 = Result.Success<PinkLily>();
    var r2 = Result.Success<PinkLily>();

    var lift = Result.Lifting.Lift(r1, r2);

    lift.IsSuccess.ShouldBeTrue();
  }

  [Theory(DisplayName = "Lifting over one error result returns an error")]
  [ClassData(typeof(Result1_Lift2_SingleErrorTestData))]
  public void Test12(
    Result<string> r1,
    Result<string> r2)
  {
    var lift = Result.Lifting.Lift(r1, r2);

    lift.IsSuccess.ShouldBeFalse();
    lift.OnError(e => e.ShouldBe("error"));
  }

  [Fact(DisplayName = "CombineErrors - Lifting over two success results returns success")]
  public void Test51()
  {
    var r1 = Result.Success<IEnumerable<PinkLily>>();
    var r2 = Result.Success<IEnumerable<PinkLily>>();

    var lift = Result.Lifting.Lift(r1, r2, (e1, e2) => e1.Concat(e2));

    lift.IsSuccess.ShouldBeTrue();
  }

  [Theory(DisplayName = "CombineErrors - Lifting over one error result returns an error")]
  [ClassData(typeof(Result1_Lift2_SingleErrorTestData))]
  public void Test52(
    Result<string> r1
   ,Result<string> r2)
  {
    var lift = Result.Lifting.Lift(r1, r2, (e1, e2) => e1 + e2);

    lift.IsSuccess.ShouldBeFalse();
    lift.OnError(e => e.ShouldBe("error"));
  }

  [Theory(DisplayName = "CombineErrors - Lifting over all error results returns cumulative error")]
  [ClassData(typeof(Result1_Lift2_AllErrorTestData))]
  public void Test53(
    Result<string> r1
   ,Result<string> r2)
  {
    var lift = Result.Lifting.Lift(r1, r2, (e1, e2) => e1 + e2);

    lift.IsSuccess.ShouldBeFalse();
    lift.OnError(e => e.ShouldBe("error0error1"));
  }

  #endregion

  #region LiftAsync

  [Fact(DisplayName = "Lifting async over two success results returns success")]
  public async Task Test21()
  {
    var tr1 = Task.FromResult(Result.Success<PinkLily>());
    var tr2 = Task.FromResult(Result.Success<PinkLily>());

    var lift = await Result.Lifting.LiftAsync(tr1, tr2);

    lift.IsSuccess.ShouldBeTrue();
  }

  [Theory(DisplayName = "Lifting async over one error result returns an error")]
  [ClassData(typeof(Result1_LiftAsync2_SingleErrorTestData))]
  public async Task Test22(
    Task<Result<string>> r1,
    Task<Result<string>> r2)
  {
    var lift = await Result.Lifting.LiftAsync(r1, r2);

    lift.IsSuccess.ShouldBeFalse();
    lift.OnError(e => e.ShouldBe("error"));
  }

  [Fact(DisplayName = "CombineErrors - Lifting async over two success results returns success")]
  public async Task Test61()
  {
    var tr1 = Task.FromResult(Result.Success<IEnumerable<PinkLily>>());
    var tr2 = Task.FromResult(Result.Success<IEnumerable<PinkLily>>());

    var lift = await Result.Lifting.LiftAsync(tr1, tr2, (e1, e2) => e1.Concat(e2));

    lift.IsSuccess.ShouldBeTrue();
  }

  [Theory(DisplayName = "CombineErrors - Lifting async over one error result returns an error")]
  [ClassData(typeof(Result1_LiftAsync2_SingleErrorTestData))]
  public async Task Test62(
    Task<Result<string>> r1,
    Task<Result<string>> r2)
  {
    var lift = await Result.Lifting.LiftAsync(r1, r2, (e1, e2) => e1 + e2);

    lift.IsSuccess.ShouldBeFalse();
    lift.OnError(e => e.ShouldBe("error"));
  }

  [Theory(DisplayName = "CombineErrors - Lifting async over all error results returns cumulative error")]
  [ClassData(typeof(Result1_LiftAsync2_AllErrorTestData))]
  public async Task Test63(
    Task<Result<string>> r1,
    Task<Result<string>> r2)
  {
    var lift = await Result.Lifting.LiftAsync(r1, r2, (e1, e2) => e1 + e2);

    lift.IsSuccess.ShouldBeFalse();
    lift.OnError(e => e.ShouldBe("error0error1"));
  }

  #endregion

  #region LiftLazy

  [Fact(DisplayName = "Lifting lazy over two successes returns success")]
  public void Test31()
  {
    var fr1 = Result.Success<PinkLily>;
    var fr2 = Result.Success<PinkLily>;

    var lift = Result.Lifting.LiftLazy(fr1, fr2);

    lift.IsSuccess.ShouldBeTrue();
  }

  [Theory(DisplayName = "Lifting lazy over error results returns an error")]
  [ClassData(typeof(Result1_LiftLazy2ErrorTestData))]
  public void Test32(
    Func<Result<string>> r1,
    Func<Result<string>> r2)
  {
    var lift = Result.Lifting.LiftLazy(r1, r2);

    lift.IsSuccess.ShouldBeFalse();
    lift.OnError(e => e.ShouldBe("error"));
  }

  #endregion

  #region LiftLazyAsync

  [Fact(DisplayName = "Lifting lazy async over two successes returns success")]
  public async Task Test41()
  {
    var ftr1 = () => Task.FromResult(Result.Success<PinkLily>());
    var ftr2 = () => Task.FromResult(Result.Success<PinkLily>());

    var lift = await Result.Lifting.LiftLazyAsync(ftr1, ftr2);

    lift.IsSuccess.ShouldBeTrue();
  }

  [Theory(DisplayName = "Lifting lazy async over error results returns an error")]
  [ClassData(typeof(Result1_LiftLazyAsync2ErrorTestData))]
  public async Task Test42(
    Func<Task<Result<string>>> r1,
    Func<Task<Result<string>>> r2)
  {
    var lift = await Result.Lifting.LiftLazyAsync(r1, r2);

    lift.IsSuccess.ShouldBeFalse();
    lift.OnError(e => e.ShouldBe("error"));
  }

  #endregion
}

public sealed class Result1_Lift2_SingleErrorTestData : IEnumerable<object[]>
{
  private readonly IGenerator g = Result1TestDataGenerator.AsResults();

  public IEnumerator<object[]> GetEnumerator()
  {
    yield return g.GenerateSuccessPlusOneError(2, 0);
    yield return g.GenerateSuccessPlusOneError(2, 1);
  }

  IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
}

public sealed class Result1_Lift2_AllErrorTestData : IEnumerable<object[]>
{
  private readonly IGenerator g = Result1TestDataGenerator.AsResults();

  public IEnumerator<object[]> GetEnumerator()
  {
    yield return g.GenerateAllErrors(2);
  }

  IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
}

public sealed class Result1_LiftAsync2_SingleErrorTestData : IEnumerable<object[]>
{
  private readonly IGenerator g = Result1TestDataGenerator.AsTasks();

  public IEnumerator<object[]> GetEnumerator()
  {
    yield return g.GenerateSuccessPlusOneError(2, 0);
    yield return g.GenerateSuccessPlusOneError(2, 1);
  }

  IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
}

public sealed class Result1_LiftAsync2_AllErrorTestData : IEnumerable<object[]>
{
  private readonly IGenerator g = Result1TestDataGenerator.AsTasks();

  public IEnumerator<object[]> GetEnumerator()
  {
    yield return g.GenerateAllErrors(2);
  }

  IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
}

public sealed class Result1_LiftLazy2ErrorTestData : IEnumerable<object[]>
{
  private readonly IGenerator g = Result1TestDataGenerator.AsFunctions();

  public IEnumerator<object[]> GetEnumerator()
  {
    yield return g.GenerateSuccessPlusOneError(2, 0);
    yield return g.GenerateSuccessPlusOneError(2, 1);
  }

  IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
}

public sealed class Result1_LiftLazyAsync2ErrorTestData : IEnumerable<object[]>
{
  private readonly IGenerator g = Result1TestDataGenerator.AsFunctionTasks();

  public IEnumerator<object[]> GetEnumerator()
  {
    yield return g.GenerateSuccessPlusOneError(2, 0);
    yield return g.GenerateSuccessPlusOneError(2, 1);
  }

  IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
}