namespace Tests.LiftingTests.TestData;

public static class Result1TestDataGenerator
{
  public static IGenerator AsResults() => new Result1TestDataGeneratorAsResults();

  public static IGenerator AsTasks() => new Result1TestDataGeneratorAsTasks();

  public static IGenerator AsFunctions() => new Result1TestDataGeneratorAsFunctions();

  public static IGenerator AsFunctionTasks() => new Result1TestDataGeneratorAsFunctionTasks();
}