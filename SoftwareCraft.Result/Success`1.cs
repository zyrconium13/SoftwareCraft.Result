namespace SoftwareCraft.Functional
{
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using System.Threading.Tasks;

	public class Success<TError> : Result<TError>
	{
		public override Result<TError> OnSuccess(Action onSuccess)
		{
			onSuccess();

			return this;
		}

		public override async Task<Result<TError>> OnSuccessAsync(Func<Task> onSuccess)
		{
			await onSuccess();

			return this;
		}

		public override void Match(
			Action         matchValue,
			Action<TError> matchError)
			=> matchValue();

		public override Task MatchAsync(
			Func<Task>         matchValue,
			Func<TError, Task> matchError)
			=> matchValue();

		public override TOut Match<TOut>(
			Func<TOut>         matchValue,
			Func<TError, TOut> matchError)
			=> matchValue();

		public override Task<TOut> MatchAsync<TOut>(
			Func<Task<TOut>>         matchValue,
			Func<TError, Task<TOut>> matchError)
			=> matchValue();

		public override Result<UError> Select<UError>(
			Action               mapSuccess,
			Func<TError, UError> mapError)
		{
			mapSuccess();

			return new Success<UError>();
		}

		public override Result<UValue, UError> SelectSwitch<UValue, UError>(
			Func<UValue>         mapSuccess,
			Func<TError, UError> mapError)
			=> new Success<UValue, UError>(mapSuccess());

		public override async Task<Result<UError>> SelectAsync<UError>(
			Func<Task>                 mapSuccess,
			Func<TError, Task<UError>> mapError)
		{
			await mapSuccess();

			return new Success<UError>();
		}

		public override async Task<Result<UValue, UError>>
			SelectSwitchAsync<UValue, UError>(
				Func<Task<UValue>>         mapSuccess,
				Func<TError, Task<UError>> mapError)
			=> new Success<UValue, UError>(await mapSuccess());

		public override Result<UError> SelectMany<UError>(
			Func<Result<UError>>         mapSuccess,
			Func<TError, Result<UError>> mapError)
			=> mapSuccess();

		public override Result<UValue, UError>
			SelectSwitchMany<UValue, UError>(
				Func<Result<UValue, UError>>         mapSuccess,
				Func<TError, Result<UValue, UError>> mapError)
			=> mapSuccess();

		public override Task<Result<UError>> SelectManyAsync<UError>(
			Func<Task<Result<UError>>>         mapSuccess,
			Func<TError, Task<Result<UError>>> mapError)
			=> mapSuccess();

		public override async Task<Result<UValue, UError>>
			SelectSwitchManyAsync<UValue, UError>(
				Func<Task<Result<UValue, UError>>>         mapSuccess,
				Func<TError, Task<Result<UValue, UError>>> mapError)
			=> await mapSuccess();
	}
}