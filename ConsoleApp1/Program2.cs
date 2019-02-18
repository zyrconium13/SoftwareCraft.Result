using System;
using System.Collections.Generic;
using System.Text;
using CSharpFunctionalExtensions;

namespace ConsoleApp1
{
	class Program2
	{
		static void Main(string[] args)
		{
			var v = Result.Ok<int, string>(13)
				.OnFailure(s => Console.WriteLine(s))
				.OnSuccess(i => Result.Fail<int, string>("oops"))
				.OnFailure(s => Console.WriteLine(s));
		}
	}
}
