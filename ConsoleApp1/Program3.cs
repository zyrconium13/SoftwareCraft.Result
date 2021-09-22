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
		}
	}
}