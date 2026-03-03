namespace Tests.LiftingTests.TestData;

public interface IGenerator
{
  object[] Generate(int size, int errorPosition);
}