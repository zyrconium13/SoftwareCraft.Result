using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SoftwareCraft.Functional
{
    public class Error<TError> : Result<TError>
    {
        private readonly TError error;

        internal Error(TError error)
        {
            Validate(error);

            this.error = error;
        }

        public override Result<TError> OnError(Action<TError> onError)
        {
            onError(error);

            return this;
        }

        public override void Match(
            Action matchValue,
            Action<TError> matchError)
            => matchError(error);

        public override Task MatchAsync(
            Func<Task> matchValue,
            Func<TError, Task> matchError)
            => matchError(error);

        public override TOut Match<TOut>(
            Func<TOut> matchValue,
            Func<TError, TOut> matchError)
            => matchError(error);

        public override Task<TOut> MatchAsync<TOut>(
            Func<Task<TOut>> matchValue,
            Func<TError, Task<TOut>> matchError)
            => matchError(error);

        public override Result<UError> Select<UError>(
            Func<TError, UError> mapError)
            => new Error<UError>(mapError(error));

        public override async Task<Result<UError>> SelectAsync<UError>(
            Func<TError, Task<UError>> mapError)
            => new Error<UError>(await mapError(error));

        public override Result<UError> SelectMany<UError>(
            Func<TError, Result<UError>> mapError)
            => mapError(error);

        public override Task<Result<UError>> SelectManyAsync<UError>(
            Func<TError, Task<Result<UError>>> mapError)
            => mapError(error);
    }
}