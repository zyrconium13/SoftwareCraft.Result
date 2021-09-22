using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using SoftwareCraft.Functional;

namespace ConsoleApp1
{
    public static class Program2
    {
        private static async Task Main()
        {
            var success1 = Result.Success<int, string>(13);
            var success2 = Result.Success<double, string>(1.23);

            var error1 = Result.Error<double, string>("oops");
            var error2 = Result.Error<int, string>("fuck");

            var r1 = LiftExtensions.Lift(success1, success2);
            var r2 = LiftExtensions.Lift(success1, error2);
            var r3 = LiftExtensions.Lift(error1, success2);
            var r4 = LiftExtensions.Lift(error1, error2);

            Func<Result<int, string>> funcSuccess1 = () => success1;
            Func<Result<double, string>> funcSuccess2 = () => success2;
            Func<Result<double, string>> funcError1 = () => error1;
            Func<Result<int, string>> funcError2 = () => error2;

            var r11 = LiftExtensions.LiftLazy(funcSuccess1, funcSuccess2);
            var r12 = LiftExtensions.LiftLazy(funcSuccess1, funcError2);
            var r13 = LiftExtensions.LiftLazy(funcError1, funcSuccess2);
            var r14 = LiftExtensions.LiftLazy(funcError1, funcError2);

            Func<Task<Result<int, string>>> taskSuccess1 = () => Task.FromResult(success1);
            Func<Task<Result<double, string>>> taskSuccess2 = () => Task.FromResult(success2);
            Func<Task<Result<double, string>>> taskError1 = () => Task.FromResult(error1);
            Func<Task<Result<int, string>>> taskError2 = () => Task.FromResult(error2);

            var r21 = await LiftExtensions.LiftLazyAsync(taskSuccess1, taskSuccess2);
            var r22 = await LiftExtensions.LiftLazyAsync(taskSuccess1, taskError2);
            var r23 = await LiftExtensions.LiftLazyAsync(taskError1, taskSuccess2);
            var r24 = await LiftExtensions.LiftLazyAsync(taskError1, taskError2);
        }
    }
}