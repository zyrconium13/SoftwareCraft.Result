using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SoftwareCraft.Functional
{
    public class Success<TValue, TError> : Result<TValue, TError>
    {
        private readonly TValue value;

        internal Success(TValue value)
        {
            Validate(value);

            this.value = value;
        }

        public override bool IsSuccess => true;

        internal override TValue Value => value;

        internal override TError ResultError =>
            throw new InvalidOperationException("Calling Error on a Success result.");

        public override Result<TValue, TError> OnSuccess(Action<TValue> onSuccess)
        {
            onSuccess(value);

            return this;
        }

        public override void Match(
            Action<TValue> matchValue,
            Action<TError> matchError)
            => matchValue(value);

        public override TOut Match<TOut>(
            Func<TValue, TOut> matchValue,
            Func<TError, TOut> matchError)
            => matchValue(value);

        //public override Result<TAggregate, TError> Join<UValue, TAggregate>(Func<Result<UValue, TError>> other,
        //    Func<TValue, UValue, TAggregate> aggregator)
        //{
        //    return other().Match(
        //        uValue => Result.Success<TAggregate, TError>(aggregator(value, uValue)),
        //        Result.Error<TAggregate, TError>);
        //}

        //public override Result<TAggregate, IEnumerable<TError>> Join<UValue, TAggregate>(
        //    Result<UValue, TError> other, Func<TValue, UValue, TAggregate> aggregator)
        //{
        //    return other.Match(o => Result.Success<TAggregate, IEnumerable<TError>>(aggregator(value, o)),
        //        e => Result.Error<TAggregate, IEnumerable<TError>>(new[] {e}));
        //}

        #region Select

        public override Result<UValue, UError> Select<UValue, UError>(
            Func<TValue, UValue> mapValue,
            Func<TError, UError> mapError)
            => new Success<UValue, UError>(mapValue(value));

        public override async Task<Result<UValue, UError>> SelectAsync<UValue, UError>(
            Func<TValue, Task<UValue>> mapValue,
            Func<TError, Task<UError>> mapError)
            => new Success<UValue, UError>(await mapValue(value));

        public override Result<UValue, TError> Select<UValue>(
            Func<TValue, UValue> mapValue)
            => new Success<UValue, TError>(mapValue(value));

        public override async Task<Result<UValue, TError>> SelectAsync<UValue>(Func<TValue, Task<UValue>> mapValue)
            => new Success<UValue, TError>(await mapValue(value));

        public override Result<UError> SelectSwitch<UError>(
            Func<TError, UError> mapError)
            => new Success<UError>();

        public override Result<TError> SelectSwitch()
            => new Success<TError>();

        #endregion

        #region SelectMany

        public override Result<UValue, UError> SelectMany<UValue, UError>(
            Func<TValue, Result<UValue, UError>> mapValue,
            Func<TError, Result<UValue, UError>> mapError)
            => mapValue(value);

        public override Task<Result<UValue, UError>> SelectManyAsync<UValue, UError>(
            Func<TValue, Task<Result<UValue, UError>>> mapValue,
            Func<TError, Task<Result<UValue, UError>>> mapError)
            => mapValue(value);

        public override Result<UValue, TError> SelectMany<UValue>(
            Func<TValue, Result<UValue, TError>> mapValue)
            => mapValue(value);

        public override Task<Result<UValue, TError>> SelectManyAsync<UValue>(
            Func<TValue, Task<Result<UValue, TError>>> mapValue)
            => mapValue(value);

        public override Result<UError> SelectMany<UError>(
            Func<TValue, Result<UError>> mapValue,
            Func<TError, Result<UError>> mapError)
            => mapValue(value);

        public override Task<Result<UError>> SelectManyAsync<UError>(
            Func<TValue, Task<Result<UError>>> mapValue, 
            Func<TError, Task<Result<UError>>> mapError)
            => mapValue(value);

        public override Result<TError> SelectMany(
            Func<TValue, Result<TError>> mapValue)
            => mapValue(value);

        public override Task<Result<TError>> SelectManyAsync(Func<TValue, Task<Result<TError>>> mapValue) 
            => mapValue(value);

        #endregion
    }
}