namespace Tests;

using Shouldly;

public class Spy
{
  private int timesTripped;

  private object value;

  public void Trip()
  {
    timesTripped++;
  }

  public void Trip(object expectedValue)
  {
    timesTripped++;
    value = expectedValue;
  }

  public void VerifyTrip(int times)
  {
    CheckTimesTripped(times);
  }

  public void VerifyTrip(int times, object expectedValue)
  {
    CheckTimesTripped(times);

    CheckTrippedValue(expectedValue);
  }

  private void CheckTimesTripped(int times)
  {
    timesTripped.ShouldBe(times, $"Expected spy tripped {times} times, but actually tripped {timesTripped} times.");
  }

  private void CheckTrippedValue(object expectedValue)
  {
    timesTripped.ShouldBe(expectedValue, $"Expected spy tripped with {expectedValue}, but actually tripped with {value}.");
  }
}