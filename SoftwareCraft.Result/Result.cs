using System;
using System.Linq;

namespace SoftwareCraft.Functional
{
	public static class Result
	{
		public static Result<TValue, TError> Success<TValue, TError>(TValue value)
		{
			return new Success<TValue, TError>(value);
		}

		public static Result<TValue, TError> Error<TValue, TError>(TError error)
		{
			return new Error<TValue, TError>(error);
		}
	}
}