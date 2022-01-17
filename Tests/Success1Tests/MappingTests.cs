namespace Tests.Success1Tests;

using System;

using FluentAssertions;

using System.Collections.Generic;
using System.Linq;

using SampleTypes.Reference;
using SampleTypes.Value;

using SoftwareCraft.Functional;

using Xunit;

public sealed class MappingTests
{
	private readonly Spy errorSpy;
	private readonly Spy successSpy;

	public MappingTests()
	{
		successSpy = new();
		errorSpy   = new();
	}

	#region SelectMany

	[Fact(DisplayName = "Success result calls success map function but does not call error map function")]
	public void Test7()
	{
		var expectedResult = Result.Success<PinkLily>();

		var newResult = Result.Success<VioletIris>().SelectMany(
			() =>
			{
				successSpy.Trip();
				return expectedResult;
			},
			e =>
			{
				errorSpy.Trip(e);
				return Result.Success<PinkLily>();
			});

		successSpy.VerifyTrip(1);
		errorSpy.VerifyTrip(0);

		newResult.Should().BeSameAs(expectedResult);
	}

	[Fact(DisplayName = "Success result calls success map function but does not call error map function")]
	public void Test8()
	{
		var expectedResult = Result.Error(new PinkLily());

		var newResult = Result.Success<VioletIris>().SelectMany(
			() =>
			{
				successSpy.Trip();
				return expectedResult;
			},
			e =>
			{
				errorSpy.Trip(e);
				return Result.Success<PinkLily>();
			});

		successSpy.VerifyTrip(1);
		errorSpy.VerifyTrip(0);

		newResult.Should().BeSameAs(expectedResult);
	}

	[Fact(DisplayName = "Success result calls success map function")]
	public void Test9()
	{
		var expectedResult = Result.Error(new VioletIris());

		var newResult = Result.Success<VioletIris>().SelectMany(
			() =>
			{
				successSpy.Trip();
				return expectedResult;
			});

		successSpy.VerifyTrip(1);

		newResult.Should().BeSameAs(expectedResult);
	}

	[Fact(DisplayName = "Success result calls success map function")]
	public void Test10()
	{
		var expectedResult = Result.Success<VioletIris>();

		var newResult = Result.Success<VioletIris>().SelectMany(
			() =>
			{
				successSpy.Trip();
				return expectedResult;
			});

		successSpy.VerifyTrip(1);

		newResult.Should().BeSameAs(expectedResult);
	}

	[Fact(DisplayName = "Success result does not call error map function")]
	public void Test11()
	{
		var newResult = Result.Success<VioletIris>().SelectMany(
			e =>
			{
				errorSpy.Trip(e);
				return Result.Error(new PinkLily());
			});

		errorSpy.VerifyTrip(0);

		newResult.Should().BeOfType<Success<PinkLily>>();
	}

	[Fact(DisplayName = "Error result calls error map function but does not call success map function")]
	public void Test12()
	{
		var expectedResult = Result.Success<PinkLily>();

		var newResult = Result.Error(new VioletIris()).SelectMany(
			() =>
			{
				successSpy.Trip();
				return Result.Success<PinkLily>();
			},
			e =>
			{
				errorSpy.Trip(e);
				return expectedResult;
			});

		successSpy.VerifyTrip(0);
		errorSpy.VerifyTrip(1);

		newResult.Should().BeSameAs(expectedResult);
	}

	[Fact(DisplayName = "Error result calls error map function but does not call success map function")]
	public void Test13()
	{
		var expectedResult = Result.Error(new PinkLily());

		var newResult = Result.Error(new VioletIris()).SelectMany(
			() =>
			{
				successSpy.Trip();
				return Result.Success<PinkLily>();
			},
			e =>
			{
				errorSpy.Trip(e);
				return expectedResult;
			});

		successSpy.VerifyTrip(0);
		errorSpy.VerifyTrip(1);

		newResult.Should().BeSameAs(expectedResult);
	}

	[Fact(DisplayName = "Error result calls error map function")]
	public void Test14()
	{
		var expectedResult = Result.Error(new PinkLily());

		var newResult = Result.Error(new VioletIris()).SelectMany(
			e =>
			{
				errorSpy.Trip(e);
				return expectedResult;
			});

		errorSpy.VerifyTrip(1);

		newResult.Should().BeSameAs(expectedResult);
	}

	[Fact(DisplayName = "Error result calls error map function")]
	public void Test15()
	{
		var expectedResult = Result.Success<PinkLily>();

		var newResult = Result.Error(new VioletIris()).SelectMany(
			e =>
			{
				errorSpy.Trip(e);
				return expectedResult;
			});

		errorSpy.VerifyTrip(1);

		newResult.Should().BeSameAs(expectedResult);
	}

	[Fact(DisplayName = "Error result does not call success map function")]
	public void Test16()
	{
		var newResult = Result.Error(new VioletIris()).SelectMany(
			() =>
			{
				successSpy.Trip();
				return Result.Success<VioletIris>();
			});

		successSpy.VerifyTrip(0);

		newResult.Should().BeOfType<Error<VioletIris>>();
	}

	#endregion

	#region Select

	[Fact(DisplayName = "Success result calls success map function but does not call error map function")]
	public void Test1()
	{
		var newResult = Result.Success<VioletIris>().Select(
			() => { successSpy.Trip(); },
			e =>
			{
				errorSpy.Trip(e);
				return new PinkLily();
			});

		successSpy.VerifyTrip(1);
		errorSpy.VerifyTrip(0);

		newResult.Should().BeOfType<Success<PinkLily>>();
	}

	[Fact(DisplayName = "Success result calls success map function")]
	public void Test2()
	{
		var newResult = Result.Success<VioletIris>().Select(
			() => { successSpy.Trip(); });

		successSpy.VerifyTrip(1);

		newResult.Should().BeOfType<Success<VioletIris>>();
	}

	[Fact(DisplayName = "Success result does not call error map function")]
	public void Test3()
	{
		var newResult = Result.Success<VioletIris>().Select(
			e =>
			{
				errorSpy.Trip(e);
				return new PinkLily();
			});

		errorSpy.VerifyTrip(0);

		newResult.Should().BeOfType<Success<PinkLily>>();
	}

	[Fact(DisplayName = "Error result calls error map function but does not call success map function")]
	public void Test4()
	{
		var expectedInput  = new GreenTurtle();
		var expectedOutput = new RedDragon();

		var newResult = Result.Error(expectedInput).Select(
			() => { successSpy.Trip(); },
			e =>
			{
				errorSpy.Trip(e);
				return expectedOutput;
			});

		successSpy.VerifyTrip(0);
		errorSpy.VerifyTrip(1, expectedInput);

		newResult.Match(() => { }, e => e.Should().BeSameAs(expectedOutput));
	}

	[Fact(DisplayName = "Error result calls error map function")]
	public void Test5()
	{
		var expectedInput  = new GreenTurtle();
		var expectedOutput = new RedDragon();

		var newResult = Result.Error(expectedInput).Select(
			e =>
			{
				errorSpy.Trip(e);
				return expectedOutput;
			});

		errorSpy.VerifyTrip(1, expectedInput);

		newResult.Match(() => { }, e => { e.Should().Be(expectedOutput); });
	}

	[Fact(DisplayName = "Error result does not call success map function")]
	public void Test6()
	{
		var newResult = Result.Error(new VioletIris()).Select(
			() => { successSpy.Trip(); });

		successSpy.VerifyTrip(0);

		newResult.Should().BeOfType<Error<VioletIris>>();
	}

	#endregion
}