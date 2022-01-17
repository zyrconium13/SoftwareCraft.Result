namespace Tests.LiftingTests.TestData;

using System;
using System.Collections.Generic;
using System.Linq;

public interface IGenerator
{
	object[] Generate(int size, int errorPosition);
}