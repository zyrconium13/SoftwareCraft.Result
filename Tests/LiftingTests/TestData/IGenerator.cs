namespace Tests.LiftingTests.TestData;

public interface IGenerator
{
  // object[] GenerateAllSuccesses(int size);

  object[] GenerateSuccessPlusOneError(int size, int errorPosition);

  object[] GenerateAllErrors(int size);
}