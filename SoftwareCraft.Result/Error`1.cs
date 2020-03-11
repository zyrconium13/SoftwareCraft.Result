namespace SoftwareCraft.Functional
{
	using System;
	using System.Linq;

	public class Error<TError> : Result<TError>
	{
		private readonly TError error;

		internal Error(TError error)
		{
			Validate(error);

			this.error = error;
		}

		public override Result<TError> OnError(Action<TError> onError)
		{
			onError(error);

			return this;
		}

		public override void Match(Action matchValue, Action<TError> matchError) => matchError(error);

		public override TOut Match<TOut>(Func<TOut> matchValue, Func<TError, TOut> matchError) => matchError(error);

		public override Result<UError> Select<UError>(Func<TError, UError> mapError) => Result.Error(mapError(error));

		public override Result<UError> SelectMany<UError>(Func<TError, Result<UError>> mapError) => mapError(error);
	}
}