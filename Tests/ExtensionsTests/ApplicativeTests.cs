// ReSharper disable MemberCanBeFileLocal

namespace Tests.ExtensionsTests;

using Shouldly;
using SoftwareCraft.Functional;

public sealed class ApplicativeTests
{
  [Fact(DisplayName = "Function is applied to value in applicative context")]
  public void Test1()
  {
    var funcResult  = Result.Success<Func<int, int>, string>(i => i + 42);
    var valueResult = Result.Success<int, string>(13);

    var outcome = funcResult.Apply(valueResult);

    outcome.Match(v => v.ShouldBe(13 + 42), _ => throw new InvalidOperationException());
  }

  [Fact(DisplayName = "Error function propagates")]
  public void Test2()
  {
    var funcResult  = Result.Error<Func<int, int>, string>("No function");
    var valueResult = Result.Success<int, string>(13);

    var outcome = funcResult.Apply(valueResult);

    outcome.Match(_ => throw new InvalidOperationException(), e => e.ShouldBe("No function"));
  }

  [Fact(DisplayName = "Error value propagates")]
  public void Test3()
  {
    var funcResult  = Result.Success<Func<int, int>, string>(i => i + 42);
    var valueResult = Result.Error<int, string>("No value");

    var outcome = funcResult.Apply(valueResult);

    outcome.Match(_ => throw new InvalidOperationException(), e => e.ShouldBe("No value"));
  }

  [Fact(DisplayName = "First error propagates")]
  public void Test4()
  {
    var funcResult  = Result.Error<Func<int, int>, string>("No function");
    var valueResult = Result.Error<int, string>("No value");

    var outcome = funcResult.Apply(valueResult);

    outcome.Match(_ => throw new InvalidOperationException(), e => e.ShouldBe("No function"));
  }
}