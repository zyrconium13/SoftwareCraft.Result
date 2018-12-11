using System;
using System.Linq;

namespace SoftwareCraft.Functional
{
	public static class Result
	{
		public static Result<TValue, TError> Success<TValue, TError>(TValue value) => new Success<TValue, TError>(value);

		public static Result<TValue, TError> Error<TValue, TError>(TError error) => new Error<TValue, TError>(error);

		public static Result<TError> Success<TError>() => new Success<TError>();

		public static Result<TError> Error<TError>(TError error) => new Error<TError>(error);
	}
}