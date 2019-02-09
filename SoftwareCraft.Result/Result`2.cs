using System;
using System.Collections.Generic;
using System.Linq;

namespace SoftwareCraft.Functional
{
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

		public abstract Result<UValue, UError> Select<UValue, UError>(
			Func<TValue, UValue> mapValue,
			Func<TError, UError> mapError);

		public abstract Result<UValue, UError> SelectMany<UValue, UError>(
			Func<TValue, Result<UValue, UError>> mapValue,
			Func<TError, Result<UValue, UError>> mapError);

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