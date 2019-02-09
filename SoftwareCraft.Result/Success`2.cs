using System;
using System.Linq;

namespace SoftwareCraft.Functional
{
	public class Success<TValue, TError> : Result<TValue, TError>
	{
		private readonly TValue value;

		public Success(TValue value)
		{
			Validate(value);

			this.value = value;
		}

		public override Result<TValue, TError> OnSuccess(Action<TValue> onSuccess)
		{
			onSuccess(value);

			return this;
		}

		public override Result<UValue, UError> Map<UValue, UError>(Func<TValue, UValue> mapValue,
			Func<TError, UError> mapError) =>
			Result.Success<UValue, UError>(mapValue(value));
	}
}