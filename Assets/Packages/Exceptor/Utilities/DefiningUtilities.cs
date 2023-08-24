using System;

namespace Exceptor.Utilities
{
    /// <summary>
    /// All utilities for defining the type of an object.
    /// </summary>
    public static class DefiningUtilities
    {
        /// <summary>
        /// Object is a number?
        /// </summary>
        /// <param name="obj"></param>
        /// <returns>bool</returns>
        public static bool IsNumber(this object obj)
        {
            if (obj == null)
                return false;

            Type type = obj.GetType();

            if (type == null)
                return false;

            TypeCode typeCode = Type.GetTypeCode(type);
            
            switch (typeCode)
            {
                case TypeCode.Byte:
                case TypeCode.SByte:
                case TypeCode.UInt16:
                case TypeCode.UInt32:
                case TypeCode.UInt64:
                case TypeCode.Int16:
                case TypeCode.Int32:
                case TypeCode.Int64:
                case TypeCode.Decimal:
                case TypeCode.Double:
                case TypeCode.Single:
                    return true;
                default:
                    return false;
            }
        }

        /// <summary>
        /// Object is a boolean?
        /// </summary>
        /// <param name="obj"></param>
        /// <returns>bool</returns>
        public static bool IsBoolean(this object obj)
        {
            if (obj == null)
                return false;

            Type type = obj.GetType();

            if (type == null)
                return false;

            TypeCode typeCode = Type.GetTypeCode(type);

            switch (typeCode)
            {
                case TypeCode.Boolean:
                    return true;
                default:
                    return false;
            }
        }
    }
}
