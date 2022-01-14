using System;
using System.Collections.Generic;
using System.Linq;

namespace SoftwareCraft.Functional;

using System.Threading.Tasks;

public static class Result
{
	public static Result<TValue, TError> Success<TValue, TError>(TValue value) =>
		new Success<TValue, TError>(value);

	public static Result<TValue, TError> Error<TValue, TError>(TError error) => new Error<TValue, TError>(error);

	public static Result<TError> Success<TError>() => new Success<TError>();

	public static Result<TError> Error<TError>(TError error) => new Error<TError>(error);

	public static class Lifting
	{
		#region Lift2

		#region Result`1

		public static Result<TError> Lift<TError>
		(
			Result<TError> r1,
			Result<TError> r2
		)
			=> r1.SelectMany(
				() => r2.SelectMany(
					Success<TError>));

		public static async Task<Result<TError>> LiftAsync<TError>
		(
			Task<Result<TError>> r1,
			Task<Result<TError>> r2
		)
			=> await (await r1).SelectManyAsync(
				async () => (await r2).SelectMany(
					Success<TError>));

		#endregion

		#region Result`2

		public static Result<Tuple<T1, T2>, TError> Lift<T1, T2, TError>
		(
			Result<T1, TError> r1,
			Result<T2, TError> r2
		)
			=> r1.SelectMany(
				t1 => r2.SelectMany(
					t2 => Success<Tuple<T1, T2>, TError>(Tuple.Create(t1, t2))));

		public static async Task<Result<Tuple<T1, T2>, TError>> LiftAsync<T1, T2, TError>
		(
			Task<Result<T1, TError>> r1,
			Task<Result<T2, TError>> r2
		)
			=> await (await r1).SelectManyAsync(
				async t1 => (await r2).SelectMany(
					t2 => Success<Tuple<T1, T2>, TError>(Tuple.Create(t1, t2))));

		public static Result<Tuple<T1, T2>, TError> LiftLazy<T1, T2, TError>
		(
			Func<Result<T1, TError>> f1,
			Func<Result<T2, TError>> f2
		)
			=> f1().SelectMany(
				t1 => f2().SelectMany(
					t2 => Success<Tuple<T1, T2>, TError>(Tuple.Create(t1, t2))));

		public static async Task<Result<Tuple<T1, T2>, TError>> LiftLazyAsync<T1, T2, TError>
		(
			Func<Task<Result<T1, TError>>> f1,
			Func<Task<Result<T2, TError>>> f2
		)
			=> await (await f1()).SelectManyAsync(
				async t1 => (await f2()).SelectMany(
					t2 => Success<Tuple<T1, T2>, TError>(Tuple.Create(t1, t2))),
				e1 => Task.FromResult(Error<Tuple<T1, T2>, TError>(e1)));

		#endregion

		#endregion

		#region Lift3

		public static Result<TError> Lift<TError>
		(
			Result<TError> r1,
			Result<TError> r2,
			Result<TError> r3
		)
			=> r1.SelectMany(
				_ => r2.SelectMany(
					_ => r3.SelectMany(
						_ => Success<TError>())));

		public static async Task<Result<TError>> LiftAsync<TError>
		(
			Task<Result<TError>> r1,
			Task<Result<TError>> r2,
			Task<Result<TError>> r3
		)
			=> await (await r1).SelectManyAsync(
				async _ => await (await r2).SelectManyAsync(
					async _ => (await r3).SelectMany(
						_ => Success<TError>())));

		public static Result<Tuple<T1, T2, T3>, TError> Lift<T1, T2, T3, TError>
		(
			Result<T1, TError> r1,
			Result<T2, TError> r2,
			Result<T3, TError> r3
		)
			=> r1.SelectMany(
				t1 => r2.SelectMany(
					t2 => r3.SelectMany(
						t3 => Success<Tuple<T1, T2, T3>, TError>(Tuple.Create(t1, t2, t3)))));

		public static async Task<Result<Tuple<T1, T2, T3>, TError>> LiftAsync<T1, T2, T3, TError>
		(
			Task<Result<T1, TError>> r1,
			Task<Result<T2, TError>> r2,
			Task<Result<T3, TError>> r3
		)
			=> await (await r1).SelectManyAsync(
				async t1 => await (await r2).SelectManyAsync(
					async t2 => (await r3).SelectMany(
						t3 => Success<Tuple<T1, T2, T3>, TError>(Tuple.Create(t1, t2, t3)))));

		public static Result<Tuple<T1, T2, T3>, TError> LiftLazy<T1, T2, T3, TError>
		(
			Func<Result<T1, TError>> f1,
			Func<Result<T2, TError>> f2,
			Func<Result<T3, TError>> f3
		)
			=> f1().SelectMany(
				t1 => f2().SelectMany(
					t2 => f3().SelectMany(
						t3 => Success<Tuple<T1, T2, T3>, TError>(Tuple.Create(t1, t2, t3)))));

		public static async Task<Result<Tuple<T1, T2, T3>, TError>> LiftLazyAsync<T1, T2, T3, TError>
		(
			Func<Task<Result<T1, TError>>> f1,
			Func<Task<Result<T2, TError>>> f2,
			Func<Task<Result<T3, TError>>> f3
		)
			=> await (await f1()).SelectManyAsync(
				async t1 => await (await f2()).SelectManyAsync(
					async t2 => (await f3()).SelectMany(
						t3 => Success<Tuple<T1, T2, T3>, TError>(Tuple.Create(t1, t2, t3))),
					e2 => Task.FromResult(Error<Tuple<T1, T2, T3>, TError>(e2))),
				e1 => Task.FromResult(Error<Tuple<T1, T2, T3>, TError>(e1)));

		#endregion

		#region Lift4

		public static Result<TError> Lift<TError>
		(
			Result<TError> r1,
			Result<TError> r2,
			Result<TError> r3,
			Result<TError> r4
		)
			=> r1.SelectMany(
				_ => r2.SelectMany(
					_ => r3.SelectMany(
						_ => r4.SelectMany(
							_ => Success<TError>()))));

		public static async Task<Result<TError>> LiftAsync<TError>
		(
			Task<Result<TError>> r1,
			Task<Result<TError>> r2,
			Task<Result<TError>> r3,
			Task<Result<TError>> r4
		)
			=> await (await r1).SelectManyAsync(
				async _ => await (await r2).SelectManyAsync(
					async _ => await (await r3).SelectManyAsync(
						async _ => (await r4).SelectMany(
							_ => Success<TError>()))));

		public static Result<Tuple<T1, T2, T3, T4>, TError> Lift<T1, T2, T3, T4, TError>
		(
			Result<T1, TError> r1,
			Result<T2, TError> r2,
			Result<T3, TError> r3,
			Result<T4, TError> r4
		)
			=> r1.SelectMany(
				t1 => r2.SelectMany(
					t2 => r3.SelectMany(
						t3 => r4.SelectMany(
							t4 => Success<Tuple<T1, T2, T3, T4>, TError>(Tuple.Create(t1, t2, t3, t4))))));

		public static async Task<Result<Tuple<T1, T2, T3, T4>, TError>> LiftAsync<T1, T2, T3, T4, TError>
		(
			Task<Result<T1, TError>> r1,
			Task<Result<T2, TError>> r2,
			Task<Result<T3, TError>> r3,
			Task<Result<T4, TError>> r4
		)
			=> await (await r1).SelectManyAsync(
				async t1 => await (await r2).SelectManyAsync(
					async t2 => await (await r3).SelectManyAsync(
						async t3 => (await r4).SelectMany(
							t4 => Success<Tuple<T1, T2, T3, T4>, TError>(Tuple.Create(t1, t2, t3, t4))))));

		public static Result<Tuple<T1, T2, T3, T4>, TError> LiftLazy<T1, T2, T3, T4, TError>
		(
			Func<Result<T1, TError>> f1,
			Func<Result<T2, TError>> f2,
			Func<Result<T3, TError>> f3,
			Func<Result<T4, TError>> f4
		)
			=> f1().SelectMany(
				t1 => f2().SelectMany(
					t2 => f3().SelectMany(
						t3 => f4().SelectMany(
							t4 => Success<Tuple<T1, T2, T3, T4>, TError>(Tuple.Create(t1, t2, t3, t4))))));

		public static async Task<Result<Tuple<T1, T2, T3, T4>, TError>> LiftLazyAsync<T1, T2, T3, T4, TError>
		(
			Func<Task<Result<T1, TError>>> f1,
			Func<Task<Result<T2, TError>>> f2,
			Func<Task<Result<T3, TError>>> f3,
			Func<Task<Result<T4, TError>>> f4
		)
			=> await (await f1()).SelectManyAsync(
				async t1 => await (await f2()).SelectManyAsync(
					async t2 => await (await f3()).SelectManyAsync(
						async t3 => (await f4()).SelectMany(
							t4 => Success<Tuple<T1, T2, T3, T4>, TError>(Tuple.Create(t1, t2, t3, t4))),
						e3 => Task.FromResult(Error<Tuple<T1, T2, T3, T4>, TError>(e3))),
					e2 => Task.FromResult(Error<Tuple<T1, T2, T3, T4>, TError>(e2))),
				e1 => Task.FromResult(Error<Tuple<T1, T2, T3, T4>, TError>(e1)));

		#endregion

		#region Lift5

		public static Result<TError> Lift<TError>
		(
			Result<TError> r1,
			Result<TError> r2,
			Result<TError> r3,
			Result<TError> r4,
			Result<TError> r5
		)
			=> r1.SelectMany(
				_ => r2.SelectMany(
					_ => r3.SelectMany(
						_ => r4.SelectMany(
							_ => r5.SelectMany(
								_ => Success<TError>())))));

		public static async Task<Result<TError>> LiftAsync<TError>
		(
			Task<Result<TError>> r1,
			Task<Result<TError>> r2,
			Task<Result<TError>> r3,
			Task<Result<TError>> r4,
			Task<Result<TError>> r5
		)
			=> await (await r1).SelectManyAsync(
				async _ => await (await r2).SelectManyAsync(
					async _ => await (await r3).SelectManyAsync(
						async _ => await (await r4).SelectManyAsync(
							async _ => (await r5).SelectMany(
								_ => Success<TError>())))));

		public static Result<Tuple<T1, T2, T3, T4, T5>, TError> Lift<T1, T2, T3, T4, T5, TError>
		(
			Result<T1, TError> r1,
			Result<T2, TError> r2,
			Result<T3, TError> r3,
			Result<T4, TError> r4,
			Result<T5, TError> r5
		)
			=> r1.SelectMany(
				t1 => r2.SelectMany(
					t2 => r3.SelectMany(
						t3 => r4.SelectMany(
							t4 => r5.SelectMany(
								t5 => Success<Tuple<T1, T2, T3, T4, T5>, TError>(
									Tuple.Create(t1, t2, t3, t4, t5)))))));

		public static async Task<Result<Tuple<T1, T2, T3, T4, T5>, TError>> LiftAsync<T1, T2, T3, T4, T5, TError>
		(
			Task<Result<T1, TError>> r1,
			Task<Result<T2, TError>> r2,
			Task<Result<T3, TError>> r3,
			Task<Result<T4, TError>> r4,
			Task<Result<T5, TError>> r5
		)
			=> await (await r1).SelectManyAsync(
				async t1 => await (await r2).SelectManyAsync(
					async t2 => await (await r3).SelectManyAsync(
						async t3 => await (await r4).SelectManyAsync(
							async t4 => (await r5).SelectMany(
								t5 => Success<Tuple<T1, T2, T3, T4, T5>, TError>(Tuple.Create(t1, t2, t3, t4, t5)))))));

		public static Result<Tuple<T1, T2, T3, T4, T5>, TError> LiftLazy<T1, T2, T3, T4, T5, TError>
		(
			Func<Result<T1, TError>> f1,
			Func<Result<T2, TError>> f2,
			Func<Result<T3, TError>> f3,
			Func<Result<T4, TError>> f4,
			Func<Result<T5, TError>> f5
		)
			=> f1().SelectMany(
				t1 => f2().SelectMany(
					t2 => f3().SelectMany(
						t3 => f4().SelectMany(
							t4 => f5().SelectMany(
								t5 => Success<Tuple<T1, T2, T3, T4, T5>, TError>(
									Tuple.Create(t1, t2, t3, t4, t5)))))));

		public static async Task<Result<Tuple<T1, T2, T3, T4, T5>, TError>> LiftLazyAsync<T1, T2, T3, T4, T5, TError>
		(
			Func<Task<Result<T1, TError>>> f1,
			Func<Task<Result<T2, TError>>> f2,
			Func<Task<Result<T3, TError>>> f3,
			Func<Task<Result<T4, TError>>> f4,
			Func<Task<Result<T5, TError>>> f5
		)
			=> await (await f1()).SelectManyAsync(
				async t1 => await (await f2()).SelectManyAsync(
					async t2 => await (await f3()).SelectManyAsync(
						async t3 => await (await f4()).SelectManyAsync(
							async t4 => (await f5()).SelectMany(
								t5 => Success<Tuple<T1, T2, T3, T4, T5>, TError>(
									Tuple.Create(t1, t2, t3, t4, t5))),
							e4 => Task.FromResult(Error<Tuple<T1, T2, T3, T4, T5>, TError>(e4))),
						e3 => Task.FromResult(Error<Tuple<T1, T2, T3, T4, T5>, TError>(e3))),
					e2 => Task.FromResult(Error<Tuple<T1, T2, T3, T4, T5>, TError>(e2))),
				e1 => Task.FromResult(Error<Tuple<T1, T2, T3, T4, T5>, TError>(e1)));

		#endregion
	}
}