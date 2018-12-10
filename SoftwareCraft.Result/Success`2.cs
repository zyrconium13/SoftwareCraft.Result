using System;
using System.Linq;

namespace SoftwareCraft.Functional
{
	public class Success<TValue, TError> : Result<TValue, TError>
	{
		public Success(TValue value)
		{
			InnerValue = new[] {value};
		}

		public override Result<TValue, TError> OnSuccess(Action<TValue> onSuccess)
		{
			onSuccess(InnerValue[0]);

			return this;
		}

		public override Result<TValue, TError> OnError(Action<TError> onError)
		{
			// Do nothing
			return this;
		}

		public override Result<TValue, TError> OnBoth(Action onBoth)
		{
			onBoth();

			return this;
		}
	}
}