namespace Tests.Success1Tests;

using SampleTypes.Value;
using Shouldly;
using SoftwareCraft.Functional;

public class OnMethodsTests
{
  private readonly Spy              spy;
  private readonly Result<PinkLily> sut;

  public OnMethodsTests()
  {
    sut = Result.Success<PinkLily>();

    spy = new Spy();
  }

  [Fact]
  public void OnSuccessIsCalled()
  {
    var forwardedResult = sut.OnSuccess(() => { spy.Trip(); });

    spy.VerifyTrip(1);

    forwardedResult.ShouldBeSameAs(sut);
  }

  [Fact]
  public void OnErrorIsNotCalled()
  {
    var forwardedResult = sut.OnError(e => { spy.Trip(e); });

    spy.VerifyTrip(0);

    forwardedResult.ShouldBeSameAs(sut);
  }

  [Fact]
  public void OnBothIsCalled()
  {
    var forwardedResult = sut.OnBoth(() => { spy.Trip(); });

    spy.VerifyTrip(1);

    forwardedResult.ShouldBeSameAs(sut);
  }
}