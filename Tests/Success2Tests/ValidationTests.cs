namespace Tests.Success2Tests;

using SampleTypes.Reference;
using SampleTypes.Value;
using Shouldly;
using SoftwareCraft.Functional;

public sealed class ValidationTests
{
  [Fact]
  public void CannotAssignDefaultValueToReferenceTypes()
  {
    Should.Throw<InvalidOperationException>(() => Result.Success<RedDragon, VioletIris>(null!));
  }

  [Fact]
  public void CannotAssignDefaultValueToNullableValueTypes()
  {
    Should.Throw<InvalidOperationException>(() => Result.Success<PinkLily?, VioletIris>(null));
  }

  [Fact]
  public void CanAssignDefaultValueToValueTypes()
  {
    Result.Success<PinkLily, VioletIris>(default).ShouldNotBeNull();
  }
}