using System;
using System.Linq;

namespace SoftwareCraft.Functional
{
	public class Error<TValue, TError> : Result<TValue, TError>
	{
		private readonly TError error;

		public Error(TError error)
		{
			Validate(error);

			this.error = error;
		}

		public override Result<TValue, TError> OnError(Action<TError> onError)
		{
			onError(error);

			return this;
		}

		public override void Match(Action<TValue> matchValue, Action<TError> matchError) =>
			matchError(error);

		public override TOut Match<TOut>(Func<TValue, TOut> matchValue, Func<TError, TOut> matchError) =>
			matchError(error);

		public override Result<UValue, UError> Select<UValue, UError>(
			Func<TValue, UValue> mapValue,
			Func<TError, UError> mapError) =>
			Result.Error<UValue, UError>(mapError(error));

		public override Result<UValue, UError> SelectMany<UValue, UError>(
			Func<TValue, Result<UValue, UError>> mapValue,
			Func<TError, Result<UValue, UError>> mapError) =>
			mapError(error);

		public override Result<TAggregate, TError> Join<UValue, TAggregate>(Func<Result<UValue, TError>> other, Func<TValue, UValue, TAggregate> aggregator) =>
			new Error<TAggregate, TError>(error);
	}
}