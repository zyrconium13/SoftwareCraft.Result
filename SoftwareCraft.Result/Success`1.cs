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
	}
}