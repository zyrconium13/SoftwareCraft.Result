using System;
using System.Linq;

namespace SoftwareCraft.Functional
{
	public class Success<TValue, TError> : Result<TValue, TError>
	{
		private readonly TValue value;

		public Success(TValue value)
		{
			Validate(value);

			this.value = value;
		}

		public override Result<TValue, TError> OnSuccess(Action<TValue> onSuccess)
		{
			onSuccess(value);

			return this;
		}

		public override void Match(Action<TValue> matchValue, Action<TError> matchError) =>
			matchValue(value);

		public override TOut Match<TOut>(Func<TValue, TOut> matchValue, Func<TError, TOut> matchError) =>
			matchValue(value);

		public override Result<UValue, UError> Select<UValue, UError>(
			Func<TValue, UValue> mapValue,
			Func<TError, UError> mapError) =>
			Result.Success<UValue, UError>(mapValue(value));

		public override Result<UValue, UError> SelectMany<UValue, UError>(
			Func<TValue, Result<UValue, UError>> mapValue,
			Func<TError, Result<UValue, UError>> mapError) =>
			mapValue(value);
	}
}