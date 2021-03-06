﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Sandbox
{
    /// <summary>
    /// Reflection Extensions
    /// </summary>
    public static class ReflectiveEnumerator
    {
        static ReflectiveEnumerator() { }

        /// <summary>
        /// Ensure that type T contains a parameterless constructor.
        /// Get An IEnumerable of all subclasses of type T in the executing assembly.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static IEnumerable<T> GetEnumerableOfType<T>() where T : class
        {
            return from t in Assembly.GetExecutingAssembly().GetTypes()
                   where t.GetInterfaces().Contains(typeof(T))
                           && t.GetConstructor(Type.EmptyTypes) != null
                   select Activator.CreateInstance(t) as T;
        }
    }
}
