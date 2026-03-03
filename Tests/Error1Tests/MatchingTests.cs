namespace Tests.Error1Tests;

using SampleTypes.Value;
using Shouldly;
using SoftwareCraft.Functional;

public sealed class MatchingTests
{
  [Fact]
  public void ActionMatchingOverloadInvokesTheErrorBranchWithTheProvidedErrorValue()
  {
    var result = Result.Error(new PinkLily());

    var spy = new Spy();

    var matchValue = new VioletIris();
    var matchError = new VioletIris();

    result.Match(
      () => { spy.Trip(matchValue); },
      e => { spy.Trip(matchError); }
    );

    spy.VerifyTrip(1, matchError);
  }

  [Fact]
  public void FunctionMatchingOverloadInvokesTheErrorBranchWithTheProvidedErrorValue()
  {
    var result = Result.Error(new PinkLily());

    var matchValue = new VioletIris();
    var matchError = new VioletIris();

    var matchResult = result.Match(
      () => matchValue,
      e => matchError);

    matchResult.ShouldBe(matchError);
  }
}