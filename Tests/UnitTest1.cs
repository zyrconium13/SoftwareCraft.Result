using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SoftwareCraft.Functional;

namespace Tests
{
	[TestClass]
	public class UnitTest1
	{
		[TestMethod]
		public void TestMethod1()
		{
			Result.Error<int, string>("mumu");
		}
	}
}