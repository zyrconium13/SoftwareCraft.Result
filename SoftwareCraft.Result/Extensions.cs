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
}