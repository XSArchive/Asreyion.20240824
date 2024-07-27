namespace Asreyion.Framework.Enumerations;

/// <summary>
/// Defines the priority levels for code execution.
/// </summary>
/// <remarks>This enumeration uses bitwise flags to allow for combination of multiple priorities.</remarks>
[Flags]
public enum Priority : byte
{
    /// <summary>
    /// Represents the priority level for code that should be executed as soon as possible.
    /// </summary>
    /// <remarks>This is reserved for code like the ASP.NET core code, or other code that MUST be run first. Please do not use it for anything else.</remarks>
    Root = 0,

    /// <summary>
    /// Represents the highest priority level for critical tasks.
    /// </summary>
    Core = 1 << 0,

    /// <summary>
    /// Represents a high priority level, used for important tasks that need immediate attention.
    /// </summary>
    High = 1 << 1,

    /// <summary>
    /// Represents a priority level above normal but below high. Suitable for moderately important tasks.
    /// </summary>
    AboveNormal = 1 << 2,

    /// <summary>
    /// Represents the standard priority level. Used for tasks that are neither high nor low priority.
    /// </summary>
    Normal = 1 << 3,

    /// <summary>
    /// Represents a priority level below normal. Suitable for tasks that are less urgent.
    /// </summary>
    BelowNormal = 1 << 4,

    /// <summary>
    /// Represents the lowest priority level, used for tasks that are the least urgent.
    /// </summary>
    Low = 1 << 5,

    /// <summary>
    /// Represents all possible priority levels combined. Includes Core, High, AboveNormal, Normal, BelowNormal, and Low.
    /// </summary>
    All = Core | High | AboveNormal | Normal | BelowNormal | Low
}
