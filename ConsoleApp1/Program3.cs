using System;
using System.Linq;
using CSharpFunctionalExtensions;

namespace ConsoleApp1
{
	internal class Program3
	{
		private static void Main(string[] args)
		{
			Result.Ok<int, string>(13)
				.OnSuccess(i => Result.Fail<bool, string>("mumu").OnFailure(e=>Console.WriteLine(e)))
				.OnFailure(e => Console.WriteLine(e));
		}
	}
}