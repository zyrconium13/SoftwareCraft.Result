using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SoftwareCraft.Functional
{
    public abstract class Result<TValue, TError>
    {
        public abstract bool IsSuccess { get; }

        internal abstract TValue Value { get; }

        internal abstract TError ResultError { get; }

        public virtual Result<TValue, TError> OnSuccess(Action<TValue> onSuccess) => this;

        public virtual Task<Result<TValue, TError>> OnSuccessAsync(Func<TValue, Task> onSuccess) => Task.FromResult(this);

        public virtual Result<TValue, TError> OnError(Action<TError> onError) => this;
        
        public virtual Task<Result<TValue, TError>> OnErrorAsync(Func<TError, Task> onError) => Task.FromResult(this);

        public virtual Result<TValue, TError> OnBoth(Action onBoth)
        {
            onBoth();

            return this;
        }

        public virtual async Task<Result<TValue, TError>> OnBothAsync(Func<Task> onBoth)
        {
	        await onBoth();

	        return this;
        }

        public abstract void Match(Action<TValue> matchValue, Action<TError> matchError);

        public abstract Task MatchAsync(Func<TValue, Task> matchValue, Func<TError, Task> matchError);

        public abstract TOut Match<TOut>(Func<TValue, TOut> matchValue, Func<TError, TOut> matchError);

        public abstract Task<TOut> MatchAsync<TOut>(Func<TValue, Task<TOut>> matchValue,
            Func<TError, Task<TOut>> matchError);

        private protected static void Validate<T>(T value)
        {
            var isNotValueType = !typeof(T).IsValueType;
            var isNullableValueType = Nullable.GetUnderlyingType(typeof(T)) != null;
            var hasDefaultValue = EqualityComparer<T>.Default.Equals(value, default);

            if ((isNotValueType || isNullableValueType) && hasDefaultValue)
                throw new InvalidOperationException();
        }

        #region Select

        public abstract Result<UValue, UError> Select<UValue, UError>(
            Func<TValue, UValue> mapValue,
            Func<TError, UError> mapError);

        public abstract Task<Result<UValue, UError>> SelectAsync<UValue, UError>(
            Func<TValue, Task<UValue>> mapValue,
            Func<TError, Task<UError>> mapError);

        public abstract Result<UValue, TError> Select<UValue>(
            Func<TValue, UValue> mapValue);

        public abstract Task<Result<UValue, TError>> SelectAsync<UValue>(
            Func<TValue, Task<UValue>> mapValue);

        public abstract Result<UError> SelectSwitch<UError>(
            Func<TError, UError> mapError);

        public abstract Result<TError> SelectSwitch();

        #endregion

        #region SelectMany

        public abstract Result<UValue, UError> SelectMany<UValue, UError>(
            Func<TValue, Result<UValue, UError>> mapValue,
            Func<TError, Result<UValue, UError>> mapError);

        public abstract Task<Result<UValue, UError>> SelectManyAsync<UValue, UError>(
            Func<TValue, Task<Result<UValue, UError>>> mapValue,
            Func<TError, Task<Result<UValue, UError>>> mapError);

        public abstract Result<UValue, TError> SelectMany<UValue>(
            Func<TValue, Result<UValue, TError>> mapValue);

        public abstract Task<Result<UValue, TError>> SelectManyAsync<UValue>(
            Func<TValue, Task<Result<UValue, TError>>> mapValue);

        public abstract Result<UError> SelectMany<UError>(
            Func<TValue, Result<UError>> mapValue,
            Func<TError, Result<UError>> mapError);

        public abstract Task<Result<UError>> SelectManyAsync<UError>(
            Func<TValue, Task<Result<UError>>> mapValue,
            Func<TError, Task<Result<UError>>> mapError);

        public abstract Result<TError> SelectMany(
            Func<TValue, Result<TError>> mapValue);

        public abstract Task<Result<TError>> SelectManyAsync(
            Func<TValue, Task<Result<TError>>> mapValue);

        #endregion
    }
}