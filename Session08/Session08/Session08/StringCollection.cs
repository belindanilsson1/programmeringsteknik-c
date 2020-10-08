using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Session08
{
    class StringCollection : CollectionBase, ICollection 
    {
        public string GetString(int index)
        {
            //Säkrare, returnerar null vid skiljande datatyp
            // return List[index] as string;

            //Snabbare men genererar fel
            return (string)List[index];
        }

        //Möjliggör åtkomst via index, använda listan som en Array.
        public string this[int index]
        {
            get 
            {
                return (string)List[index];
            }
            set
            {
                List[index] = value;
            }
        }

        public void AddString(string input)
        {
            List.Add(input);
        }

        public IEnumerable GetItems()
        {
            //Om listan är null orsakas ett fel under körtid.
            // Med yield break kan man avbryta enumerationen.
            if (List == null)
                yield break;

            foreach (var item in List)
            {
                yield return item;
            }
        }

        
    }
}
