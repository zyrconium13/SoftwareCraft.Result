namespace SoftwareCraft.Functional
{
	using System;
	using System.Collections.Generic;
	using System.Linq;

	public static class Extensions
	{
		public static Result<T, string> AsSuccess<T>(this T      @this) => Result.Success<T, string>(@this);
		public static Result<T, string> AsError<T>(this   string @this) => Result.Error<T, string>(@this);

		public static Result<string> AsSuccess(this object _)     => Result.Success<string>();
		public static Result<string> AsError(this   string @this) => Result.Error(@this);
	}
}