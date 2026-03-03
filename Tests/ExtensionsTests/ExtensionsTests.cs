// ReSharper disable MemberCanBeFileLocal

namespace Tests.ExtensionsTests;

using SampleTypes.Value;
using Shouldly;
using SoftwareCraft.Functional;

public sealed class ExtensionsTests
{
  [Fact(DisplayName = "AsSuccess wraps into success Result`2")]
  public void Test1()
  {
    var result = new PinkLily().AsSuccess<PinkLily, VioletIris>();

    result.ShouldBeOfType<Success<PinkLily, VioletIris>>();
  }

  [Fact(DisplayName = "AsError wraps into error Result`2")]
  public void Test2()
  {
    var result = new VioletIris().AsError<PinkLily, VioletIris>();

    result.ShouldBeOfType<Error<PinkLily, VioletIris>>();
  }

  [Fact(DisplayName = "AsSuccess wraps into error Result`1")]
  public void Test3()
  {
    var result = Unit.Instance.AsSuccess<PinkLily>();

    result.ShouldBeOfType<Success<PinkLily>>();
  }

  [Fact(DisplayName = "AsError wraps into error Result`1")]
  public void Test4()
  {
    var result = new PinkLily().AsError();

    result.ShouldBeOfType<Error<PinkLily>>();
  }
}