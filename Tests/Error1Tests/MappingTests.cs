namespace Tests.Error1Tests;

using SampleTypes.Value;
using Shouldly;
using SoftwareCraft.Functional;

public sealed class MappingTests : IDisposable
{
  private readonly Result<PinkLily> errorResult;
  private readonly PinkLily         errorValue;

  private readonly Spy spy;

  public MappingTests()
  {
    errorValue  = new PinkLily();
    errorResult = Result.Error(errorValue);
    spy         = new Spy();
  }

  public void Dispose()
  {
    spy.VerifyTrip(1, errorValue);
  }

  [Fact]
  public void MapsAndWrapsErrorValue()
  {
    var newResult = errorResult.Select(
      () => { },
      e =>
      {
        spy.Trip(e);
        return new VioletIris();
      });

    newResult.ShouldBeOfType<Error<VioletIris>>();
  }

  [Fact]
  public void MapsAndFlattensErrorValue()
  {
    var newResult = errorResult.SelectMany(
      Result.Success<VioletIris>,
      e =>
      {
        spy.Trip(e);
        return Result.Error(new VioletIris());
      });

    newResult.ShouldBeOfType<Error<VioletIris>>();
  }
}