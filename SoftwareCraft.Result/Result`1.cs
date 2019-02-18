using System;
using System.Collections.Generic;
using System.Linq;

namespace SoftwareCraft.Functional
{
	public abstract class Result<TError>
	{
		public virtual Result<TError> OnSuccess(Action onSuccess) => this;

		public virtual Result<TError> OnError(Action<TError> onError) => this;

		public virtual Result<TError> OnBoth(Action onBoth)
		{
			onBoth();

			return this;
		}

		public abstract void Match(Action matchValue, Action<TError> matchError);

		public abstract TOut Match<TOut>(Func<TOut> matchValue, Func<TError, TOut> matchError);

		public abstract Result<UError> Select<UError>(Func<TError, UError> mapError);

		public abstract Result<UError> SelectMany<UError>(Func<TError, Result<UError>> mapError);

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