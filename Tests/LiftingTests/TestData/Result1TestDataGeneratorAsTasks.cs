namespace Tests.LiftingTests.TestData;

using SoftwareCraft.Functional;

public sealed class Result1TestDataGeneratorAsTasks : IGenerator
{
  public object[] Generate(int size, int errorPosition)
  {
    var array = new object[size];

    Array.Fill(array, Task.FromResult(Result.Success<string>()));

    array[errorPosition] = Task.FromResult(Result.Error("error"));

    return array;
  }
}