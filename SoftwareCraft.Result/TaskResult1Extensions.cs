namespace SoftwareCraft.Functional;

using System;
using System.Threading.Tasks;

public static class TaskResult1Extensions
{
  #region Match

  public static async Task Match<TError>(
    this Task<Result<TError>> @this,
    Action                    matchValue,
    Action<TError>            matchError)
    => (await @this).Match(matchValue, matchError);

  public static async Task<TOut> Match<TError, TOut>(
    this Task<Result<TError>> @this,
    Func<TOut>                matchValue,
    Func<TError, TOut>        matchError)
    => (await @this).Match(matchValue, matchError);

  public static async Task MatchAsync<TError>(
    this Task<Result<TError>> @this,
    Func<Task>                matchValue,
    Func<TError, Task>        matchError)
    => await (await @this).MatchAsync(matchValue, matchError);

  public static async Task<TOut> MatchAsync<TError, TOut>(
    this Task<Result<TError>> @this,
    Func<Task<TOut>>          matchValue,
    Func<TError, Task<TOut>>  matchError)
    => await (await @this).MatchAsync(matchValue, matchError);

  #endregion

  #region Select

  public static async Task<Result<UError>> Select<TError, UError>(
    this Task<Result<TError>> @this,
    Action                    mapSuccess,
    Func<TError, UError>      mapError)
    => (await @this).Select(mapSuccess, mapError);

  public static async Task<Result<TError>> Select<TError>(
    this Task<Result<TError>> @this,
    Action                    mapSuccess)
    => (await @this).Select(mapSuccess);

  public static async Task<Result<UError>> Select<TError, UError>(
    this Task<Result<TError>> @this,
    Func<TError, UError>      mapError)
    => (await @this).Select(mapError);

  public static async Task<Result<UValue, UError>> SelectSwitch<TError, UValue, UError>(
    this Task<Result<TError>> @this,
    Func<UValue>              mapSuccess,
    Func<TError, UError>      mapError)
    => (await @this).SelectSwitch(mapSuccess, mapError);

  public static async Task<Result<UValue, TError>> SelectSwitch<TError, UValue>(
    this Task<Result<TError>> @this,
    Func<UValue>              mapSuccess)
    => (await @this).SelectSwitch(mapSuccess);

  public static async Task<Result<UError>> SelectAsync<TError, UError>(
    this Task<Result<TError>>  @this,
    Func<Task>                 mapSuccess,
    Func<TError, Task<UError>> mapError)
    => await (await @this).SelectAsync(mapSuccess, mapError);

  public static async Task<Result<TError>> SelectAsync<TError>(
    this Task<Result<TError>> @this,
    Func<Task>                mapSuccess)
    => await (await @this).SelectAsync(mapSuccess);

  public static async Task<Result<UError>> SelectAsync<TError, UError>(
    this Task<Result<TError>>  @this,
    Func<TError, Task<UError>> mapError)
    => await (await @this).SelectAsync(mapError);

  public static async Task<Result<UValue, UError>> SelectSwitchAsync<TError, UValue, UError>(
    this Task<Result<TError>>  @this,
    Func<Task<UValue>>         mapSuccess,
    Func<TError, Task<UError>> mapError)
    => await (await @this).SelectSwitchAsync(mapSuccess, mapError);

  public static async Task<Result<UValue, TError>> SelectSwitchAsync<TError, UValue>(
    this Task<Result<TError>> @this,
    Func<Task<UValue>>        mapSuccess)
    => await (await @this).SelectSwitchAsync(mapSuccess);

  #endregion

  #region SelectMany

  public static async Task<Result<UError>> SelectMany<TError, UError>(
    this Task<Result<TError>>    @this,
    Func<Result<UError>>         mapSuccess,
    Func<TError, Result<UError>> mapError)
    => (await @this).SelectMany(mapSuccess, mapError);

  public static async Task<Result<TError>> SelectMany<TError>(
    this Task<Result<TError>> @this,
    Func<Result<TError>>      mapSuccess)
    => (await @this).SelectMany(mapSuccess);

  public static async Task<Result<UError>> SelectMany<TError, UError>(
    this Task<Result<TError>>    @this,
    Func<TError, Result<UError>> mapError)
    => (await @this).SelectMany(mapError);

  public static async Task<Result<UValue, UError>> SelectSwitchMany<TError, UValue, UError>(
    this Task<Result<TError>>            @this,
    Func<Result<UValue, UError>>         mapSuccess,
    Func<TError, Result<UValue, UError>> mapError)
    => (await @this).SelectSwitchMany(mapSuccess, mapError);

  public static async Task<Result<UValue, TError>> SelectSwitchMany<TError, UValue>(
    this Task<Result<TError>>    @this,
    Func<Result<UValue, TError>> mapSuccess)
    => (await @this).SelectSwitchMany(mapSuccess);

  public static async Task<Result<UError>> SelectManyAsync<TError, UError>(
    this Task<Result<TError>>          @this,
    Func<Task<Result<UError>>>         mapSuccess,
    Func<TError, Task<Result<UError>>> mapError)
    => await (await @this).SelectManyAsync(mapSuccess, mapError);

  public static async Task<Result<TError>> SelectManyAsync<TError>(
    this Task<Result<TError>>  @this,
    Func<Task<Result<TError>>> mapSuccess)
    => await (await @this).SelectManyAsync(mapSuccess);

  public static async Task<Result<UError>> SelectManyAsync<TError, UError>(
    this Task<Result<TError>>          @this,
    Func<TError, Task<Result<UError>>> mapError)
    => await (await @this).SelectManyAsync(mapError);

  public static async Task<Result<UValue, UError>> SelectSwitchManyAsync<TError, UValue, UError>(
    this Task<Result<TError>>                  @this,
    Func<Task<Result<UValue, UError>>>         mapSuccess,
    Func<TError, Task<Result<UValue, UError>>> mapError)
    => await (await @this).SelectSwitchManyAsync(mapSuccess, mapError);

  public static async Task<Result<UValue, TError>> SelectSwitchManyAsync<TError, UValue>(
    this Task<Result<TError>>          @this,
    Func<Task<Result<UValue, TError>>> mapSuccess)
    => await (await @this).SelectSwitchManyAsync(mapSuccess);

  #endregion
}