﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace SoftwareCraft.Functional
{
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

		//public override Result<TError> Join(Func<Result<TError>> other) => Result.Error(error);

		//public override Result<IEnumerable<TError>> Join(Result<TError> other) =>
		//	other.Match(() => Result.Error<IEnumerable<TError>>(new[] {error}),
		//		e => Result.Error<IEnumerable<TError>>(new[] {error, e}));
	}
}