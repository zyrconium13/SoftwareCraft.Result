using System;
using System.Linq;

namespace SoftwareCraft.Functional
{
	public class Error<TError> : Result<TError>
	{
		private readonly TError error;

		public Error(TError error)
		{
			Validate(error);

			this.error = error;
		}

		public override Result<TError> OnError(Action<TError> onError)
		{
			onError(error);

			return this;
		}
	}
}