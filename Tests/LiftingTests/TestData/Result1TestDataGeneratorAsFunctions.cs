namespace Tests.LiftingTests.TestData;

using System;
using SoftwareCraft.Functional;

public class Result1TestDataGeneratorAsFunctions : IGenerator
{
  public object[] Generate(int size, int errorPosition)
  {
    var array = new object[size];

    Array.Fill(array, () => Result.Success<string>());

    array[errorPosition] = () => Result.Error("error");

    return array;
  }
}