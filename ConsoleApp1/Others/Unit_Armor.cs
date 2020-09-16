using System;
using System.Collections.Generic;
using System.Text;

namespace Army
{
   
        class Unit_Armor
        {
            public int Armor { get; private set; }
            public string Name { get; private set; }
            public Unit_Armor(int armor, string name)
            {
                Armor = armor;
                Name = name;
            }

        }
    
}
