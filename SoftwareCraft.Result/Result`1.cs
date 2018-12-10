using System;
using System.Linq;

namespace SoftwareCraft.Functional
{
	public abstract class Result<TError>
	{
		protected TError[] InnerError;

		protected Result()
		{
			InnerError = new TError[0];
		}

		public abstract Result<TError> OnSuccess(Action onSuccess);

		public abstract Result<TError> OnError(Action<TError> onError);

		public abstract Result<TError> OnBoth(Action onBoth);
	}
}