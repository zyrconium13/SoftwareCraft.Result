using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SoftwareCraft.Functional
{
    public class Success<TError> : Result<TError>
    {
        public override Result<TError> OnSuccess(Action onSuccess)
        {
            onSuccess();

            return this;
        }

        public override void Match(
            Action matchValue,
            Action<TError> matchError)
            => matchValue();

        public override Task MatchAsync(
            Func<Task> matchValue,
            Func<TError, Task> matchError)
            => matchValue();

        public override TOut Match<TOut>(
            Func<TOut> matchValue,
            Func<TError, TOut> matchError)
            => matchValue();

        public override Task<TOut> MatchAsync<TOut>(
            Func<Task<TOut>> matchValue,
            Func<TError, Task<TOut>> matchError)
            => matchValue();

        public override Result<UError> Select<UError>(Action mapSuccess, Func<TError, UError> mapError)
        {
	        mapSuccess();

	        return new Success<UError>();
        }

        public override async Task<Result<UError>> SelectAsync<UError>(
            Func<Task> mapSuccess,
            Func<TError, Task<UError>> mapError)
        {
	        await mapSuccess();
	        
	        return new Success<UError>();
        }

        public override Result<UError> SelectMany<UError>(
            Func<TError, Result<UError>> mapError)
            => new Success<UError>();

        public override Task<Result<UError>> SelectManyAsync<UError>(
            Func<TError, Task<Result<UError>>> mapError)
            => Task.FromResult((Result<UError>) new Success<UError>());
    }
}