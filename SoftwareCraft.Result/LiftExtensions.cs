using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SoftwareCraft.Functional
{
    public static class LiftExtensions
    {
        #region Lift2

        public static Result<Tuple<T1, T2>, TError> Lift<T1, T2, TError>
        (
            Result<T1, TError> r1,
            Result<T2, TError> r2
        )
            => r1.SelectMany(
                t1 => r2.SelectMany(
                    t2 => Result.Success<Tuple<T1, T2>, TError>(Tuple.Create(t1, t2))));

        public static Result<Tuple<T1, T2>, TError> LiftLazy<T1, T2, TError>
        (
            Func<Result<T1, TError>> f1,
            Func<Result<T2, TError>> f2
        )
            => f1().SelectMany(
                t1 => f2().SelectMany(
                    t2 => Result.Success<Tuple<T1, T2>, TError>(Tuple.Create(t1, t2))));

        public static async Task<Result<Tuple<T1, T2>, TError>> LiftLazyAsync<T1, T2, TError>
        (
            Func<Task<Result<T1, TError>>> f1,
            Func<Task<Result<T2, TError>>> f2
        )
            => await (await f1()).SelectManyAsync(
                async t1 => (await f2()).SelectMany(
                    t2 => Result.Success<Tuple<T1, T2>, TError>(Tuple.Create(t1, t2))),
                e1 => Task.FromResult(Result.Error<Tuple<T1, T2>, TError>(e1)));

        #endregion

        #region Lift3

        public static Result<Tuple<T1, T2, T3>, TError> Lift<T1, T2, T3, TError>
        (
            Result<T1, TError> r1,
            Result<T2, TError> r2,
            Result<T3, TError> r3
        )
            => r1.SelectMany(
                t1 => r2.SelectMany(
                    t2 => r3.SelectMany(
                        t3 => Result.Success<Tuple<T1, T2, T3>, TError>(Tuple.Create(t1, t2, t3)))));

        public static Result<Tuple<T1, T2, T3>, TError> LiftLazy<T1, T2, T3, TError>
        (
            Func<Result<T1, TError>> f1,
            Func<Result<T2, TError>> f2,
            Func<Result<T3, TError>> f3
        )
            => f1().SelectMany(
                t1 => f2().SelectMany(
                    t2 => f3().SelectMany(
                        t3 => Result.Success<Tuple<T1, T2, T3>, TError>(Tuple.Create(t1, t2, t3)))));

        public static async Task<Result<Tuple<T1, T2, T3>, TError>> LiftLazyAsync<T1, T2, T3, TError>
        (
            Func<Task<Result<T1, TError>>> f1,
            Func<Task<Result<T2, TError>>> f2,
            Func<Task<Result<T3, TError>>> f3
        )
            => await (await f1()).SelectManyAsync(
                async t1 => await (await f2()).SelectManyAsync(
                    async t2 => (await f3()).SelectMany(
                        t3 => Result.Success<Tuple<T1, T2, T3>, TError>(Tuple.Create(t1, t2, t3))),
                    e2 => Task.FromResult(Result.Error<Tuple<T1, T2, T3>, TError>(e2))),
                e1 => Task.FromResult(Result.Error<Tuple<T1, T2, T3>, TError>(e1)));

        #endregion

        #region Lift4

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
                            t4 => Result.Success<Tuple<T1, T2, T3, T4>, TError>(Tuple.Create(t1, t2, t3, t4))))));

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
                            t4 => Result.Success<Tuple<T1, T2, T3, T4>, TError>(Tuple.Create(t1, t2, t3, t4))))));

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
                            t4 => Result.Success<Tuple<T1, T2, T3, T4>, TError>(Tuple.Create(t1, t2, t3, t4))),
                        e3 => Task.FromResult(Result.Error<Tuple<T1, T2, T3, T4>, TError>(e3))),
                    e2 => Task.FromResult(Result.Error<Tuple<T1, T2, T3, T4>, TError>(e2))),
                e1 => Task.FromResult(Result.Error<Tuple<T1, T2, T3, T4>, TError>(e1)));

        #endregion

        #region Lift5

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
                                t5 => Result.Success<Tuple<T1, T2, T3, T4, T5>, TError>(
                                    Tuple.Create(t1, t2, t3, t4, t5)))))));

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
                                t5 => Result.Success<Tuple<T1, T2, T3, T4, T5>, TError>(
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
                                t5 => Result.Success<Tuple<T1, T2, T3, T4, T5>, TError>(
                                    Tuple.Create(t1, t2, t3, t4, t5))),
                            e4 => Task.FromResult(Result.Error<Tuple<T1, T2, T3, T4, T5>, TError>(e4))),
                        e3 => Task.FromResult(Result.Error<Tuple<T1, T2, T3, T4, T5>, TError>(e3))),
                    e2 => Task.FromResult(Result.Error<Tuple<T1, T2, T3, T4, T5>, TError>(e2))),
                e1 => Task.FromResult(Result.Error<Tuple<T1, T2, T3, T4, T5>, TError>(e1)));

        #endregion
    }

    public static class Extensions
    {
	    public static Result<T, string> AsSuccess<T>(this T @this) => Result.Success<T, string>(@this);

	    public static Result<T, string> AsError<T>(this string @this) => Result.Error<T, string>(@this);
    }
}