﻿using System;
using System.Linq;

namespace SoftwareCraft.Functional
{
	public class Success<TValue, TError> : Result<TValue, TError>
	{
		private readonly TValue value;

		public Success(TValue value)
		{
			Validate(value);

			this.value = value;
		}

		public override Result<TValue, TError> OnSuccess(Action<TValue> onSuccess)
		{
			onSuccess(value);

			return this;
		}

		public override Result<Tuple<TValue1, TValue2>, TError> OnSuccess<TValue1, TValue2>(
			Action<TValue1, TValue2> onSuccess)
		{
			onSuccess((value as Tuple<TValue1, TValue2>).Item1, (value as Tuple<TValue1, TValue2>).Item2);

			return new Success<Tuple<TValue1, TValue2>, TError>(value as Tuple<TValue1, TValue2>);
		}

		public override Result<Tuple<TValue1, TValue2, TValue3>, TError> OnSuccess<TValue1, TValue2, TValue3>(
			Action<TValue1, TValue2, TValue3> onSuccess)
		{
			onSuccess((value as Tuple<TValue1, TValue2, TValue3>).Item1, (value as Tuple<TValue1, TValue2, TValue3>).Item2, (value as Tuple<TValue1, TValue2, TValue3>).Item3);

			return new Success<Tuple<TValue1, TValue2, TValue3>, TError>(value as Tuple<TValue1, TValue2, TValue3>);
		}

		public override void Match(
			Action<TValue> matchValue,
			Action<TError> matchError)
			=> matchValue(value);

		public override void Match<TValue1, TValue2>(
			Action<TValue1, TValue2> matchValue,
			Action<TError> matchError)
		{
			matchValue((value as Tuple<TValue1, TValue2>).Item1, (value as Tuple<TValue1, TValue2>).Item2);
		}

		public override void Match<TValue1, TValue2, TValue3>(
			Action<TValue1, TValue2, TValue3> matchValue,
			Action<TError> matchError)
		{
			matchValue((value as Tuple<TValue1, TValue2, TValue3>).Item1, (value as Tuple<TValue1, TValue2, TValue3>).Item2, (value as Tuple<TValue1, TValue2, TValue3>).Item3);
		}

		public override TOut Match<TOut>(Func<TValue, TOut> matchValue, Func<TError, TOut> matchError)
			=> matchValue(value);

		public override TOut Match<TValue1, TValue2, TOut>(
			Func<TValue1, TValue2, TOut> matchValue,
			Func<TError, TOut> matchError)
			=> matchValue((value as Tuple<TValue1, TValue2>).Item1, (value as Tuple<TValue1, TValue2>).Item2);

		public override TOut Match<TValue1, TValue2, TValue3, TOut>(
			Func<TValue1, TValue2, TValue3, TOut> matchValue,
			Func<TError, TOut> matchError)
			=> matchValue((value as Tuple<TValue1, TValue2, TValue3>).Item1, (value as Tuple<TValue1, TValue2, TValue3>).Item2, (value as Tuple<TValue1, TValue2, TValue3>).Item3);

		public override Result<UValue, UError> Select<UValue, UError>(
			Func<TValue, UValue> mapValue,
			Func<TError, UError> mapError)
			=> Result.Success<UValue, UError>(mapValue(value));

		public override Result<UValue, TError> Select<UValue>(
			Func<TValue, UValue> mapValue)
			=> Result.Success<UValue, TError>(mapValue(value));

		public override Result<UError> Select<UError>(
			Action<TValue> mapValue,
			Func<TError, UError> mapError)
		{
			mapValue(value);
			return Result.Success<UError>();
		}

		public override Result<TError> Select(Action<TValue> mapValue)
		{
			mapValue(value);

			return Result.Success<TError>();
		}

		public override Result<UValue, UError> SelectMany<UValue, UError>(
			Func<TValue, Result<UValue, UError>> mapValue,
			Func<TError, Result<UValue, UError>> mapError)
			=> mapValue(value);

		public override Result<UError> SelectMany<UError>(
			Func<TValue, Result<UError>> mapValue,
			Func<TError, Result<UError>> mapError)
			=> mapValue(value);

		public override Result<TError> SelectMany(
			Func<TValue, Result<TError>> mapValue)
			=> mapValue(value);

		public override Result<UValue, TError> SelectMany<UValue>(
			Func<TValue, Result<UValue, TError>> mapValue)
			=> mapValue(value);

		public override Result<TAggregate, TError> Join<UValue, TAggregate>(Func<Result<UValue, TError>> other,
			Func<TValue, UValue, TAggregate> aggregator)
		{
			return other().Match<Result<TAggregate, TError>>(
				uValue => new Success<TAggregate, TError>(aggregator(value, uValue)),
				error => new Error<TAggregate, TError>(error));
		}
	}
}