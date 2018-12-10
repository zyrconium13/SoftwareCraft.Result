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

		public override Result<TError> OnError(Action<TError> onError)
		{
			// Do nothing

			return this;
		}

		public override Result<TError> OnBoth(Action onBoth)
		{
			onBoth();

			return this;
		}
	}
}