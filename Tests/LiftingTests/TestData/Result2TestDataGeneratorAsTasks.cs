namespace Tests.LiftingTests.TestData;

using SampleTypes.Reference;
using SoftwareCraft.Functional;

public sealed class Result2TestDataGeneratorAsTasks : IGenerator
{
  public object[] Generate(int size, int errorPosition)
  {
    var array = new object[size];

    Array.Fill(array, Task.FromResult(Result.Success<RedDragon, string>(new RedDragon())));

    array[errorPosition] = Task.FromResult(Result.Error<RedDragon, string>("error"));

    return array;
  }
}