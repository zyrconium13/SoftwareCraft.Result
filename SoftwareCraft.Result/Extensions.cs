namespace SoftwareCraft.Functional;

using System;

public static class Extensions
{
  public static Result<TError> AsSuccess<TError>(this Unit _) =>
    Result.Success<TError>();

  public static Result<TSuccess, TError> AsSuccess<TSuccess, TError>(this TSuccess @this) =>
    Result.Success<TSuccess, TError>(@this);

  public static Result<TSuccess, TError> AsError<TSuccess, TError>(this TError @this) =>
    Result.Error<TSuccess, TError>(@this);

  public static Result<TError> AsError<TError>(this TError @this) => Result.Error(@this);

  public static Result<T1, TError> Apply<T, T1, TError>(this Result<Func<T, T1>, TError> @this, Result<T, TError> other)
    => @this.SelectMany(other.Select);
}