namespace Tests.Success2Tests;

using SampleTypes.Reference;
using SampleTypes.Value;
using Shouldly;
using SoftwareCraft.Functional;

public sealed class MatchingTests
{
  [Fact]
  public void ActionMatchingOverloadInvokesTheSuccessBranch()
  {
    var value = new RedDragon();

    var result = Result.Success<RedDragon, string>(value);

    var spy = new Spy();

    result.Match(
      v => { spy.Trip(v); },
      e => { spy.Trip(e); }
    );

    spy.VerifyTrip(1, value);
  }

  [Fact]
  public void FunctionMatchingOverloadInvokesTheSuccessBranch()
  {
    var successDummy = new VioletIris();
    var errorDummy   = new VioletIris();

    var result = Result.Success<RedDragon, string>(new RedDragon());

    var matchResult = result.Match(
      v => successDummy,
      e => errorDummy);

    matchResult.ShouldBe(successDummy);
    matchResult.ShouldNotBeSameAs(errorDummy);
  }
}