#nullable enable

using System;
using System.Runtime.CompilerServices;

namespace Microsoft.Extensions.AI;

internal static class Throw
{
    /// <summary>
    /// Throws an <see cref="System.ArgumentNullException"/> if the specified argument is <see langword="null"/>.
    /// </summary>
    /// <typeparam name="T">Argument type to be checked for <see langword="null"/>.</typeparam>
    /// <param name="argument">Object to be checked for <see langword="null"/>.</param>
    /// <param name="paramName">The name of the parameter being checked.</param>
    /// <returns>The original value of <paramref name="argument"/>.</returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static T IfNull<T>(T argument, string paramName = "")
    {
        if (argument is null)
        {
            ArgumentNullException(paramName);
        }

        return argument;
    }

    /// <summary>
    /// Throws an <see cref="System.ArgumentOutOfRangeException"/>.
    /// </summary>
    /// <param name="paramName">The name of the parameter that caused the exception.</param>
    /// <param name="message">A message that describes the error.</param>
#if !NET6_0_OR_GREATER
    [MethodImpl(MethodImplOptions.NoInlining)]
#endif
    public static void ArgumentOutOfRangeException(string paramName, string? message)
        => throw new ArgumentOutOfRangeException(paramName, message);

    /// <summary>
    /// Throws an <see cref="System.ArgumentNullException"/>.
    /// </summary>
    /// <param name="paramName">The name of the parameter that caused the exception.</param>
#if !NET6_0_OR_GREATER
    [MethodImpl(MethodImplOptions.NoInlining)]
#endif
    public static void ArgumentNullException(string paramName)
        => throw new ArgumentNullException(paramName);
}