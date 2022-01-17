namespace Tests.LiftingTests.TestData;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using SampleTypes.Reference;

using SoftwareCraft.Functional;

public class Result2TestDataGeneratorAsFunctionTasks : IGenerator
{
	public object[] Generate(int size, int errorPosition)
	{
		var array = new object[size];

		Array.Fill(array, () => Task.FromResult(Result.Success<RedDragon, string>(new())));

		array[errorPosition] = () => Task.FromResult(Result.Error<RedDragon, string>("error"));

		return array;
	}
}