// ReSharper disable MemberCanBeFileLocal

namespace Tests.ExtensionsTests;

using SampleTypes.Reference;
using SampleTypes.Value;
using Shouldly;
using SoftwareCraft.Functional;

public sealed class OperatorTests
{
  [Fact(DisplayName = "Unit auto converts to success Result`1")]
  public void Test1()
  {
    var outputValue = SuccessValue1();
    outputValue.ShouldBeOfType<Success<PinkLily>>();

    var outputReference = SuccessReference1();
    outputReference.ShouldBeOfType<Success<RedDragon>>();
  }

  [Fact(DisplayName = "Error type auto converts to error Result`1")]
  public void Test2()
  {
    var outputValue = ErrorValue1();
    outputValue.ShouldBeOfType<Error<PinkLily>>();

    var outputReference = ErrorReference1();
    outputReference.ShouldBeOfType<Error<RedDragon>>();
  }

  [Fact(DisplayName = "Success type auto converts to success Result`2")]
  public void Test3()
  {
    var outputValue = SuccessValue2();
    outputValue.ShouldBeOfType<Success<PinkLily, VioletIris>>();

    var outputReference = SuccessReference2();
    outputReference.ShouldBeOfType<Success<RedDragon, GreenTurtle>>();
  }

  [Fact(DisplayName = "Error type auto converts to error Result`2")]
  public void Test4()
  {
    var outputValue = ErrorValue2();
    outputValue.ShouldBeOfType<Error<PinkLily, VioletIris>>();

    var outputReference = ErrorReference2();
    outputReference.ShouldBeOfType<Error<RedDragon, GreenTurtle>>();
  }

  private static Result<PinkLily, VioletIris>   SuccessValue2()     => new PinkLily();
  private static Result<RedDragon, GreenTurtle> SuccessReference2() => new RedDragon();

  private static Result<PinkLily>  SuccessValue1()     => Unit.Instance;
  private static Result<RedDragon> SuccessReference1() => Unit.Instance;

  private static Result<PinkLily>  ErrorValue1()     => new PinkLily();
  private static Result<RedDragon> ErrorReference1() => new RedDragon();

  private static Result<PinkLily, VioletIris>   ErrorValue2()     => new VioletIris();
  private static Result<RedDragon, GreenTurtle> ErrorReference2() => new GreenTurtle();
}