namespace SoftwareCraft.Functional;

using System;
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

    public static Result<TError> Lift<TError>(
      Result<TError> r1
    , Result<TError> r2)
      => r1.SelectMany(() => r2.Select(() => Success<TError>()));

    public static Task<Result<TError>> LiftAsync<TError>(
      Task<Result<TError>> r1
    , Task<Result<TError>> r2)
      => r1.SelectManyAsync(() => r2.Select(() => Success<TError>()));

    public static Result<TError> LiftLazy<TError>(
      Func<Result<TError>> r1
    , Func<Result<TError>> r2)
      => r1().SelectMany(() => r2().Select(() => Success<TError>()));

    public static Task<Result<TError>> LiftLazyAsync<TError>(
      Func<Task<Result<TError>>> r1
    , Func<Task<Result<TError>>> r2)
      => r1().SelectManyAsync(() => r2().Select(() => Success<TError>()));

    #endregion

    #region Result`2

    public static Result<Tuple<T1, T2>, TError> Lift<T1, T2, TError>(
      Result<T1, TError> r1
    , Result<T2, TError> r2)
      => r1.SelectMany(t1 => r2.Select<Tuple<T1, T2>>(t2 => Tuple.Create(t1, t2)));

    public static Task<Result<Tuple<T1, T2>, TError>> LiftAsync<T1, T2, TError>(
      Task<Result<T1, TError>> r1
    , Task<Result<T2, TError>> r2)
      => r1.SelectManyAsync(t1 => r2.SelectMany(t2 => Success<Tuple<T1, T2>, TError>(Tuple.Create(t1, t2))));

    public static Result<Tuple<T1, T2>, TError> LiftLazy<T1, T2, TError>(
      Func<Result<T1, TError>> f1
    , Func<Result<T2, TError>> f2)
      => f1().SelectMany(t1 => f2().SelectMany(t2 => Success<Tuple<T1, T2>, TError>(Tuple.Create(t1, t2))));

    public static Task<Result<Tuple<T1, T2>, TError>> LiftLazyAsync<T1, T2, TError>(
      Func<Task<Result<T1, TError>>> f1
    , Func<Task<Result<T2, TError>>> f2)
      => f1().SelectManyAsync(t1 => f2().SelectMany(t2 => Success<Tuple<T1, T2>, TError>(Tuple.Create(t1, t2))));

    #endregion

    #endregion

    #region Lift3

    #region Result`1

    public static Result<TError> Lift<TError>(
      Result<TError> r1
    , Result<TError> r2
    , Result<TError> r3)
      => r1.SelectMany(() => r2.SelectMany(() => r3.Select(() => Success<TError>())));

    public static Result<TError> LiftLazy<TError>(
      Func<Result<TError>> r1
    , Func<Result<TError>> r2
    , Func<Result<TError>> r3)
      => r1().SelectMany(() => r2().SelectMany(() => r3().Select(() => Success<TError>())));

    public static Task<Result<TError>> LiftAsync<TError>(
      Task<Result<TError>> r1
    , Task<Result<TError>> r2
    , Task<Result<TError>> r3)
      => r1.SelectManyAsync(() => r2.SelectManyAsync(() => r3.Select(() => Success<TError>())));

    public static Task<Result<TError>> LiftLazyAsync<TError>(
      Func<Task<Result<TError>>> r1
    , Func<Task<Result<TError>>> r2
    , Func<Task<Result<TError>>> r3)
      => r1().SelectManyAsync(() => r2().SelectManyAsync(() => r3().Select(() => Success<TError>())));

    #endregion

    #region Result`2

    public static Result<Tuple<T1, T2, T3>, TError> Lift<T1, T2, T3, TError>(
      Result<T1, TError> r1
    , Result<T2, TError> r2
    , Result<T3, TError> r3)
      => r1.SelectMany(t1 => r2.SelectMany(t2 => r3.Select(t3 => new Tuple<T1, T2, T3>(t1, t2, t3))));

    public static Task<Result<Tuple<T1, T2, T3>, TError>> LiftAsync<T1, T2, T3, TError>(
      Task<Result<T1, TError>> r1
    , Task<Result<T2, TError>> r2
    , Task<Result<T3, TError>> r3)
      => r1.SelectManyAsync(t1 => r2.SelectManyAsync(t2 => r3.Select(t3 => new Tuple<T1, T2, T3>(t1, t2, t3))));

    public static Result<Tuple<T1, T2, T3>, TError> LiftLazy<T1, T2, T3, TError>(
      Func<Result<T1, TError>> f1
    , Func<Result<T2, TError>> f2
    , Func<Result<T3, TError>> f3)
      => f1().SelectMany(t1 => f2().SelectMany(t2 => f3().Select(t3 => new Tuple<T1, T2, T3>(t1, t2, t3))));

    public static Task<Result<Tuple<T1, T2, T3>, TError>> LiftLazyAsync<T1, T2, T3, TError>(
      Func<Task<Result<T1, TError>>> f1
    , Func<Task<Result<T2, TError>>> f2
    , Func<Task<Result<T3, TError>>> f3)
      => f1().SelectManyAsync(t1 => f2().SelectManyAsync(t2 => f3().SelectAsync(t3 => Task.FromResult(new Tuple<T1, T2, T3>(t1, t2, t3)))));

    #endregion

    #endregion

    #region Lift4

    #region Result`1

    public static Result<TError> Lift<TError>(
      Result<TError> r1
    , Result<TError> r2
    , Result<TError> r3
    , Result<TError> r4)
      => r1.SelectMany(() => r2.SelectMany(() => r3.SelectMany(() => r4.Select(() => Success<TError>()))));

    public static Task<Result<TError>> LiftAsync<TError>(
      Task<Result<TError>> r1
    , Task<Result<TError>> r2
    , Task<Result<TError>> r3
    , Task<Result<TError>> r4)
      => r1.SelectManyAsync(() => r2.SelectManyAsync(() => r3.SelectManyAsync(() => r4).Select(() => Success<TError>())));

    public static Result<TError> LiftLazy<TError>(
      Func<Result<TError>> r1
    , Func<Result<TError>> r2
    , Func<Result<TError>> r3
    , Func<Result<TError>> r4)
      => r1().SelectMany(() => r2().SelectMany(() => r3().SelectMany(() => r4().Select(() => Success<TError>()))));

    public static Task<Result<TError>> LiftLazyAsync<TError>(
      Func<Task<Result<TError>>> r1
    , Func<Task<Result<TError>>> r2
    , Func<Task<Result<TError>>> r3
    , Func<Task<Result<TError>>> r4)
      => r1().SelectManyAsync(() => r2().SelectManyAsync(() => r3().SelectManyAsync(() => r4().Select(() => Success<TError>()))));

    #endregion

    #region Result`2

    public static Result<Tuple<T1, T2, T3, T4>, TError> Lift<T1, T2, T3, T4, TError>(
      Result<T1, TError> r1
    , Result<T2, TError> r2
    , Result<T3, TError> r3
    , Result<T4, TError> r4)
      => r1.SelectMany(t1 => r2.SelectMany(t2 => r3.SelectMany(t3 => r4.Select(t4 => new Tuple<T1, T2, T3, T4>(t1, t2, t3, t4)))));

    public static Task<Result<Tuple<T1, T2, T3, T4>, TError>> LiftAsync<T1, T2, T3, T4, TError>(
      Task<Result<T1, TError>> r1
    , Task<Result<T2, TError>> r2
    , Task<Result<T3, TError>> r3
    , Task<Result<T4, TError>> r4)
      => r1.SelectManyAsync(t1 => r2.SelectManyAsync(t2 => r3.SelectManyAsync(t3 => r4.Select(t4 => new Tuple<T1, T2, T3, T4>(t1, t2, t3, t4)))));

    public static Result<Tuple<T1, T2, T3, T4>, TError> LiftLazy<T1, T2, T3, T4, TError>(
      Func<Result<T1, TError>> f1
    , Func<Result<T2, TError>> f2
    , Func<Result<T3, TError>> f3
    , Func<Result<T4, TError>> f4)
      => f1().SelectMany(t1 => f2().SelectMany(t2 => f3().SelectMany(t3 => f4().Select(t4 => new Tuple<T1, T2, T3, T4>(t1, t2, t3, t4)))));

    public static Task<Result<Tuple<T1, T2, T3, T4>, TError>> LiftLazyAsync<T1, T2, T3, T4, TError>(
      Func<Task<Result<T1, TError>>> f1
    , Func<Task<Result<T2, TError>>> f2
    , Func<Task<Result<T3, TError>>> f3
    , Func<Task<Result<T4, TError>>> f4)
      => f1().SelectManyAsync(t1 => f2()
                               .SelectManyAsync(t2 => f3().SelectManyAsync(t3 => f4().Select(t4 => new Tuple<T1, T2, T3, T4>(t1, t2, t3, t4)))));

    #endregion

    #endregion

    #region Lift5

    #region Result`1

    public static Result<TError> Lift<TError>(
      Result<TError> r1
    , Result<TError> r2
    , Result<TError> r3
    , Result<TError> r4
    , Result<TError> r5)
      => r1.SelectMany(() => r2.SelectMany(() => r3.SelectMany(() => r4.SelectMany(() => r5.Select(() => Success<TError>())))));

    public static Task<Result<TError>> LiftAsync<TError>(
      Task<Result<TError>> r1
    , Task<Result<TError>> r2
    , Task<Result<TError>> r3
    , Task<Result<TError>> r4
    , Task<Result<TError>> r5)
      => r1.SelectManyAsync(() => r2.SelectManyAsync(() => r3.SelectManyAsync(() => r4.SelectManyAsync(() => r5.Select(() => Success<TError>())))));

    public static Result<TError> LiftLazy<TError>(
      Func<Result<TError>> r1
    , Func<Result<TError>> r2
    , Func<Result<TError>> r3
    , Func<Result<TError>> r4
    , Func<Result<TError>> r5)
      => r1().SelectMany(() => r2().SelectMany(() => r3().SelectMany(() => r4().SelectMany(() => r5().Select(() => Success<TError>())))));

    public static Task<Result<TError>> LiftLazyAsync<TError>(
      Func<Task<Result<TError>>> r1
    , Func<Task<Result<TError>>> r2
    , Func<Task<Result<TError>>> r3
    , Func<Task<Result<TError>>> r4
    , Func<Task<Result<TError>>> r5)
      => r1().SelectManyAsync(() => r2().SelectManyAsync(() => r3().SelectManyAsync(() => r4()
                                                                                     .SelectManyAsync(() => r5().Select(() => Success<TError>())))));

    #endregion

    #region Result`2

    public static Result<Tuple<T1, T2, T3, T4, T5>, TError> Lift<T1, T2, T3, T4, T5, TError>(
      Result<T1, TError> r1
    , Result<T2, TError> r2
    , Result<T3, TError> r3
    , Result<T4, TError> r4
    , Result<T5, TError> r5)
      => r1.SelectMany(t1 =>
                         r2.SelectMany(t2 =>
                                         r3.SelectMany(t3 =>
                                                         r4.SelectMany(t4 => r5.Select(t5 => new Tuple<T1, T2, T3, T4, T5>(t1, t2, t3, t4, t5))))));

    public static Task<Result<Tuple<T1, T2, T3, T4, T5>, TError>> LiftAsync<T1, T2, T3, T4, T5, TError>(
      Task<Result<T1, TError>> r1
    , Task<Result<T2, TError>> r2
    , Task<Result<T3, TError>> r3
    , Task<Result<T4, TError>> r4
    , Task<Result<T5, TError>> r5)
      => r1.SelectManyAsync(t1 => r2.SelectManyAsync(t2 =>
                                                       r3.SelectManyAsync(t3 =>
                                                                            r4.SelectManyAsync(t4 => r5.Select(t5 => new Tuple<T1, T2, T3, T4, T5>(
                                                                                                 t1, t2, t3, t4, t5))))));

    public static Result<Tuple<T1, T2, T3, T4, T5>, TError> LiftLazy<T1, T2, T3, T4, T5, TError>(
      Func<Result<T1, TError>> f1
    , Func<Result<T2, TError>> f2
    , Func<Result<T3, TError>> f3
    , Func<Result<T4, TError>> f4
    , Func<Result<T5, TError>> f5)
      => f1().SelectMany(t1 => f2()
                          .SelectMany(t2 => f3()
                                       .SelectMany(t3 => f4()
                                                    .SelectMany(t4 => f5().Select(t5 => new Tuple<T1, T2, T3, T4, T5>(t1, t2, t3, t4, t5))))));

    public static Task<Result<Tuple<T1, T2, T3, T4, T5>, TError>> LiftLazyAsync<T1, T2, T3, T4, T5, TError>(
      Func<Task<Result<T1, TError>>> f1
    , Func<Task<Result<T2, TError>>> f2
    , Func<Task<Result<T3, TError>>> f3
    , Func<Task<Result<T4, TError>>> f4
    , Func<Task<Result<T5, TError>>> f5)
      => f1().SelectManyAsync(t1 => f2().SelectManyAsync(t2 => f3()
                                                          .SelectManyAsync(t3 => f4()
                                                                            .SelectManyAsync(t4 => f5()
                                                                                              .Select(t5 => new Tuple<T1, T2, T3, T4, T5>(
                                                                                                 t1, t2, t3, t4, t5))))));

    #endregion

    #endregion
  }
}