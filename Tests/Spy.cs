namespace Tests;

using Shouldly;

internal sealed class Spy
{
  private object expectedValue;
  private int    timesTripped;

  public void Trip()
  {
    timesTripped++;
  }

  public void Trip(object expectedValue)
  {
    timesTripped++;
    this.expectedValue = expectedValue;
  }

  public void VerifyTrip(int times)
  {
    CheckTimesTripped(times);
  }

  public void VerifyTrip(int times, object actualValue)
  {
    CheckTimesTripped(times);

    CheckTrippedValue(actualValue);
  }

  private void CheckTimesTripped(int times)
  {
    times.ShouldBe(timesTripped, $"Expected spy tripped {times} times, but actually tripped {timesTripped} times.");
  }

  private void CheckTrippedValue(object actualValue)
  {
    actualValue.ShouldBe(expectedValue, $"Expected spy tripped with {actualValue}, but actually tripped with {expectedValue}.");
  }
}