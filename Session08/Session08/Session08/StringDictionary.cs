using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Session08
{
    class StringDictionary : DictionaryBase, IDictionary
    {
        public void AddString(string key, string value)
        {
            Dictionary.Add(key, value);
        }

        public bool ContainsKey(string key)
        {
            return Dictionary.Contains(key);
        }

        public string GetValue(string key)
        {
            return (string)Dictionary[key];
        }
    }
}
