namespace Tests.LiftingTests.TestData;

using SoftwareCraft.Functional;

public sealed class Result1TestDataGeneratorAsResults : IGenerator
{
  public object[] Generate(int size, int errorPosition)
  {
    var array = new object[size];

    Array.Fill(array, Result.Success<string>());

    array[errorPosition] = Result.Error("error");

    return array;
  }
}