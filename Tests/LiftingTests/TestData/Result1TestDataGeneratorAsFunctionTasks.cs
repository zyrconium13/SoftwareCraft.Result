using SoftwareCraft.Functional;

namespace Tests.LiftingTests.TestData;

public sealed class Result1TestDataGeneratorAsFunctionTasks : IGenerator
{
  public object[] GenerateSuccessPlusOneError(int size, int errorPosition)
  {
    var array = new object[size];

    Array.Fill(array, () => Task.FromResult(Result.Success<string>()));

    array[errorPosition] = () => Task.FromResult(Result.Error("error"));

    return array;
  }

  public object[] GenerateAllErrors(int size) =>
  [
    .. Enumerable.Range(0, size)
                 .Select<int, Func<Task<Result<string>>>>(i => () => Task.FromResult(Result.Error($"error{i}")))
  ];
}