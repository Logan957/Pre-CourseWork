using System;
using System.Collections.Generic;
using System.Text;

namespace Army
{
   
        class Bard : Unit
        {
        public Unit_Armor GlassArmor = new Unit_Armor(30, "Glass Armor");
            public Bard(int damage, int hp, string name) : base(damage, hp, name)

            {
            }
            public override void Display()
            {
                Console.WriteLine("///////////////");
                Console.WriteLine("Name: " + Name);
                Console.WriteLine("Hp: " + Hp);
                Console.WriteLine("NameArmor: " + GlassArmor.Name);
                Console.WriteLine("Armor: " + GlassArmor.Armor);
                Console.WriteLine("Damage: " + Damage);
            }

        }
    
}
