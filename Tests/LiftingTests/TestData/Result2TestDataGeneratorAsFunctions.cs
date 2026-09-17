using SoftwareCraft.Functional;

using Tests.SampleTypes.Reference;

namespace Tests.LiftingTests.TestData;

public sealed class Result2TestDataGeneratorAsFunctions : IGenerator
{
  public object[] GenerateSuccessPlusOneError(int size, int errorPosition)
  {
    var array = new object[size];

    Array.Fill(array, () => Result.Success<RedDragon, string>(new RedDragon()));

    array[errorPosition] = () => Result.Error<RedDragon, string>("error");

    return array;
  }

  public object[] GenerateAllErrors(int size) =>
  [
    .. Enumerable.Range(0, size)
                 .Select(i => Result.Error<RedDragon, string>($"error{i}"))
  ];
}