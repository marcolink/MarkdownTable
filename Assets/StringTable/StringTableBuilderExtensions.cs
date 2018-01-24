using System;
using System.Collections.Generic;
using System.Linq;

namespace StringTable
{
    public static class StringTableBuilderExtensions
    {
        public static string ToMardownString<T>(this IEnumerable<T> rows)
        {
            var builder = new StringTableBuilder();
            var properties = typeof(T).GetProperties();//.Where(p => IsValidType(p.ReflectedType));
            var fields = typeof(T).GetFields();//.Where(p => IsValidType(p.FieldType));

            builder.WithHeader(properties.Select(p => p.Name).Concat(fields.Select(f => f.Name)).ToArray());
            
            foreach (var row in rows)
            {
                builder.WithRow(properties.Select(p => p.GetValue(row, null))
                    .Concat(fields.Select(f => f.GetValue(row))).ToArray());
            }

            return builder.ToString();
        }

        private static bool IsValidType(Type type)
        {
            return true;
        }
    }
}