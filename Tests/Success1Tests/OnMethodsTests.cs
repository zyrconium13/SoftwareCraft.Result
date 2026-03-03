namespace Tests.Success1Tests;

using SampleTypes.Value;
using Shouldly;
using SoftwareCraft.Functional;

public sealed class OnMethodsTests
{
  private readonly Spy              spy = new();
  private readonly Result<PinkLily> sut = Result.Success<PinkLily>();

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