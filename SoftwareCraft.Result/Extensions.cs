namespace SoftwareCraft.Functional;

public static class Extensions
{
  public static Result<TError> AsSuccess<TError>(this Unit _) =>
    Result.Success<TError>();

  public static Result<TSuccess, TError> AsSuccess<TSuccess, TError>(this TSuccess @this) =>
    Result.Success<TSuccess, TError>(@this);

  public static Result<TSuccess, TError> AsError<TSuccess, TError>(this TError @this) =>
    Result.Error<TSuccess, TError>(@this);

  public static Result<TError> AsError<TError>(this TError @this) => Result.Error(@this);

  public static Result<T1, TError> Apply<T, T1, TError>(
    this Result<Func<T, T1>, TError> @this,
    Result<T, TError>                other)
    => @this.SelectMany(other.Select);

  public static Result<T1, TError> Apply<T, T1, TError>(
    this Result<Func<T, T1>, TError> @this,
    Result<T, TError>                other,
    Func<TError, TError, TError>     combineErrors)
    => @this.Match<Result<T1, TError>>(
      other.Select,
      e1 => Result.Error<T1, TError>(
        other.Match(
          _ => e1,
          e2 => combineErrors(e1, e2))));


  [Obsolete("Error mapping into another type is out of scope.")]
  public static Result<T1, UError> Apply<T, T1, TError, UError>(
    this Result<Func<T, T1>, TError> @this
  , Result<T, TError>                other
  , Func<TError, TError, TError>     combineErrors
  , Func<TError, UError>             errorMap)
    => @this.SelectMany<T1, UError>(
      func => other.Select(func, errorMap)
    , thisError => other.SelectMany(
        _ => Result.Error<T1, UError>(errorMap(thisError))
      , otherError => Result.Error<T1, UError>(errorMap(combineErrors(thisError, otherError)))));
}