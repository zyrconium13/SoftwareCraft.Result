namespace Tests.Error1Tests;

using SampleTypes.Reference;
using Shouldly;
using SoftwareCraft.Functional;

public class ValidationTests
{
  [Fact]
  public void CannotAssignDefaultValueToReferenceTypes()
  {
    Should.Throw<InvalidOperationException>(() => Result.Error<RedDragon>(default));
  }

  [Fact]
  public void CannotAssignDefaultValueToNullableValueTypes()
  {
    Should.Throw<InvalidOperationException>(() => Result.Error<int?>(default));
  }

  [Fact]
  public void CanAssignDefaultValueToValueTypes()
  {
    Result.Error<int>(default).ShouldNotBeNull();
  }
}