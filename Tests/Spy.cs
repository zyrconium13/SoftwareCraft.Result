namespace Tests
{
	using System;
	using System.Linq;

	using Microsoft.VisualStudio.TestTools.UnitTesting;

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
			Assert.AreEqual(times, timesTripped, $"Expected spy tripped {times} times, but actually tripped {timesTripped} times.");
		}

		private void CheckTrippedValue(object expectedValue)
		{
			Assert.AreEqual(expectedValue, value, $"Expected spy tripped with {expectedValue}, but actually tripped with {value}.");
		}
	}
}