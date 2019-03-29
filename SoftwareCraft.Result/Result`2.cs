using System;
using System.Collections.Generic;
using System.Linq;

namespace SoftwareCraft.Functional
{
	public abstract class Result<TValue, TError>
	{
		public virtual Result<TValue, TError> OnSuccess(Action<TValue> onSuccess) => this;

		public abstract Result<Tuple<TValue1, TValue2>, TError> OnSuccess<TValue1, TValue2>(Action<TValue1, TValue2> onSuccess);

		public abstract Result<Tuple<TValue1, TValue2, TValue3>, TError> OnSuccess<TValue1, TValue2, TValue3>(Action<TValue1, TValue2, TValue3> onSuccess);

		public virtual Result<TValue, TError> OnError(Action<TError> onError) => this;

		public virtual Result<TValue, TError> OnBoth(Action onBoth)
		{
			onBoth();

			return this;
		}

		public abstract void MatchAction(Action<TValue> matchValue, Action<TError> matchError);

		public abstract void MatchAction<TValue1, TValue2>(Action<TValue1, TValue2> matchValue, Action<TError> matchError);

		public abstract void MatchAction<TValue1, TValue2, TValue3>(Action<TValue1, TValue2, TValue3> matchValue, Action<TError> matchError);

		public abstract TOut MatchFunc<TOut>(Func<TValue, TOut> matchValue, Func<TError, TOut> matchError);

		public abstract TOut MatchFunc<TValue1, TValue2, TOut>(Func<TValue1, TValue2, TOut> matchValue, Func<TError, TOut> matchError);

		public abstract TOut MatchFunc<TValue1, TValue2, TValue3, TOut>(Func<TValue1, TValue2, TValue3, TOut> matchValue, Func<TError, TOut> matchError);

		public abstract Result<UValue, UError> Select<UValue, UError>(
			Func<TValue, UValue> mapValue,
			Func<TError, UError> mapError);

		public abstract Result<UValue, UError> SelectMany<UValue, UError>(
			Func<TValue, Result<UValue, UError>> mapValue,
			Func<TError, Result<UValue, UError>> mapError);

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