using System;
using System.Linq;

namespace SoftwareCraft.Functional
{
	public abstract class Result<TValue, TError>
	{
		protected TError[] InnerError;

		protected TValue[] InnerValue;

		protected Result()
		{
			InnerValue = new TValue[0];
			InnerError = new TError[0];
		}

		public abstract Result<TValue, TError> OnSuccess(Action<TValue> onSuccess);

		public abstract Result<TValue, TError> OnError(Action<TError> onError);

		public abstract Result<TValue, TError> OnBoth(Action onBoth);
	}
}