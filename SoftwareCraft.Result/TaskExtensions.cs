namespace SoftwareCraft.Functional;

using System;
using System.Threading.Tasks;

internal static class TaskExtensions
{
  public static async Task<Result<UValue, UError>> Select<TValue, TError, UValue, UError>(
    this Task<Result<TValue, TError>> @this
  , Func<TValue, UValue>              mapValue
  , Func<TError, UError>              mapError)
    => (await @this).Select(mapValue, mapError);
}