using System;
using System.Linq;

namespace SoftwareCraft.Functional
{
	public class Error<TValue, TError> : Result<TValue, TError>
	{
		private readonly TError error;

		public Error(TError error)
		{
			Validate(error);

			this.error = error;
		}

		public override Result<TValue, TError> OnError(Action<TError> onError)
		{
			onError(error);

			return this;
		}
	}
}