// ReSharper disable MemberCanBeFileLocal

namespace Tests.ExtensionsTests;

using Shouldly;
using SoftwareCraft.Functional;

public sealed class ExtensionsTests
{
  [Fact(DisplayName = "AsSuccess wraps into success Result`2")]
  public void Test1()
  {
    var result = 13.AsSuccess<int, string>();

    result.ShouldBeOfType<Success<int, string>>();
    result.Match(x => x.ShouldBe(13), _ => { });
  }

  [Fact(DisplayName = "AsError wraps into error Result`2")]
  public void Test2()
  {
    var result = "error".AsError<int, string>();

    result.ShouldBeOfType<Error<int, string>>();
    result.Match(_ => { }, e => e.ShouldBe("error"));
  }

  [Fact(DisplayName = "AsError wraps into error Result`1")]
  public void Test3()
  {
    var result = "error".AsError();

    result.ShouldBeOfType<Error<string>>();
    result.Match(() => { }, e => e.ShouldBe("error"));
  }
}