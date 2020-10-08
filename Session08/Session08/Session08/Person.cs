using System;
using System.Collections.Generic;
using System.Text;

namespace Session08
{
    class Person
    {
        public string Name { get; set; }

        public Person Clone()
        {
            return (Person)MemberwiseClone();
        }
    }
}
