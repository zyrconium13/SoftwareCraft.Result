namespace Tests.Success2Tests;

using System;
using System.Threading.Tasks;
using SampleTypes.Reference;
using SampleTypes.Value;
using Shouldly;
using SoftwareCraft.Functional;
using Xunit;

public sealed class SwitchingTests
{
  private readonly Result<RedDragon, PinkLily> fail;
  private readonly PinkLily                    failValue;

  private readonly Spy spy;

  private readonly Result<RedDragon, PinkLily> success;
  private readonly RedDragon                   successValue;

  public SwitchingTests()
  {
    successValue = new RedDragon();
    failValue    = new PinkLily();

    success = Result.Success<RedDragon, PinkLily>(successValue);
    fail    = Result.Error<RedDragon, PinkLily>(failValue);

    spy = new Spy();
  }

  [Fact(DisplayName = "Success`2 select switch both methods")]
  public void Fact1()
  {
    success.SelectSwitch<PinkLily>(
      v => { spy.Trip(v); },
      e => throw new Exception()).ShouldBeOfType<Success<PinkLily>>();

    spy.VerifyTrip(1, successValue);
  }

  [Fact(DisplayName = "Success`2 select switch map value only")]
  public void Fact2()
  {
    success.SelectSwitch(v => { spy.Trip(v); }).ShouldBeOfType<Success<PinkLily>>();

    spy.VerifyTrip(1, successValue);
  }

  [Fact(DisplayName = "Success`2 select switch map error only (never get called)")]
  public void Fact3()
  {
    success.SelectSwitch(e =>
                                                    {
                                                      spy.Trip();

                                                      return e;
                                                    }).ShouldBeOfType<Success<PinkLily>>();

    spy.VerifyTrip(0);
  }

  [Fact(DisplayName = "Error`2 select switch both methods")]
  public void Fact4()
  {
    fail.SelectSwitch(
      v => throw new Exception(),
      e =>
      {
        spy.Trip(e);

        return e;
      }).ShouldBeOfType<Error<PinkLily>>();

    spy.VerifyTrip(1, failValue);
  }

  [Fact(DisplayName = "Error`2 select switch map value only (never gets called)")]
  public void Fact5()
  {
    fail.SelectSwitch(v =>
                                               {
                                                 spy.Trip(v);

                                                 throw new Exception();
                                               }).ShouldBeOfType<Error<PinkLily>>();

    spy.VerifyTrip(0);
  }

  [Fact(DisplayName = "Error`2 select switch map error only")]
  public void Fact6()
  {
    fail.SelectSwitch(e =>
                                               {
                                                 spy.Trip(e);

                                                 return e;
                                               }).ShouldBeOfType<Error<PinkLily>>();

    spy.VerifyTrip(1, failValue);
  }

  [Fact(DisplayName = "Success`2 select switch async both methods")]
  public async Task Fact7()
  {
    (await success.SelectSwitchAsync<PinkLily>(
                                 v =>
                                 {
                                   spy.Trip(v);
                                   return Task.CompletedTask;
                                 },
                                 e => throw new Exception())).ShouldBeOfType<Success<PinkLily>>();

    spy.VerifyTrip(1, successValue);
  }

  [Fact(DisplayName = "Success`2 select switch async map value only")]
  public async Task Fact8()
  {
    (await success.SelectSwitchAsync(v =>
                                                               {
                                                                 spy.Trip(v);
                                                                 return Task.CompletedTask;
                                                               })).ShouldBeOfType<Success<PinkLily>>();

    spy.VerifyTrip(1, successValue);
  }

  [Fact(DisplayName = "Success`2 select switch async map error only (never get called)")]
  public async Task Fact9()
  {
    (await success.SelectSwitchAsync(e =>
                                                               {
                                                                 spy.Trip(e);

                                                                 return Task.FromResult(e);
                                                               })).ShouldBeOfType<Success<PinkLily>>();

    spy.VerifyTrip(0);
  }

  [Fact(DisplayName = "Error`2 select switch async both methods")]
  public async Task Fact10()
  {
    (await fail.SelectSwitchAsync(
                               v => throw new Exception(),
                               e =>
                               {
                                 spy.Trip(e);

                                 return Task.FromResult(e);
                               })).ShouldBeOfType<Error<PinkLily>>();

    spy.VerifyTrip(1, failValue);
  }

  [Fact(DisplayName = "Error`2 select switch async map value only (never gets called)")]
  public async Task Fact11()
  {
    (await fail.SelectSwitchAsync(v =>
                                                          {
                                                            spy.Trip(v);

                                                            throw new Exception();
                                                          })).ShouldBeOfType<Error<PinkLily>>();

    spy.VerifyTrip(0);
  }

  [Fact(DisplayName = "Error`2 select switch map error only")]
  public async Task Fact12()
  {
    (await fail.SelectSwitchAsync(e =>
                                                          {
                                                            spy.Trip(e);

                                                            return Task.FromResult(e);
                                                          })).ShouldBeOfType<Error<PinkLily>>();

    spy.VerifyTrip(1, failValue);
  }
}