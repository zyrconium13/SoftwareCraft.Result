namespace Tests.Success2Tests;

using SampleTypes.Reference;
using SampleTypes.Value;
using Shouldly;
using SoftwareCraft.Functional;

public class ValidationTests
{
  [Fact]
  public void CannotAssignDefaultValueToReferenceTypes()
  {
    Should.Throw<InvalidOperationException>(() => Result.Success<RedDragon, VioletIris>(default));
  }

  [Fact]
  public void CannotAssignDefaultValueToNullableValueTypes()
  {
    Should.Throw<InvalidOperationException>(() => Result.Success<int?, VioletIris>(default));
  }

  [Fact]
  public void CanAssignDefaultValueToValueTypes()
  {
    Result.Success<int, VioletIris>(default).ShouldNotBeNull();
  }
}