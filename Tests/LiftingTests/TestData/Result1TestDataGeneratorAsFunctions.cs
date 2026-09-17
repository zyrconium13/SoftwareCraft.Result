using SoftwareCraft.Functional;

namespace Tests.LiftingTests.TestData;

public sealed class Result1TestDataGeneratorAsFunctions : IGenerator
{
  public object[] GenerateSuccessPlusOneError(int size, int errorPosition)
  {
    var array = new object[size];

    Array.Fill(array, () => Result.Success<string>());

    array[errorPosition] = () => Result.Error("error");

    return array;
  }

  public object[] GenerateAllErrors(int size) =>
  [
    .. Enumerable.Range(0, size)
                 .Select<int, Func<Result<string>>>(i => () => Result.Error($"error{i}"))
  ];
}