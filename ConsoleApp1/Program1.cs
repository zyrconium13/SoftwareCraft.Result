using System;
using System.Linq;
using SoftwareCraft.Functional;

namespace ConsoleApp1
{
	internal class Program1
	{
		private static void Main(string[] args)
		{
			String50.Create(
					"Eduard Eduard Eduard Eduard Eduard Eduard Eduard Eduard Eduard Eduard Eduard Eduard Eduard Eduard Eduard ")
				.Join(() => String50.Create("Popescu"))
				.Join(() => Birthdate.Create(new DateTime(1982, 03, 05)))
				.Match(tuple => Console.WriteLine(new Person(tuple.Item1.Item1, tuple.Item1.Item2, tuple.Item2)),
					Console.WriteLine);

			//String50.Create("Eduard")
			//	.Match(firstName => String50.Create("Popescu")
			//			.Match(lastName => Birthdate.Create(new DateTime(1982, 03, 05))
			//					.Match(birthdate =>
			//							Result.Success<Person, string>(new Person(firstName, lastName, birthdate)),
			//						Result.Error<Person, string>),
			//				Result.Error<Person, string>),
			//		Result.Error<Person, string>)
			//	.Match(person => { Console.WriteLine(person); },
			//		error => Console.WriteLine($"Could not create a Person because {error}"));
		}
	}

	internal class String50
	{
		private String50(string value) => Value = value;

		public string Value { get; }

		public static Result<String50, string> Create(string value)
		{
			if (string.IsNullOrWhiteSpace(value) || value.Length > 50)
				return Result.Error<String50, string>("Value must not be null, empty or longer than 50 characters.");

			return Result.Success<String50, string>(new String50(value));
		}
	}

	internal class Birthdate
	{
		private Birthdate(DateTime value) => Value = value;

		public DateTime Value { get; }

		public static Result<Birthdate, string> Create(DateTime value)
		{
			if (value < new DateTime(1900, 1, 1) || value > DateTime.Now)
				return Result.Error<Birthdate, string>("Birthdate must be greater than 1.1.1900 and less than today.");

			return Result.Success<Birthdate, string>(new Birthdate(value));
		}
	}

	internal class Person
	{
		public Person(String50 firstName, String50 lastName, Birthdate birthdate)
		{
			FirstName = firstName;
			LastName = lastName;
			Birthdate = birthdate;
		}

		public String50 FirstName { get; }

		public String50 LastName { get; }

		public Birthdate Birthdate { get; }

		public override string ToString() => $"{FirstName.Value} {LastName.Value} born {Birthdate.Value:d}";
	}
}