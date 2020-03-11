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

		public static Result<Tuple<TValue1, TValue2>, TError> Join<TValue1, TValue2, TError>(Func<Result<TValue1, TError>> func1, Func<Result<TValue2, TError>> func2)
		{
			return func1()
				.Match(f1 => func2()
						.Match<Result<Tuple<TValue1, TValue2>, TError>>(
							f2 => new Success<Tuple<TValue1, TValue2>, TError>(Tuple.Create(f1, f2)),
							e => new Error<Tuple<TValue1, TValue2>, TError>(e)),
					e => new Error<Tuple<TValue1, TValue2>, TError>(e));
		}

		public static Result<Tuple<TValue1, TValue2, TValue3>, TError> Join<TValue1, TValue2, TValue3, TError>(Func<Result<TValue1, TError>> func1, Func<Result<TValue2, TError>> func2, Func<Result<TValue3, TError>> func3)
		{
			return func1()
				.Match(f1 => func2()
						.Match(f2 => func3()
								.Match<Result<Tuple<TValue1, TValue2, TValue3>, TError>>(
									f3 => new Success<Tuple<TValue1, TValue2, TValue3>, TError>(Tuple.Create(f1, f2, f3)),
									e => new Error<Tuple<TValue1, TValue2, TValue3>, TError>(e)),
							e => new Error<Tuple<TValue1, TValue2, TValue3>, TError>(e)),
					e => new Error<Tuple<TValue1, TValue2, TValue3>, TError>(e));
		}
	}
}