using System;
using System.Linq;

namespace SoftwareCraft.Functional
{
	public class Error<TError> : Result<TError>
	{
		public Error(TError error)
		{
			InnerError = new[] {error};
		}

		public override Result<TError> OnSuccess(Action onSuccess)
		{
			// Do nothing
			return this;
		}

		public override Result<TError> OnError(Action<TError> onError)
		{
			onError(InnerError[0]);

			return this;
		}

		public override Result<TError> OnBoth(Action onBoth)
		{
			onBoth();

			return this;
		}
	}
}