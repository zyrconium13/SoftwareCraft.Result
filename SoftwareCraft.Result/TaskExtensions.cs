namespace SoftwareCraft.Functional;

using System;
using System.Threading.Tasks;

public static class TaskExtensions
{
  #region Select

  public static async Task<Result<UValue, UError>> Select<TValue, TError, UValue, UError>(
    this Task<Result<TValue, TError>> @this,
    Func<TValue, UValue>              mapValue,
    Func<TError, UError>              mapError)
    => (await @this).Select(mapValue, mapError);

  public static async Task<Result<UValue, TError>> Select<TValue, TError, UValue>(
    this Task<Result<TValue, TError>> @this,
    Func<TValue, UValue>              mapValue)
    => (await @this).Select(mapValue);

  public static async Task<Result<TValue, UError>> Select<TValue, TError, UError>(
    this Task<Result<TValue, TError>> @this,
    Func<TError, UError>              mapError)
    => (await @this).Select(mapError);

  public static async Task<Result<UError>> SelectSwitch<TValue, TError, UError>(
    this Task<Result<TValue, TError>> @this,
    Action<TValue>                    mapValue,
    Func<TError, UError>              mapError)
    => (await @this).SelectSwitch(mapValue, mapError);

  public static async Task<Result<TError>> SelectSwitch<TValue, TError>(
    this Task<Result<TValue, TError>> @this,
    Action<TValue>                    mapValue)
    => (await @this).SelectSwitch(mapValue);

  public static async Task<Result<UError>> SelectSwitch<TValue, TError, UError>(
    this Task<Result<TValue, TError>> @this,
    Func<TError, UError>              mapError)
    => (await @this).SelectSwitch(mapError);

  public static async Task<Result<UValue, UError>> SelectAsync<TValue, TError, UValue, UError>(
    this Task<Result<TValue, TError>> @this,
    Func<TValue, Task<UValue>>        mapValue,
    Func<TError, Task<UError>>        mapError)
    => await (await @this).SelectAsync(mapValue, mapError);

  public static async Task<Result<UValue, TError>> SelectAsync<TValue, TError, UValue>(
    this Task<Result<TValue, TError>> @this,
    Func<TValue, Task<UValue>>        mapValue)
    => await (await @this).SelectAsync(mapValue);

  public static async Task<Result<TValue, UError>> SelectAsync<TValue, TError, UError>(
    this Task<Result<TValue, TError>> @this,
    Func<TError, Task<UError>>        mapError)
    => await (await @this).SelectAsync(mapError);

  public static async Task<Result<UError>> SelectSwitchAsync<TValue, TError, UError>(
    this Task<Result<TValue, TError>> @this,
    Func<TValue, Task>                mapValue,
    Func<TError, Task<UError>>        mapError)
    => await (await @this).SelectSwitchAsync(mapValue, mapError);

  public static async Task<Result<TError>> SelectSwitchAsync<TValue, TError>(
    this Task<Result<TValue, TError>> @this,
    Func<TValue, Task>                mapValue)
    => await (await @this).SelectSwitchAsync(mapValue);

  public static async Task<Result<UError>> SelectSwitchAsync<TValue, TError, UError>(
    this Task<Result<TValue, TError>> @this,
    Func<TError, Task<UError>>        mapError)
    => await (await @this).SelectSwitchAsync(mapError);

  #endregion

  #region SelectMany

  public static async Task<Result<UValue, UError>> SelectMany<TValue, TError, UValue, UError>(
    this Task<Result<TValue, TError>>    @this,
    Func<TValue, Result<UValue, UError>> mapValue,
    Func<TError, Result<UValue, UError>> mapError)
    => (await @this).SelectMany(mapValue, mapError);

  public static async Task<Result<UValue, TError>> SelectMany<TValue, TError, UValue>(
    this Task<Result<TValue, TError>>    @this,
    Func<TValue, Result<UValue, TError>> mapValue)
    => (await @this).SelectMany(mapValue);

  public static async Task<Result<TValue, UError>> SelectMany<TValue, TError, UError>(
    this Task<Result<TValue, TError>>    @this,
    Func<TError, Result<TValue, UError>> mapError)
    => (await @this).SelectMany(mapError);

  public static async Task<Result<UError>> SelectSwitchMany<TValue, TError, UError>(
    this Task<Result<TValue, TError>> @this,
    Func<TValue, Result<UError>>      mapValue,
    Func<TError, Result<UError>>      mapError)
    => (await @this).SelectSwitchMany(mapValue, mapError);

  public static async Task<Result<TError>> SelectSwitchMany<TValue, TError>(
    this Task<Result<TValue, TError>> @this,
    Func<TValue, Result<TError>>      mapValue)
    => (await @this).SelectSwitchMany(mapValue);

  public static async Task<Result<UError>> SelectSwitchMany<TValue, TError, UError>(
    this Task<Result<TValue, TError>> @this,
    Func<TError, Result<UError>>      mapError)
    => (await @this).SelectSwitchMany(mapError);

  public static async Task<Result<UValue, UError>> SelectManyAsync<TValue, TError, UValue, UError>(
    this Task<Result<TValue, TError>>          @this,
    Func<TValue, Task<Result<UValue, UError>>> mapValue,
    Func<TError, Task<Result<UValue, UError>>> mapError)
    => await (await @this).SelectManyAsync(mapValue, mapError);

  public static async Task<Result<UValue, TError>> SelectManyAsync<TValue, TError, UValue>(
    this Task<Result<TValue, TError>>          @this,
    Func<TValue, Task<Result<UValue, TError>>> mapValue)
    => await (await @this).SelectManyAsync(mapValue);

  public static async Task<Result<TValue, UError>> SelectManyAsync<TValue, TError, UError>(
    this Task<Result<TValue, TError>>          @this,
    Func<TError, Task<Result<TValue, UError>>> mapError)
    => await (await @this).SelectManyAsync(mapError);

  public static async Task<Result<UError>> SelectSwitchManyAsync<TValue, TError, UError>(
    this Task<Result<TValue, TError>>  @this,
    Func<TValue, Task<Result<UError>>> mapValue,
    Func<TError, Task<Result<UError>>> mapError)
    => await (await @this).SelectSwitchManyAsync(mapValue, mapError);

  public static async Task<Result<TError>> SelectSwitchManyAsync<TValue, TError>(
    this Task<Result<TValue, TError>>  @this,
    Func<TValue, Task<Result<TError>>> mapValue)
    => await (await @this).SelectSwitchManyAsync(mapValue);

  public static async Task<Result<UError>> SelectSwitchManyAsync<TValue, TError, UError>(
    this Task<Result<TValue, TError>>  @this,
    Func<TError, Task<Result<UError>>> mapError)
    => await (await @this).SelectSwitchManyAsync(mapError);

  #endregion
}