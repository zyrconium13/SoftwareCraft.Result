using System;
using System.Collections.Generic;
using System.Linq;

namespace SoftwareCraft.Functional
{
	using System.Threading.Tasks;

	public abstract class Result<TError>
	{
		public virtual Result<TError> OnSuccess(Action onSuccess) => this;

		public virtual Task<Result<TError>> OnSuccessAsync(Func<Task> onSuccess) => Task.FromResult(this);

		public virtual Result<TError> OnError(Action<TError> onError) => this;

		public virtual Task<Result<TError>> OnErrorAsync(Func<TError, Task> onError) => Task.FromResult(this);

		public Result<TError> OnBoth(Action onBoth)
		{
			onBoth();

			return this;
		}

		public async Task<Result<TError>> OnBothAsync(Func<Task> onBoth)
		{
			await onBoth();

			return this;
		}

		public abstract void Match(Action matchValue, Action<TError> matchError);

		public abstract Task MatchAsync(Func<Task> matchValue, Func<TError, Task> matchError);

		public abstract TOut Match<TOut>(Func<TOut> matchValue, Func<TError, TOut> matchError);

		public abstract Task<TOut> MatchAsync<TOut>(Func<Task<TOut>> matchValue, Func<TError, Task<TOut>> matchError);

		public abstract Result<UError> Select<UError>(
			Action               mapSuccess,
			Func<TError, UError> mapError);

		public abstract Task<Result<UError>> SelectAsync<UError>(
			Func<Task>                 mapSuccess,
			Func<TError, Task<UError>> mapError);

		public abstract Result<UError> SelectMany<UError>(
			Func<Result<UError>>         mapSuccess,
			Func<TError, Result<UError>> mapError);

		public abstract Task<Result<UError>> SelectManyAsync<UError>(
			Func<Task<Result<UError>>>         mapSuccess,
			Func<TError, Task<Result<UError>>> mapError);

		private protected static void Validate<T>(T value)
		{
			var isNotValueType      = !typeof(T).IsValueType;
			var isNullableValueType = Nullable.GetUnderlyingType(typeof(T)) != null;
			var hasDefaultValue     = EqualityComparer<T>.Default.Equals(value, default);

			if ((isNotValueType || isNullableValueType) && hasDefaultValue)
				throw new InvalidOperationException();
		}
	}
}