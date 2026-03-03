namespace Tests;

using SampleTypes.Reference;
using SampleTypes.Value;
using Shouldly;
using SoftwareCraft.Functional;

public sealed class DefaultValueTests
{
  [Fact]
  public void CannotAssignDefaultValueToReferenceTypes()
  {
    Should.Throw<InvalidOperationException>(() => Result.Error<PinkLily, RedDragon>(null!));
  }

  [Fact]
  public void CannotAssignDefaultValueToNullableValueTypes()
  {
    Should.Throw<InvalidOperationException>(() => Result.Error<PinkLily, VioletIris?>(null));
  }

  [Fact]
  public void CanAssignDefaultValueToValueTypes()
  {
    Result.Error<PinkLily, VioletIris>(default).ShouldNotBeNull();
  }
}