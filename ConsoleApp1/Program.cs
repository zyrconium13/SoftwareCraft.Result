using System;
using System.Linq;
using System.Threading.Tasks;
using SoftwareCraft.Functional;

namespace ConsoleApp1
{
	internal class Program
	{
		private static void ValidateValue1(object value)
		{
			var isNotValueType = !value.GetType().IsValueType;
			var isNullableValueType = Nullable.GetUnderlyingType(value.GetType()) != null;
			var hasDefaultValue = Equals(value, Activator.CreateInstance(value.GetType()));

			if ((isNotValueType || isNullableValueType) && hasDefaultValue)
				throw new InvalidOperationException();
		}

		private static void Main(string[] args)
		{
			//Result.Success<Person, string>(null);
			//Result.Success<int?, string>(null);
			Result.Success<int, string>(0);

			ValidateValue1((int?) 0);

			Result.Success<int, string>(13)
				.OnSuccess(v => Console.WriteLine($"R1 Success: {v}"))
				.OnError(e => Console.WriteLine($"R1 Error: {e}"))
				.OnBoth(() => Console.WriteLine("R1 Both: Hello"));

			Result.Error<int, string>("Fizz")
				.OnError(e => Console.WriteLine($"R2 Error: {e}"))
				.OnSuccess(v => Console.WriteLine($"R2 Success: {v}"))
				.OnBoth(() => Console.WriteLine("R2 Both: Hello"));

			Result.Success<string>()
				.OnBoth(() => Console.WriteLine("R3 Both: Hello"))
				.OnSuccess(() => Console.WriteLine("R3 Success"))
				.OnError(e => Console.WriteLine($"R3 Error: {e}"));

			Result.Error("Buzz")
				.OnSuccess(() => Console.WriteLine("R4 Success"))
				.OnBoth(() => Console.WriteLine("R4 Both: Hello"))
				.OnError(e => Console.WriteLine($"R4 Error: {e}"));

			Result.Success<int, string>(13)
				.OnSuccess(async i => await WriteToConsoleAsync(i));
		}

		private static async Task WriteToConsoleAsync(int i)
		{
			Console.WriteLine(i);

			await Task.CompletedTask;
		}
	}

	internal class Person { }
}