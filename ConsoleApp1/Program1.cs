﻿using System;
using System.Collections.Generic;
using System.Linq;

using SoftwareCraft.Functional;

namespace ConsoleApp1
{
    internal static class Program1
    {
        private static void Main()
        {
            var person = Person.Create("", "", new DateTime(1982, 3, 5));

            person.Match(Console.WriteLine, Console.WriteLine);
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

        public static Result<Person, string> Create(string firstName, string lastName, DateTime birthdate)
            => LiftExtensions.LiftLazy(() => String50.Create(firstName), () => String50.Create(lastName),
                    () => Birthdate.Create(birthdate))
                .Match(t =>
                {
                    var (f, l, b) = t;

                    return Result.Success<Person, string>(new Person(f, l, b));
                }, Result.Error<Person, string>);

        public static Result<Person, string> Shit(String50 f, String50 l, Birthdate b) =>
            Result.Success<Person, string>(new Person(f, l, b));
    }
}