using System;
using System.Linq;

namespace SoftwareCraft.Functional
{
	public class Error<TValue, TError> : Result<TValue, TError>
	{
		private readonly TError error;

		internal Error(TError error)
		{
			Validate(error);

			this.error = error;
		}

		public override Result<TValue, TError> OnError(Action<TError> onError)
		{
			onError(error);

			return this;
		}

		public override void Match(
			Action<TValue> matchValue,
			Action<TError> matchError)
			=> matchError(error);

		public override TOut Match<TOut>(
			Func<TValue, TOut> matchValue,
			Func<TError, TOut> matchError)
			=> matchError(error);

		public override Result<UValue, UError> Select<UValue, UError>(
			Func<TValue, UValue> mapValue,
			Func<TError, UError> mapError)
			=> Result.Error<UValue, UError>(mapError(error));

		public override Result<UValue, TError> Select<UValue>(
			Func<TValue, UValue> mapValue)
			=> Result.Error<UValue, TError>(error);

		public override Result<UError> Select<UError>(
			Func<TError, UError> mapError)
			=> Result.Error(mapError(error));

		public override Result<UValue, UError> SelectMany<UValue, UError>(
			Func<TValue, Result<UValue, UError>> mapValue,
			Func<TError, Result<UValue, UError>> mapError)
			=> mapError(error);

		public override Result<UError> SelectMany<UError>(
			Func<TValue, Result<UError>> mapValue,
			Func<TError, Result<UError>> mapError)
			=> mapError(error);

		public override Result<TError> SelectMany(
			Func<TValue, Result<TError>> mapValue)
			=> Result.Error(error);

		public override Result<UValue, TError> SelectMany<UValue>(
			Func<TValue, Result<UValue, TError>> mapValue)
			=> Result.Error<UValue, TError>(error);

		public override Result<TAggregate, TError> Join<UValue, TAggregate>(
			Func<Result<UValue, TError>> other,
			Func<TValue, UValue, TAggregate> aggregator)
			=> new Error<TAggregate, TError>(error);
	}
}