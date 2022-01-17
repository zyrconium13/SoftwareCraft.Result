namespace Tests.ExtensionsTests;

using System;

using FluentAssertions;

using System.Collections.Generic;
using System.Linq;

using SoftwareCraft.Functional;

using Xunit;

public class ExtensionsTests
{
	[Fact(DisplayName = "AsSuccess wraps into success Result`2")]
	public void Test1()
	{
		var result = 13.AsSuccess<int, string>();

		result.Should().BeOfType<Success<int, string>>();
		result.Match(x => x.Should().Be(13), _ => { });
	}

	[Fact(DisplayName = "AsError wraps into error Result`2")]
	public void Test2()
	{
		var result = "error".AsError<int, string>();

		result.Should().BeOfType<Error<int, string>>();
		result.Match(_ => { }, e => e.Should().Be("error"));
	}

	[Fact(DisplayName = "AsError wraps into error Result`1")]
	public void Test3()
	{
		var result = "error".AsError();

		result.Should().BeOfType<Error<string>>();
		result.Match(() => { }, e => e.Should().Be("error"));
	}
}