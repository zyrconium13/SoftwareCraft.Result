namespace Tests.Success1Tests;

using SampleTypes.Reference;
using Shouldly;
using SoftwareCraft.Functional;
using Xunit;

public class MatchingTests
{
  [Fact]
  public void ActionMatchingOverloadInvokesTheSuccessBranch()
  {
    var result = Result.Success<string>();

    var spy = new Spy();

    result.Match(
      () => { spy.Trip(); },
      e => { spy.Trip(e); }
    );

    spy.VerifyTrip(1);
  }

  [Fact]
  public void FunctionMatchingOverloadInvokesTheSuccessBranch()
  {
    var successDummy = new RedDragon();
    var errorDummy   = new RedDragon();

    var result = Result.Success<string>();

    var matchResult = result.Match(
      () => successDummy,
      e => errorDummy);

    matchResult.ShouldBeSameAs(successDummy);
    matchResult.ShouldNotBeSameAs(errorDummy);
  }
}