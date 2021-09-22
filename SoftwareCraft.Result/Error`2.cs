namespace SoftwareCraft.Functional
{
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using System.Threading.Tasks;

	public class Error<TValue, TError> : Result<TValue, TError>
	{
		private readonly TError error;

		internal Error(TError error)
		{
			Validate(error);

			this.error = error;
		}

		public override bool IsSuccess => false;

		#region On

		public override Result<TValue, TError> OnError(Action<TError> onError)
		{
			onError(error);

			return this;
		}

		public override async Task<Result<TValue, TError>> OnErrorAsync(Func<TError, Task> onError)
		{
			await onError(error);

			return this;
		}

		#endregion

		#region Match

		public override void Match(
			Action<TValue> matchValue,
			Action<TError> matchError)
			=> matchError(error);

		public override Task MatchAsync(
			Func<TValue, Task> matchValue,
			Func<TError, Task> matchError)
			=> matchError(error);

		public override TOut Match<TOut>(
			Func<TValue, TOut> matchValue,
			Func<TError, TOut> matchError)
			=> matchError(error);

		public override Task<TOut> MatchAsync<TOut>(
			Func<TValue, Task<TOut>> matchValue,
			Func<TError, Task<TOut>> matchError)
			=> matchError(error);

		#endregion

		#region Select

		public override Result<UValue, UError> Select<UValue, UError>(
			Func<TValue, UValue> mapValue,
			Func<TError, UError> mapError)
			=> new Error<UValue, UError>(mapError(error));

		public override Result<UValue, TError> Select<UValue>(
			Func<TValue, UValue> mapValue) =>
			new Error<UValue, TError>(error);

		public override Result<TValue, UError> Select<UError>(
			Func<TError, UError> mapError)
			=> new Error<TValue, UError>(mapError(error));

		public override Result<UError> SelectSwitch<UError>(
			Action<TValue>       mapValue,
			Func<TError, UError> mapError)
			=> new Error<UError>(mapError(error));

		public override Result<TError> SelectSwitch(Action<TValue> mapValue)
			=> new Error<TError>(error);

		public override Result<UError> SelectSwitch<UError>(Func<TError, UError> mapError)
			=> new Error<UError>(mapError(error));

		public override async Task<Result<UValue, UError>> SelectAsync<UValue, UError>(
			Func<TValue, Task<UValue>> mapValue,
			Func<TError, Task<UError>> mapError)
			=> new Error<UValue, UError>(await mapError(error));

		public override Task<Result<UValue, TError>> SelectAsync<UValue>(Func<TValue, Task<UValue>> mapValue)
			=> Task.FromResult((Result<UValue, TError>)new Error<UValue, TError>(error));

		public override async Task<Result<TValue, UError>> SelectAsync<UError>(Func<TError, Task<UError>> mapError)
			=> new Error<TValue, UError>(await mapError(error));

		public override async Task<Result<UError>> SelectSwitchAsync<UError>(
			Func<TValue, Task>         mapValue,
			Func<TError, Task<UError>> mapError)
			=> new Error<UError>(await mapError(error));

		public override Task<Result<TError>> SelectSwitchAsync(Func<TValue, Task> mapValue)
			=> Task.FromResult((Result<TError>)new Error<TError>(error));

		public override async Task<Result<UError>> SelectSwitchAsync<UError>(Func<TError, Task<UError>> mapError)
			=> new Error<UError>(await mapError(error));

		#endregion

		#region SelectMany

		public override Result<UValue, UError> SelectMany<UValue, UError>(
			Func<TValue, Result<UValue, UError>> mapValue,
			Func<TError, Result<UValue, UError>> mapError)
			=> mapError(error);

		public override Result<UValue, TError> SelectMany<UValue>(
			Func<TValue, Result<UValue, TError>> mapValue)
			=> new Error<UValue, TError>(error);

		public override Result<TValue, UError> SelectMany<UError>(
			Func<TError, Result<TValue, UError>> mapError)
			=> mapError(error);

		public override Result<TError> SelectSwitchMany(Func<TValue, Result<TError>> mapValue)
			=> new Error<TError>(error);

		public override Result<UError> SelectSwitchMany<UError>(Func<TError, Result<UError>> mapError)
			=> mapError(error);

		public override Task<Result<UValue, UError>> SelectManyAsync<UValue, UError>(
			Func<TValue, Task<Result<UValue, UError>>> mapValue,
			Func<TError, Task<Result<UValue, UError>>> mapError)
			=> mapError(error);

		public override Task<Result<UValue, TError>>
			SelectManyAsync<UValue>(Func<TValue, Task<Result<UValue, TError>>> mapValue)
			=> Task.FromResult((Result<UValue, TError>)new Error<UValue, TError>(error));

		public override async Task<Result<TValue, UError>> SelectManyAsync<UError>(
			Func<TError, Task<Result<TValue, UError>>> mapError)
			=> await mapError(error);

		public override Result<UError> SelectSwitchMany<UError>(
			Func<TValue, Result<UError>> mapValue,
			Func<TError, Result<UError>> mapError)
			=> mapError(error);

		public override Task<Result<UError>> SelectSwitchManyAsync<UError>(
			Func<TValue, Task<Result<UError>>> mapValue,
			Func<TError, Task<Result<UError>>> mapError)
			=> mapError(error);

		public override Task<Result<TError>> SelectSwitchManyAsync(
			Func<TValue, Task<Result<TError>>> mapValue)
			=> Task.FromResult((Result<TError>)new Error<TError>(error));

		public override async Task<Result<UError>> SelectSwitchManyAsync<UError>(
			Func<TError, Task<Result<UError>>> mapError)
			=> await mapError(error);

		#endregion
	}
}