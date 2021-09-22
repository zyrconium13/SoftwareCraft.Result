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

		public override bool IsSuccess => false;

		#region On

		public override Result<TError> OnError(Action<TError> onError)
		{
			onError(error);

			return this;
		}

		public override async Task<Result<TError>> OnErrorAsync(Func<TError, Task> onError)
		{
			await onError(error);

			return this;
		}

		#endregion

		#region Match

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

		#endregion

		#region Select

		public override Result<UError> Select<UError>(
			Action               mapSuccess,
			Func<TError, UError> mapError)
			=> new Error<UError>(mapError(error));

		public override Result<TError> Select(
			Action mapSuccess)
			=> new Error<TError>(error);

		public override Result<UError> Select<UError>(
			Func<TError, UError> mapError)
			=> new Error<UError>(mapError(error));

		public override Result<UValue, UError> SelectSwitch<UValue, UError>(
			Func<UValue> mapSuccess, Func<TError, UError> mapError)
			=> new Error<UValue, UError>(mapError(error));

		public override Result<UValue, TError> SelectSwitch<UValue>(
			Func<UValue> mapSuccess)
			=> new Error<UValue, TError>(error);

		public override async Task<Result<UError>> SelectAsync<UError>(
			Func<Task>                 mapSuccess,
			Func<TError, Task<UError>> mapError)
			=> new Error<UError>(await mapError(error));

		public override Task<Result<TError>> SelectAsync(
			Func<Task> mapSuccess)
			=> Task.FromResult((Result<TError>)new Error<TError>(error));

		public override async Task<Result<UError>> SelectAsync<UError>(
			Func<TError, Task<UError>> mapError)
			=> new Error<UError>(await mapError(error));

		public override async Task<Result<UValue, UError>> SelectSwitchAsync<UValue, UError>(
			Func<Task<UValue>>         mapSuccess,
			Func<TError, Task<UError>> mapError)
			=> new Error<UValue, UError>(await mapError(error));

		public override Task<Result<UValue, TError>> SelectSwitchAsync<UValue>(
			Func<Task<UValue>> mapSuccess)
			=> Task.FromResult((Result<UValue, TError>)new Error<UValue, TError>(error));

		#endregion

		#region SelectMany

		public override Result<UError> SelectMany<UError>(
			Func<Result<UError>>         mapSuccess,
			Func<TError, Result<UError>> mapError)
			=> mapError(error);

		public override Result<TError> SelectMany(
			Func<Result<TError>> mapSuccess)
			=> new Error<TError>(error);

		public override Result<UError> SelectMany<UError>(
			Func<TError, Result<UError>> mapError)
			=> mapError(error);

		public override Result<UValue, UError> SelectSwitchMany<UValue, UError>(
			Func<Result<UValue, UError>>         mapSuccess,
			Func<TError, Result<UValue, UError>> mapError)
			=> mapError(error);

		public override Result<UValue, TError> SelectSwitchMany<UValue>(
			Func<Result<UValue, TError>> mapSuccess)
			=> new Error<UValue, TError>(error);

		public override Task<Result<UError>> SelectManyAsync<UError>(
			Func<Task<Result<UError>>>         mapSuccess,
			Func<TError, Task<Result<UError>>> mapError)
			=> mapError(error);

		public override Task<Result<TError>> SelectManyAsync(
			Func<Task<Result<TError>>> mapSuccess)
			=> Task.FromResult((Result<TError>)new Error<TError>(error));

		public override async Task<Result<UError>> SelectManyAsync<UError>(
			Func<TError, Task<Result<UError>>> mapError)
			=> await mapError(error);

		public override async Task<Result<UValue, UError>> SelectSwitchManyAsync<UValue, UError>(
			Func<Task<Result<UValue, UError>>>         mapSuccess,
			Func<TError, Task<Result<UValue, UError>>> mapError)
			=> await mapError(error);

		public override Task<Result<UValue, TError>> SelectSwitchManyAsync<UValue>(
			Func<Task<Result<UValue, TError>>> mapSuccess)
			=> Task.FromResult((Result<UValue, TError>)new Error<UValue, TError>(error));

		#endregion
	}
}