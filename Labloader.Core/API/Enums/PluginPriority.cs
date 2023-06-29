using Labloader.Core.API.Features;

namespace Labloader.Core.API.Enums
{
    /// <summary>
    /// The priority in which to load the <see cref="Plugin{T}"/>
    /// </summary>
    public enum PluginPriority
    {
        /// <summary>
        /// Highest priority
        /// </summary>
        Highest = int.MaxValue-1,
        /// <summary>
        /// High priority
        /// </summary>
        High = 1000,
        /// <summary>
        /// Normal priority
        /// </summary>
        Normal = 0,
        /// <summary>
        /// Low priority
        /// </summary>
        Low = -1000,
        /// <summary>
        /// Lowest priority
        /// </summary>
        Lowest = int.MinValue+1
    }
}