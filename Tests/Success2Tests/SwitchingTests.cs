namespace Tests.Success2Tests
{
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using System.Threading.Tasks;

	using SampleTypes.Reference;
	using SampleTypes.Value;

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
			successValue = new();
			failValue    = new();

			success = Result.Success<RedDragon, PinkLily>(successValue);
			fail    = Result.Error<RedDragon, PinkLily>(failValue);

			spy = new();
		}

		[Fact(DisplayName = "Success`2 select switch both methods")]
		public void Fact1()
		{
			var _ = (Success<PinkLily>)success.SelectSwitch<PinkLily>(
				v => { spy.Trip(v); },
				e => throw new());

			spy.VerifyTrip(1, successValue);
		}

		[Fact(DisplayName = "Success`2 select switch map value only")]
		public void Fact2()
		{
			var _ = (Success<PinkLily>)success.SelectSwitch(
				v => { spy.Trip(v); });

			spy.VerifyTrip(1, successValue);
		}

		[Fact(DisplayName = "Success`2 select switch map error only (never get called)")]
		public void Fact3()
		{
			var _ = (Success<PinkLily>)success.SelectSwitch(
				e =>
				{
					spy.Trip();

					return e;
				});

			spy.VerifyTrip(0);
		}

		[Fact(DisplayName = "Error`2 select switch both methods")]
		public void Fact4()
		{
			var _ = (Error<PinkLily>)fail.SelectSwitch(
				v => throw new(),
				e =>
				{
					spy.Trip(e);

					return e;
				});

			spy.VerifyTrip(1, failValue);
		}

		[Fact(DisplayName = "Error`2 select switch map value only (never gets called)")]
		public void Fact5()
		{
			var _ = (Error<PinkLily>)fail.SelectSwitch(
				v =>
				{
					spy.Trip(v);

					throw new();
				});

			spy.VerifyTrip(0);
		}

		[Fact(DisplayName = "Error`2 select switch map error only")]
		public void Fact6()
		{
			var _ = (Error<PinkLily>)fail.SelectSwitch(
				e =>
				{
					spy.Trip(e);

					return e;
				});

			spy.VerifyTrip(1, failValue);
		}

		[Fact(DisplayName = "Success`2 select switch async both methods")]
		public async Task Fact7()
		{
			var _ = (Success<PinkLily>)await success.SelectSwitchAsync<PinkLily>(
				v =>
				{
					spy.Trip(v);
					return Task.CompletedTask;
				},
				e => throw new());

			spy.VerifyTrip(1, successValue);
		}

		[Fact(DisplayName = "Success`2 select switch async map value only")]
		public async Task Fact8()
		{
			var _ = (Success<PinkLily>)await success.SelectSwitchAsync(
				v =>
				{
					spy.Trip(v);
					return Task.CompletedTask;
				});

			spy.VerifyTrip(1, successValue);
		}

		[Fact(DisplayName = "Success`2 select switch async map error only (never get called)")]
		public async Task Fact9()
		{
			var _ = (Success<PinkLily>)await success.SelectSwitchAsync(
				e =>
				{
					spy.Trip(e);

					return Task.FromResult(e);
				});

			spy.VerifyTrip(0);
		}

		[Fact(DisplayName = "Error`2 select switch async both methods")]
		public async Task Fact10()
		{
			var _ = (Error<PinkLily>)await fail.SelectSwitchAsync(
				v => throw new(),
				e =>
				{
					spy.Trip(e);

					return Task.FromResult(e);
				});

			spy.VerifyTrip(1, failValue);
		}

		[Fact(DisplayName = "Error`2 select switch async map value only (never gets called)")]
		public async Task Fact11()
		{
			var _ = (Error<PinkLily>)await fail.SelectSwitchAsync(
				v =>
				{
					spy.Trip(v);

					throw new();
				});

			spy.VerifyTrip(0);
		}

		[Fact(DisplayName = "Error`2 select switch map error only")]
		public async Task Fact12()
		{
			var _ = (Error<PinkLily>)await fail.SelectSwitchAsync(
				e =>
				{
					spy.Trip(e);

					return Task.FromResult(e);
				});

			spy.VerifyTrip(1, failValue);
		}
	}
}