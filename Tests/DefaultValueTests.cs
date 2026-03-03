namespace Tests;

using SampleTypes.Reference;
using Shouldly;
using SoftwareCraft.Functional;

public sealed class DefaultValueTests
{
  [Fact]
  public void CannotAssignDefaultValueToReferenceTypes()
  {
    Should.Throw<InvalidOperationException>(() => Result.Error<int, RedDragon>(default));
  }

  [Fact]
  public void CannotAssignDefaultValueToNullableValueTypes()
  {
    Should.Throw<InvalidOperationException>(() => Result.Error<int, int?>(default));
  }

  [Fact]
  public void CanAssignDefaultValueToValueTypes()
  {
    Result.Error<int, int>(default).ShouldNotBeNull();
  }
}