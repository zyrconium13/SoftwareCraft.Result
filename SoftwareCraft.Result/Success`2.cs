namespace SoftwareCraft.Functional
{
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using System.Threading.Tasks;

	public class Success<TValue, TError> : Result<TValue, TError>
	{
		private readonly TValue value;

		internal Success(TValue value)
		{
			Validate(value);

			this.value = value;
		}

		public override bool IsSuccess => true;

		#region On

		public override Result<TValue, TError> OnSuccess(Action<TValue> onSuccess)
		{
			onSuccess(value);

			return this;
		}

		public override async Task<Result<TValue, TError>> OnSuccessAsync(Func<TValue, Task> onSuccess)
		{
			await onSuccess(value);

			return this;
		}

		#endregion

		#region Match

		public override void Match(
			Action<TValue> matchValue,
			Action<TError> matchError)
			=> matchValue(value);

		public override Task MatchAsync(
			Func<TValue, Task> matchValue,
			Func<TError, Task> matchError)
			=> matchValue(value);

		public override TOut Match<TOut>(
			Func<TValue, TOut> matchValue,
			Func<TError, TOut> matchError)
			=> matchValue(value);

		public override Task<TOut> MatchAsync<TOut>(
			Func<TValue, Task<TOut>> matchValue,
			Func<TError, Task<TOut>> matchError)
			=> matchValue(value);

		#endregion

		#region Select

		public override Result<UValue, UError> Select<UValue, UError>(
			Func<TValue, UValue> mapValue,
			Func<TError, UError> mapError)
			=> new Success<UValue, UError>(mapValue(value));

		public override Result<UValue, TError> Select<UValue>(
			Func<TValue, UValue> mapValue)
			=> new Success<UValue, TError>(mapValue(value));

		public override Result<TValue, UError> Select<UError>(
			Func<TError, UError> mapError)
			=> new Success<TValue, UError>(value);

		public override Result<UError> SelectSwitch<UError>(
			Action<TValue>       mapValue,
			Func<TError, UError> mapError)
		{
			mapValue(value);

			return new Success<UError>();
		}

		public override Result<TError> SelectSwitch(Action<TValue> mapValue)
		{
			mapValue(value);

			return new Success<TError>();
		}

		public override Result<UError> SelectSwitch<UError>(Func<TError, UError> mapError)
			=> new Success<UError>();

		public override async Task<Result<UValue, UError>> SelectAsync<UValue, UError>(
			Func<TValue, Task<UValue>> mapValue,
			Func<TError, Task<UError>> mapError)
			=> new Success<UValue, UError>(await mapValue(value));

		public override async Task<Result<UValue, TError>> SelectAsync<UValue>(Func<TValue, Task<UValue>> mapValue)
			=> new Success<UValue, TError>(await mapValue(value));

		public override Task<Result<TValue, UError>> SelectAsync<UError>(Func<TError, Task<UError>> mapError)
			=> Task.FromResult((Result<TValue, UError>)new Success<TValue, UError>(value));

		public override async Task<Result<UError>> SelectSwitchAsync<UError>(
			Func<TValue, Task>         mapValue,
			Func<TError, Task<UError>> mapError)
		{
			await mapValue(value);

			return new Success<UError>();
		}

		public override async Task<Result<TError>> SelectSwitchAsync(Func<TValue, Task> mapValue)
		{
			await mapValue(value);

			return new Success<TError>();
		}

		public override Task<Result<UError>> SelectSwitchAsync<UError>(Func<TError, Task<UError>> mapError)
			=> Task.FromResult((Result<UError>)new Success<UError>());

		#endregion

		#region SelectMany

		public override Result<UValue, UError> SelectMany<UValue, UError>(
			Func<TValue, Result<UValue, UError>> mapValue,
			Func<TError, Result<UValue, UError>> mapError)
			=> mapValue(value);

		public override Result<UValue, TError> SelectMany<UValue>(
			Func<TValue, Result<UValue, TError>> mapValue)
			=> mapValue(value);

		public override Result<TValue, UError> SelectMany<UError>(
			Func<TError, Result<TValue, UError>> mapError)
			=> new Success<TValue, UError>(value);

		public override Result<UError> SelectSwitchMany<UError>(
			Func<TValue, Result<UError>> mapValue,
			Func<TError, Result<UError>> mapError)
			=> mapValue(value);

		public override Result<TError> SelectSwitchMany(Func<TValue, Result<TError>> mapValue)
			=> mapValue(value);

		public override Result<UError> SelectSwitchMany<UError>(Func<TError, Result<UError>> mapError)
			=> new Success<UError>();

		public override Task<Result<UValue, UError>> SelectManyAsync<UValue, UError>(
			Func<TValue, Task<Result<UValue, UError>>> mapValue,
			Func<TError, Task<Result<UValue, UError>>> mapError)
			=> mapValue(value);

		public override async Task<Result<UValue, TError>> SelectManyAsync<UValue>(
			Func<TValue, Task<Result<UValue, TError>>> mapValue)
			=> await mapValue(value);

		public override Task<Result<TValue, UError>> SelectManyAsync<UError>(
			Func<TError, Task<Result<TValue, UError>>> mapError)
			=> Task.FromResult((Result<TValue, UError>)new Success<TValue, UError>(value));

		public override Task<Result<UError>> SelectSwitchManyAsync<UError>(
			Func<TValue, Task<Result<UError>>> mapValue,
			Func<TError, Task<Result<UError>>> mapError)
			=> mapValue(value);

		public override async Task<Result<TError>> SelectSwitchManyAsync(Func<TValue, Task<Result<TError>>> mapValue)
			=> await mapValue(value);

		public override Task<Result<UError>> SelectSwitchManyAsync<UError>(Func<TError, Task<Result<UError>>> mapError)
			=> Task.FromResult((Result<UError>)new Success<UError>());

		#endregion
	}
}