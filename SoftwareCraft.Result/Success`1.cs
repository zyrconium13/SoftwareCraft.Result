using System;
using System.Linq;

namespace SoftwareCraft.Functional
{
	public class Success<TError> : Result<TError>
	{
		public override Result<TError> OnSuccess(Action onSuccess)
		{
			onSuccess();

			return this;
		}

		public override Result<UError> Map<UError>(Func<TError, UError> mapError) => Result.Success<UError>();
	}
}