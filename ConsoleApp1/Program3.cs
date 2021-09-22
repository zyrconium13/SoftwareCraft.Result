namespace ConsoleApp1
{
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using System.Threading.Tasks;

	using SoftwareCraft.Functional;

	public static class Program3
	{
		public static void Main()
		{
			Result.Success<string>()
			      .Select(() => { Console.WriteLine("Handle success."); }, error =>
			      {
				      Console.WriteLine($"Handle error '{error}'.");

				      return "another error";
			      });

			Result.Error("original error")
			      .Select(() => { Console.WriteLine("Handle success."); }, error =>
			      {
				      Console.WriteLine($"Handle error '{error}'.");

				      return "another error";
			      });

			Result.Success<string>()
			      .SelectAsync(async () =>
			      {
				      Console.WriteLine("Handle success async.");

				      await Task.Delay(100);
			      }, async error =>
			      {
				      Console.WriteLine($"Handle error async '{error}'.");

				      await Task.Delay(100);

				      return "another error async";
			      });

			Result.Error("original error")
			      .SelectAsync(async () =>
			      {
				      Console.WriteLine("Handle success async.");

				      await Task.Delay(100);
			      }, async error =>
			      {
				      Console.WriteLine($"Handle error async '{error}'.");

				      await Task.Delay(100);

				      return "another error async";
			      });

			Result.Success<string>()
			      .SelectMany(() =>
			      {
				      Console.WriteLine("Handle success many.");

				      return Result.Success<string>();
			      }, error =>
			      {
				      Console.WriteLine($"Handle error many '{error}'.");

				      return Result.Error("another error many");
			      });

			Result.Error("original error")
			      .SelectMany(() =>
			      {
				      Console.WriteLine("Handle success many.");

				      return Result.Success<string>();
			      }, error =>
			      {
				      Console.WriteLine($"Handle error many '{error}'.");

				      return Result.Error("another error many");
			      });

			Result.Success<string>()
			      .SelectManyAsync(async () =>
			      {
				      Console.WriteLine("Handle success many async.");

				      await Task.Delay(100);

				      return Result.Success<string>();
			      }, async error =>
			      {
				      Console.WriteLine($"Handle error many async '{error}'.");

				      await Task.Delay(100);

				      return Result.Error("another error many async");
			      });

			Result.Error("original error")
			      .SelectManyAsync(async () =>
			      {
				      Console.WriteLine("Handle success many async.");

				      await Task.Delay(100);

				      return Result.Success<string>();
			      }, async error =>
			      {
				      Console.WriteLine($"Handle error many async '{error}'.");

				      await Task.Delay(100);

				      return Result.Error("another error many async");
			      });
		}
	}
}