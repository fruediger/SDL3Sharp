﻿using Sdl3Sharp.SourceGeneration;
using System.Runtime.CompilerServices;

namespace Sdl3Sharp.Internal.NativeImportConditions;

internal sealed class Not<TCondition> : INativeImportCondition
	where TCondition : INativeImportCondition
{
	private Not() { }

	[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
	public static bool Evaluate() => !TCondition.Evaluate();
}
