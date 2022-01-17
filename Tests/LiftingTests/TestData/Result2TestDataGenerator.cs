namespace Tests.LiftingTests.TestData;

using System;
using System.Collections.Generic;
using System.Linq;

public static class Result2TestDataGenerator
{
	public static IGenerator AsResults() => new Result2TestDataGeneratorAsResults();

	public static IGenerator AsTasks() => new Result2TestDataGeneratorAsTasks();

	public static IGenerator AsFunctions() => new Result2TestDataGeneratorAsFunctions();

	public static IGenerator AsFunctionTasks() => new Result2TestDataGeneratorAsFunctionTasks();
}