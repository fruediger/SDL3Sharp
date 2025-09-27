﻿using Sdl3Sharp.Internal;
using Sdl3Sharp.Windowing;
using System;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace Sdl3Sharp.Events;

partial struct Event
{
	[FieldOffset(0)] internal WindowEvent Window;
	
	/// <summary>
	/// Creates a new <see cref="Event"/> from a <see cref="WindowEvent"/>
	/// </summary>
	/// <param name="event">The <see cref="WindowEvent"/> to store into the newly created <see cref="Event"/></param>
	[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
#pragma warning disable IDE0034 // Leave it for explicitness sake
	public Event(in WindowEvent @event) : this(default(IUnsafeConstructorDispatch?)) => Window = @event;
#pragma warning restore IDE0034
}

/// <summary>
/// Represents an event that occurs when a <see cref="Window"/> changes its state
/// </summary>
[StructLayout(LayoutKind.Sequential)]
public struct WindowEvent : ICommonEvent<WindowEvent>, IFormattable, ISpanFormattable
{
	[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
	private static bool Accepts(EventType type) => type >= EventType.Window.Shown && type <= EventType.Window.HdrStateChanged;

	[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
	static bool ICommonEvent<WindowEvent>.Accepts(EventType type) => Accepts(type);

	[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
	static ref WindowEvent ICommonEvent<WindowEvent>.GetReference(ref Event @event) => ref @event.Window;

	private CommonEvent<WindowEvent> mCommon;
	private uint mWindowID;
	private int mData1;
	private int mData2;

	/// <inheritdoc/>
	public EventType<WindowEvent> Type
	{
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)] readonly get => mCommon.Type;
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)] set => mCommon.Type = value;
	}

	/// <inheritdoc/>
	public ulong Timestamp
	{
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)] readonly get => mCommon.Timestamp;
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)] set => mCommon.Timestamp = value;
	}

	/// <summary>
	/// Gets or sets the window ID of the <see cref="Window"/> which changes it's state
	/// </summary>
	/// <value>
	/// The window ID of the <see cref="Window"/> which changes it's state
	/// </value>
	public uint WindowId
	{
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)] readonly get => mWindowID;
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)] set => mWindowID = value;
	}

	/// <summary>
	/// Gets or sets the first event dependent data slot
	/// </summary>
	/// <value>
	/// The first event dependent data slot
	/// </value>
	/// <remarks>
	/// <para>
	/// The value of this property reflects different data semantics dependent on the <see cref="Type"/>:
	/// <list type="bullet">
	///		<item>
	///			<term>
	///				<see cref="EventType.Window.Exposed"/>
	///			</term>
	///			<description>
	///				<c>1</c> for "live-resize expose" events; otherwise, <c>0</c>
	///			</description>
	///		</item>
	///		<item>
	///			<term>
	///				<see cref="EventType.Window.Moved"/>
	///			</term>
	///			<description>
	///				The new horizontal coordinate of the <see cref="Window"/> after it has been moved
	///			</description>
	///		</item>
	///		<item>
	///			<term>
	///				<see cref="EventType.Window.Resized"/>
	///			</term>
	///			<description>
	///				The new width of the <see cref="Window"/> after it has been resized
	///			</description>
	///		</item>
	///		<item>
	///			<term>
	///				<see cref="EventType.Window.Resized"/>
	///			</term>
	///			<description>
	///				The new horizontal pixel size of the <see cref="Window"/> after it has been changed
	///			</description>
	///		</item>
	/// </list>
	/// </para>
	/// </remarks>
	public int Data1
	{
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)] readonly get => mData1;
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)] set => mData1 = value;
	}

	/// <summary>
	/// Gets or sets the second event dependent data slot
	/// </summary>
	/// <value>
	/// The second event dependent data slot
	/// </value>
	/// <remarks>
	/// <para>
	/// The value of this property reflects different data semantics dependent on the <see cref="Type"/>:
	/// <list type="bullet">
	///		<item>
	///			<term>
	///				<see cref="EventType.Window.Moved"/>
	///			</term>
	///			<description>
	///				The new vertical coordinate of the <see cref="Window"/> after it has been moved
	///			</description>
	///		</item>
	///		<item>
	///			<term>
	///				<see cref="EventType.Window.Resized"/>
	///			</term>
	///			<description>
	///				The new height of the <see cref="Window"/> after it has been resized
	///			</description>
	///		</item>
	///		<item>
	///			<term>
	///				<see cref="EventType.Window.Resized"/>
	///			</term>
	///			<description>
	///				The new vertical pixel size of the <see cref="Window"/> after it has been changed
	///			</description>
	///		</item>
	/// </list>
	/// </para>
	/// </remarks>
	public int Data2
	{
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)] readonly get => mData2;
		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)] set => mData2 = value;
	}

	/// <inheritdoc/>
	public readonly override string ToString() => ToString(format: default, formatProvider: default);

	/// <inheritdoc cref="IFormattable.ToString(string?, IFormatProvider?)"/>
	public readonly string ToString(IFormatProvider? formatProvider) => ToString(format: default, formatProvider);

	/// <inheritdoc cref="IFormattable.ToString(string?, IFormatProvider?)"/>
	public readonly string ToString(string? format) => ToString(format, formatProvider: default);

	/// <inheritdoc/>
	public readonly string ToString(string? format, IFormatProvider? formatProvider)
		=> $"{{ {ICommonEvent.PartialToString(in this, format, formatProvider)}, {
			nameof(WindowId)}: {WindowId.ToString(format, formatProvider)}, {
			nameof(Data1)}: {Data1.ToString(format, formatProvider)}, {
			nameof(Data2)}: {Data2.ToString(format, formatProvider)} }}";

	/// <inheritdoc/>
	public readonly bool TryFormat(Span<char> destination, out int charsWritten, ReadOnlySpan<char> format = default, IFormatProvider? provider = default)
	{
		charsWritten = 0;

		return SpanFormat.TryWrite("{ ", ref destination, ref charsWritten)
			&& ICommonEvent.TryPartialFormat(in this, ref destination, ref charsWritten, format, provider)
			&& SpanFormat.TryWrite($", {nameof(WindowId)}: ", ref destination, ref charsWritten)
			&& SpanFormat.TryWrite(WindowId, ref destination, ref charsWritten, format, provider)
			&& SpanFormat.TryWrite($", {nameof(Data1)}: ", ref destination, ref charsWritten)
			&& SpanFormat.TryWrite(Data1, ref destination, ref charsWritten, format, provider)
			&& SpanFormat.TryWrite($", {nameof(Data2)}: ", ref destination, ref charsWritten)
			&& SpanFormat.TryWrite(Data2, ref destination, ref charsWritten, format, provider)
			&& SpanFormat.TryWrite(" }", ref destination, ref charsWritten);
	}

	/// <inheritdoc/>
	[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
	public static implicit operator Event(in WindowEvent @event) => new(in @event);

	/// <remarks>
	/// <para>
	/// The <see cref="Event.Type"/> of the given <paramref name="event"/> must be be in the range from <see cref="EventType.Window.Shown"/> (inclusive) through <see cref="EventType.Window.HdrStateChanged"/> (inclusive).
	/// Otherwise, it will lead the method to throw an <see cref="ArgumentException"/>!
	/// </para>
	/// </remarks>
	/// <exception cref="ArgumentException">
	/// The <see cref="Event.Type"/> of the given <paramref name="event"/> was not in the range from <see cref="EventType.Window.Shown"/> (inclusive) through <see cref="EventType.Window.HdrStateChanged"/> (inclusive)
	/// </exception>
	/// <inheritdoc/>
	public static explicit operator WindowEvent(in Event @event)
	{
		if (!Accepts(@event.Type))
		{
			failEventArgumentIsNotWindowEvent();
		}

		return @event.Window;

		[DoesNotReturn]
		static void failEventArgumentIsNotWindowEvent() => throw new ArgumentException($"{nameof(@event)} must be a {nameof(WindowEvent)} by {nameof(Type)}", paramName: nameof(@event));
	}
}
