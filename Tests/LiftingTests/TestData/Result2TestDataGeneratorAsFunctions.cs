namespace Tests.LiftingTests.TestData;

using SampleTypes.Reference;
using SoftwareCraft.Functional;

public class Result2TestDataGeneratorAsFunctions : IGenerator
{
  public object[] Generate(int size, int errorPosition)
  {
    var array = new object[size];

    Array.Fill(array, () => Result.Success<RedDragon, string>(new RedDragon()));

    array[errorPosition] = () => Result.Error<RedDragon, string>("error");

    return array;
  }
}