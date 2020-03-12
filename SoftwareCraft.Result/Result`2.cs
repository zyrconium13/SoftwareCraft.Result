using System;
using System.Linq;

namespace SoftwareCraft.Functional
{
	using System.Collections.Generic;

	public abstract class Result<TValue, TError>
	{
		public virtual Result<TValue, TError> OnSuccess(Action<TValue> onSuccess) => this;

		public virtual Result<TValue, TError> OnError(Action<TError> onError) => this;

		public virtual Result<TValue, TError> OnBoth(Action onBoth)
		{
			onBoth();

			return this;
		}

		public abstract void Match(Action<TValue> matchValue, Action<TError> matchError);

		public abstract TOut Match<TOut>(Func<TValue, TOut> matchValue, Func<TError, TOut> matchError);

		public abstract Result<UValue, UError> Select<UValue, UError>(
			Func<TValue, UValue> mapValue,
			Func<TError, UError> mapError);

		public abstract Result<UValue, TError> Select<UValue>(
			Func<TValue, UValue> mapValue);

		public abstract Result<UError> Select<UError>(
			Func<TError, UError> mapError);

		public abstract Result<UValue, UError> SelectMany<UValue, UError>(
			Func<TValue, Result<UValue, UError>> mapValue,
			Func<TError, Result<UValue, UError>> mapError);

		public abstract Result<UValue, TError> SelectMany<UValue>(
			Func<TValue, Result<UValue, TError>> mapValue);

		public abstract Result<UError> SelectMany<UError>(
			Func<TValue, Result<UError>> mapValue,
			Func<TError, Result<UError>> mapError);

		public abstract Result<TError> SelectMany(
			Func<TValue, Result<TError>> mapValue);

		public abstract Result<TAggregate, TError> Join<UValue, TAggregate>(Func<Result<UValue, TError>> other, Func<TValue, UValue, TAggregate> aggregator);

		private protected static void Validate<T>(T value)
		{
			var isNotValueType = !typeof(T).IsValueType;
			var isNullableValueType = Nullable.GetUnderlyingType(typeof(T)) != null;
			var hasDefaultValue = EqualityComparer<T>.Default.Equals(value, default);

			if ((isNotValueType || isNullableValueType) && hasDefaultValue)
				throw new InvalidOperationException();
		}
	}
}