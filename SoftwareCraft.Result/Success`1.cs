namespace SoftwareCraft.Functional
{
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using System.Threading.Tasks;

	public class Success<TError> : Result<TError>
	{
		public override bool IsSuccess => true;

		#region On

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

		#endregion

		#region Match

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

		#endregion

		#region Select

		public override Result<UError> Select<UError>(
			Action               mapSuccess,
			Func<TError, UError> mapError)
		{
			mapSuccess();

			return new Success<UError>();
		}

		public override Result<TError> Select(
			Action mapSuccess)
		{
			mapSuccess();

			return new Success<TError>();
		}

		public override Result<UError> Select<UError>(
			Func<TError, UError> mapError)
			=> new Success<UError>();

		public override Result<UValue, UError> SelectSwitch<UValue, UError>(
			Func<UValue>         mapSuccess,
			Func<TError, UError> mapError)
			=> new Success<UValue, UError>(mapSuccess());

		public override Result<UValue, TError> SelectSwitch<UValue>(
			Func<UValue> mapSuccess)
			=> new Success<UValue, TError>(mapSuccess());

		public override async Task<Result<UError>> SelectAsync<UError>(
			Func<Task>                 mapSuccess,
			Func<TError, Task<UError>> mapError)
		{
			await mapSuccess();

			return new Success<UError>();
		}

		public override async Task<Result<TError>> SelectAsync(
			Func<Task> mapSuccess)
		{
			await mapSuccess();

			return new Success<TError>();
		}

		public override Task<Result<UError>> SelectAsync<UError>(
			Func<TError, Task<UError>> mapError)
			=> Task.FromResult((Result<UError>)new Success<UError>());

		public override async Task<Result<UValue, UError>>
			SelectSwitchAsync<UValue, UError>(
				Func<Task<UValue>>         mapSuccess,
				Func<TError, Task<UError>> mapError)
			=> new Success<UValue, UError>(await mapSuccess());

		public override async Task<Result<UValue, TError>> SelectSwitchAsync<UValue>(
			Func<Task<UValue>> mapSuccess)
			=> new Success<UValue, TError>(await mapSuccess());

		#endregion

		#region SelectMany

		public override Result<UError> SelectMany<UError>(
			Func<Result<UError>>         mapSuccess,
			Func<TError, Result<UError>> mapError)
			=> mapSuccess();

		public override Result<TError> SelectMany(
			Func<Result<TError>> mapSuccess)
			=> mapSuccess();

		public override Result<UError> SelectMany<UError>(
			Func<TError, Result<UError>> mapError)
			=> new Success<UError>();

		public override Result<UValue, UError> SelectSwitchMany<UValue, UError>(
			Func<Result<UValue, UError>>         mapSuccess,
			Func<TError, Result<UValue, UError>> mapError)
			=> mapSuccess();

		public override Result<UValue, TError> SelectSwitchMany<UValue>(
			Func<Result<UValue, TError>> mapSuccess)
			=> mapSuccess();

		public override Task<Result<UError>> SelectManyAsync<UError>(
			Func<Task<Result<UError>>>         mapSuccess,
			Func<TError, Task<Result<UError>>> mapError)
			=> mapSuccess();

		public override async Task<Result<TError>> SelectManyAsync(
			Func<Task<Result<TError>>> mapSuccess)
		{
			await mapSuccess();

			return new Success<TError>();
		}

		public override Task<Result<UError>> SelectManyAsync<UError>(
			Func<TError, Task<Result<UError>>> mapError)
			=> Task.FromResult((Result<UError>)new Success<UError>());

		public override async Task<Result<UValue, UError>> SelectSwitchManyAsync<UValue, UError>(
			Func<Task<Result<UValue, UError>>>         mapSuccess,
			Func<TError, Task<Result<UValue, UError>>> mapError)
			=> await mapSuccess();

		public override async Task<Result<UValue, TError>> SelectSwitchManyAsync<UValue>(
			Func<Task<Result<UValue, TError>>> mapSuccess)
			=> await mapSuccess();

		#endregion
	}
}