namespace SoftwareCraft.Functional;

using System;
using System.Collections.Generic;
using System.Linq;

public static class Extensions
{
	public static Result<TSuccess, TError> AsSuccess<TSuccess, TError>(this TSuccess @this) =>
		Result.Success<TSuccess, TError>(@this);

	public static Result<TSuccess, TError> AsError<TSuccess, TError>(this TError @this) =>
		Result.Error<TSuccess, TError>(@this);

	public static Result<TError> AsError<TError>(this TError @this) => Result.Error(@this);
}