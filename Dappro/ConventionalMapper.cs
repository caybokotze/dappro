using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Dappro
{
    public class ConventionalMapper<T>
    {
        public string[] GetProperties()
        {
            Type type = typeof(T);
            List<string> propertyNames = new List<string>();

            foreach (var prop in type.GetProperties())
            {
                propertyNames.Add(prop.Name);
            }
            
            return null;
        }
    }
}