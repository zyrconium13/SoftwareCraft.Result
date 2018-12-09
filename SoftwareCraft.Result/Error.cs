using System;
using System.Linq;

namespace SoftwareCraft.Functional
{
	public class Error<TValue, TError> : Result<TValue, TError>
	{
		public Error(TError error)
		{
			InnerError = new[] {error};
		}

		public override bool IsSuccess => false;
		public override bool IsError => true;

		public override Result<TValue, TError> OnSuccess(Action<TValue> onSuccess)
		{
			// Do nothing
			return this;
		}

		public override Result<TValue, TError> OnError(Action<TError> onError)
		{
			onError(InnerError[0]);

			return this;
		}

		public override Result<TValue, TError> OnBoth(Action onBoth)
		{
			onBoth();

			return this;
		}
	}
}