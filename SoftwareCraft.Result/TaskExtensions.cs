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
}