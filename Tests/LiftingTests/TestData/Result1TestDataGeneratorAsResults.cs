namespace Tests.LiftingTests.TestData;

using System;
using System.Collections.Generic;
using System.Linq;

using SoftwareCraft.Functional;

public class Result1TestDataGeneratorAsResults : IGenerator
{
	public object[] Generate(int size, int errorPosition)
	{
		var array = new object[size];

		Array.Fill(array, Result.Success<string>());

		array[errorPosition] = Result.Error("error");

		return array;
	}
}