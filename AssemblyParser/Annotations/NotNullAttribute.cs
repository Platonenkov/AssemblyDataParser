using System;

namespace AssemblyDataParser.Annotations
{
    /// <summary>
    /// Indicates that the value of the marked element could never be <c>null</c>
    /// </summary>
    /// <example><code>
    /// [NotNull] public object Foo() {
    ///   return null; // Warning: Possible 'null' assignment
    /// }
    /// </code></example>
    [AttributeUsage(AttributeTargets.Method | AttributeTargets.Property | AttributeTargets.Field | AttributeTargets.Parameter | AttributeTargets.Delegate)]
    internal sealed class NotNullAttribute : Attribute
    {
    }
    /// <summary>
    /// Indicates that the value of the marked element can be <c>null</c>
    /// </summary>
    /// <example><code>
    /// [CanBeNull] public object Foo() {
    ///   return null; // Warning: Possible 'null' assignment
    /// }
    /// </code></example>
    [AttributeUsage(AttributeTargets.Method | AttributeTargets.Property | AttributeTargets.Field | AttributeTargets.Parameter | AttributeTargets.Delegate)]
    internal sealed class CanBeNullAttribute : Attribute
    {
    }
}
