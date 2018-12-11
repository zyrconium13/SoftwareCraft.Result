﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace SoftwareCraft.Functional
{
	public abstract class Result<TError>
	{
		public virtual Result<TError> OnSuccess(Action onSuccess) => this;

		public virtual Result<TError> OnError(Action<TError> onError) => this;

		public virtual Result<TError> OnBoth(Action onBoth)
		{
			onBoth();

			return this;
		}

		private protected static void Validate<T>(T value)
		{
			var isNotValueType = !typeof(T).IsValueType;
			var isNullableValueType = Nullable.GetUnderlyingType(typeof(T)) != null;
			var hasDefaultValue = EqualityComparer<T>.Default.Equals(value, default);

			if ((isNotValueType || isNullableValueType) && hasDefaultValue)
				throw new InvalidOperationException();
		}
	}
}