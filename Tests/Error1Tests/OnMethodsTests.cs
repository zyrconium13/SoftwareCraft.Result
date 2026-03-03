namespace Tests.Error1Tests;

using Shouldly;
using SoftwareCraft.Functional;
using Xunit;

public class OnMethodsTests
{
  private readonly string errorValue;

  private readonly Result<string> result;

  private readonly Spy spy;

  public OnMethodsTests()
  {
    errorValue = "error";

    result = Result.Error(errorValue);

    spy = new Spy();
  }

  [Fact]
  public void OnSuccessIsNotCalled()
  {
    var forwardedResult = result.OnSuccess(() => { spy.Trip(); });

    spy.VerifyTrip(0);

    forwardedResult.ShouldBeSameAs(result);
  }

  [Fact]
  public void OnErrorIsCalled()
  {
    var forwardedResult = result.OnError(e => { spy.Trip(e); });

    spy.VerifyTrip(1, errorValue);

    forwardedResult.ShouldBeSameAs(result);
  }

  [Fact]
  public void OnBothIsCalled()
  {
    var forwardedResult = result.OnBoth(() => { spy.Trip(); });

    spy.VerifyTrip(1);

    forwardedResult.ShouldBeSameAs(result);
  }
}