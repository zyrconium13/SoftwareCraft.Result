using SoftwareCraft.Functional;

using Tests.SampleTypes.Reference;

namespace Tests.LiftingTests.TestData;

public sealed class Result2TestDataGeneratorAsFunctionTasks : IGenerator
{
  public object[] GenerateSuccessPlusOneError(int size, int errorPosition)
  {
    var array = new object[size];

    Array.Fill(array, () => Task.FromResult(Result.Success<RedDragon, string>(new RedDragon())));

    array[errorPosition] = () => Task.FromResult(Result.Error<RedDragon, string>("error"));

    return array;
  }

  public object[] GenerateAllErrors(int size) =>
  [
    .. Enumerable.Range(0, size)
                 .Select<int, Func<Task<Result<RedDragon, string>>>>(i => () => Task.FromResult(Result.Error<RedDragon, string>($"error{i}")))
  ];
}