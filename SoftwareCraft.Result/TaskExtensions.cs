namespace SoftwareCraft.Functional;

using System;
using System.Threading.Tasks;

public static class TaskExtensions
{
  #region Select

  extension<TValue, TError>(Task<Result<TValue, TError>> @this)
  {
    public async Task<Result<UValue, UError>> Select<UValue, UError>(Func<TValue, UValue> mapValue,
                                                                     Func<TError, UError> mapError)
      => (await @this).Select(mapValue, mapError);

    public async Task<Result<UValue, TError>> Select<UValue>(Func<TValue, UValue> mapValue)
      => (await @this).Select(mapValue);

    public async Task<Result<TValue, UError>> Select<UError>(Func<TError, UError> mapError)
      => (await @this).Select(mapError);

    public async Task<Result<UError>> SelectSwitch<UError>(Action<TValue>       mapValue,
                                                           Func<TError, UError> mapError)
      => (await @this).SelectSwitch(mapValue, mapError);

    public async Task<Result<TError>> SelectSwitch(Action<TValue> mapValue)
      => (await @this).SelectSwitch(mapValue);

    public async Task<Result<UError>> SelectSwitch<UError>(Func<TError, UError> mapError)
      => (await @this).SelectSwitch(mapError);

    public async Task<Result<UValue, UError>> SelectAsync<UValue, UError>(Func<TValue, Task<UValue>> mapValue,
                                                                          Func<TError, Task<UError>> mapError)
      => await (await @this).SelectAsync(mapValue, mapError);

    public async Task<Result<UValue, TError>> SelectAsync<UValue>(Func<TValue, Task<UValue>> mapValue)
      => await (await @this).SelectAsync(mapValue);

    public async Task<Result<TValue, UError>> SelectAsync<UError>(Func<TError, Task<UError>> mapError)
      => await (await @this).SelectAsync(mapError);

    public async Task<Result<UError>> SelectSwitchAsync<UError>(Func<TValue, Task>         mapValue,
                                                                Func<TError, Task<UError>> mapError)
      => await (await @this).SelectSwitchAsync(mapValue, mapError);

    public async Task<Result<TError>> SelectSwitchAsync(Func<TValue, Task> mapValue)
      => await (await @this).SelectSwitchAsync(mapValue);

    public async Task<Result<UError>> SelectSwitchAsync<UError>(Func<TError, Task<UError>> mapError)
      => await (await @this).SelectSwitchAsync(mapError);
  }

  #endregion

  #region SelectMany

  extension<TValue, TError>(Task<Result<TValue, TError>> @this)
  {
    public async Task<Result<UValue, UError>> SelectMany<UValue, UError>(Func<TValue, Result<UValue, UError>> mapValue,
                                                                         Func<TError, Result<UValue, UError>> mapError)
      => (await @this).SelectMany(mapValue, mapError);

    public async Task<Result<UValue, TError>> SelectMany<UValue>(Func<TValue, Result<UValue, TError>> mapValue)
      => (await @this).SelectMany(mapValue);

    public async Task<Result<TValue, UError>> SelectMany<UError>(Func<TError, Result<TValue, UError>> mapError)
      => (await @this).SelectMany(mapError);

    public async Task<Result<UError>> SelectSwitchMany<UError>(Func<TValue, Result<UError>> mapValue,
                                                               Func<TError, Result<UError>> mapError)
      => (await @this).SelectSwitchMany(mapValue, mapError);

    public async Task<Result<TError>> SelectSwitchMany(Func<TValue, Result<TError>> mapValue)
      => (await @this).SelectSwitchMany(mapValue);

    public async Task<Result<UError>> SelectSwitchMany<UError>(Func<TError, Result<UError>> mapError)
      => (await @this).SelectSwitchMany(mapError);

    public async Task<Result<UValue, UError>> SelectManyAsync<UValue, UError>(Func<TValue, Task<Result<UValue, UError>>> mapValue,
                                                                              Func<TError, Task<Result<UValue, UError>>> mapError)
      => await (await @this).SelectManyAsync(mapValue, mapError);

    public async Task<Result<UValue, TError>> SelectManyAsync<UValue>(Func<TValue, Task<Result<UValue, TError>>> mapValue)
      => await (await @this).SelectManyAsync(mapValue);

    public async Task<Result<TValue, UError>> SelectManyAsync<UError>(Func<TError, Task<Result<TValue, UError>>> mapError)
      => await (await @this).SelectManyAsync(mapError);

    public async Task<Result<UError>> SelectSwitchManyAsync<UError>(Func<TValue, Task<Result<UError>>> mapValue,
                                                                    Func<TError, Task<Result<UError>>> mapError)
      => await (await @this).SelectSwitchManyAsync(mapValue, mapError);

    public async Task<Result<TError>> SelectSwitchManyAsync(Func<TValue, Task<Result<TError>>> mapValue)
      => await (await @this).SelectSwitchManyAsync(mapValue);

    public async Task<Result<UError>> SelectSwitchManyAsync<UError>(Func<TError, Task<Result<UError>>> mapError)
      => await (await @this).SelectSwitchManyAsync(mapError);
  }

  #endregion

  #region Match

  extension<TValue, TError>(Task<Result<TValue, TError>> @this)
  {
    public async Task Match(Action<TValue> matchValue,
                            Action<TError> matchError)
      => (await @this).Match(matchValue, matchError);

    public async Task<TOut> Match<TOut>(Func<TValue, TOut> matchValue,
                                        Func<TError, TOut> matchError)
      => (await @this).Match(matchValue, matchError);

    public async Task MatchAsync(Func<TValue, Task> matchValue,
                                 Func<TError, Task> matchError)
      => await (await @this).MatchAsync(matchValue, matchError);

    public async Task<TOut> MatchAsync<TOut>(Func<TValue, Task<TOut>> matchValue,
                                             Func<TError, Task<TOut>> matchError)
      => await (await @this).MatchAsync(matchValue, matchError);
  }

  #endregion
}