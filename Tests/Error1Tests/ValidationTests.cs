namespace Tests.Error1Tests;

using SampleTypes.Reference;
using SampleTypes.Value;
using Shouldly;
using SoftwareCraft.Functional;

public sealed class ValidationTests
{
  [Fact]
  public void CannotAssignDefaultValueToReferenceTypes()
  {
    Should.Throw<InvalidOperationException>(() => Result.Error<RedDragon>(null!));
  }

  [Fact]
  public void CannotAssignDefaultValueToNullableValueTypes()
  {
    Should.Throw<InvalidOperationException>(() => Result.Error<PinkLily?>(null));
  }

  [Fact]
  public void CanAssignDefaultValueToValueTypes()
  {
    Result.Error<PinkLily>(default).ShouldNotBeNull();
  }
}