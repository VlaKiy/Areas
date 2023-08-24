using System; 
using UnityEngine;

namespace Exceptor.Utilities
{
    /// <summary>
    /// All utilities for debugging messages.
    /// </summary>
    public static class DebugUtilities
    {
        /// <summary>
        /// Messaging debug with DebugMode.
        /// </summary>
        /// <param name="message"></param>
        /// <param name="mode"></param>
        public static void DebugMessage(string message, DebugMode mode = DebugMode.Log)
        {
            DebugWithMode(message, mode);
        }

        /// <summary>
        /// Messaging debug DebugMode if condition is true.
        /// </summary>
        /// <param name="condition"></param>
        /// <param name="message"></param>
        public static void DebugIfValid(this bool condition, string message, DebugMode debugMode = DebugMode.Log)
        {
            if (condition)
                DebugWithMode(message, debugMode);
        }

        /// <summary>
        /// Messaging debug with DebugMode if condition is false.
        /// </summary>
        /// <param name="condition"></param>
        /// <param name="message"></param>
        public static void DebugIfInvalid(this bool condition, string message, DebugMode debugMode = DebugMode.Log)
        {
            if (!condition)
                DebugWithMode(message, debugMode);
        }

        /// <summary>
        /// Messaging debug with DebugMode.
        /// </summary>
        /// <param name="message"></param>
        /// <param name="mode"></param>
        private static void DebugWithMode(string message, DebugMode mode = DebugMode.Log)
        {
            if (message == null)
                throw new ArgumentNullException("message", "Message is null");

            switch (mode)
            {
                case DebugMode.Log:
                    Debug.Log(message);
                    break;
                case DebugMode.Warning:
                    Debug.LogWarning(message);
                    break;
                case DebugMode.Error:
                    Debug.LogError(message);
                    break;
                default:
                    break;
            }
        }
    }
}
