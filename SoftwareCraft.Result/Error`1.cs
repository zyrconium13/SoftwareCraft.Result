namespace SoftwareCraft.Functional
{
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using System.Threading.Tasks;

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
			Action         matchValue,
			Action<TError> matchError)
			=> matchError(error);

		public override Task MatchAsync(
			Func<Task>         matchValue,
			Func<TError, Task> matchError)
			=> matchError(error);

		public override TOut Match<TOut>(
			Func<TOut>         matchValue,
			Func<TError, TOut> matchError)
			=> matchError(error);

		public override Task<TOut> MatchAsync<TOut>(
			Func<Task<TOut>>         matchValue,
			Func<TError, Task<TOut>> matchError)
			=> matchError(error);

		public override Result<UError> Select<UError>(Action mapSuccess, Func<TError, UError> mapError) =>
			new Error<UError>(mapError(error));

		public override async Task<Result<UError>> SelectAsync<UError>(
			Func<Task>                 mapSuccess,
			Func<TError, Task<UError>> mapError)
			=> new Error<UError>(await mapError(error));

		public override Result<UError> SelectMany<UError>(
			Func<Result<UError>>         mapSuccess,
			Func<TError, Result<UError>> mapError)
			=> mapError(error);

		public override Task<Result<UError>> SelectManyAsync<UError>(
			Func<Task<Result<UError>>>         mapSuccess,
			Func<TError, Task<Result<UError>>> mapError)
			=> mapError(error);
	}
}