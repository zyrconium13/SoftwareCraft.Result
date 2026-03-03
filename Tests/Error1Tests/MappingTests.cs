namespace Tests.Error1Tests;

using System;
using SampleTypes.Value;
using Shouldly;
using SoftwareCraft.Functional;
using Xunit;

public sealed class MappingTests : IDisposable
{
  private readonly PinkLily errorValue;

  private readonly Result<PinkLily> result;

  private readonly Spy spy;

  public MappingTests()
  {
    errorValue = new PinkLily();
    result     = Result.Error(errorValue);
    spy        = new Spy();
  }

  public void Dispose()
  {
    spy.VerifyTrip(1, errorValue);
  }

  [Fact]
  public void MapsAndWrapsErrorValue()
  {
    var newResult = result.Select(
      () => { },
      e =>
      {
        spy.Trip(e);
        return new VioletIris();
      });

    newResult.ShouldBeOfType<Result<VioletIris>>();
    newResult.ShouldBeOfType<Error<VioletIris>>();
  }

  [Fact]
  public void MapsAndFlattensErrorValue()
  {
    var newResult = result.SelectMany(
      Result.Success<VioletIris>,
      e =>
      {
        spy.Trip(e);
        return Result.Error(new VioletIris());
      });

    newResult.ShouldBeOfType<Result<VioletIris>>();
    newResult.ShouldBeOfType<Error<VioletIris>>();
  }
}