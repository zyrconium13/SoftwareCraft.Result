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

		public override void Match(Action matchValue, Action<TError> matchError) => matchValue();

		public override TOut Match<TOut>(Func<TOut> matchValue, Func<TError, TOut> matchError) => matchValue();

		public override Result<UError> Select<UError>(Func<TError, UError> mapError) =>
			Result.Success<UError>();

		public override Result<UError> SelectMany<UError>(Func<TError, Result<UError>> mapError) =>
			Result.Success<UError>();
	}
}