﻿using System;
using System.ComponentModel;
using System.Globalization;
using System.Linq;

namespace Surging.Core.CPlatform.Utilities
{
    public static class ObjectExtensions
    {
        public static T As<T>(this object obj)
            where T : class
        {
            return (T)obj;
        }

        public static T To<T>(this object obj)
            where T : struct
        {
            if (typeof(T) == typeof(Guid))
            {
                return (T)TypeDescriptor.GetConverter(typeof(T)).ConvertFromInvariantString(obj.ToString());
            }

            return (T)Convert.ChangeType(obj, typeof(T), CultureInfo.InvariantCulture);
        }

        public static T ConventTo<T>(this object obj)
        {
            if (typeof(T).IsValueType)
            {
                if (typeof(T) == typeof(Guid))
                {
                    return (T)TypeDescriptor.GetConverter(typeof(T)).ConvertFromInvariantString(obj.ToString());
                }

                return (T)Convert.ChangeType(obj, typeof(T), CultureInfo.InvariantCulture);
            }
            return (T)obj;
        }

        public static bool IsIn<T>(this T item, params T[] list)
        {
            return list.Contains(item);
        }
    }
}