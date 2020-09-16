using System;
using System.Collections.Generic;
using System.Text;

namespace Army
{
    class Wizard : Unit
    {
        public Unit_Armor GlassArmor = new Unit_Armor(30, "Glass Armor");
        public Wizard(int damage, int hp, string name) : base(damage, hp, name)

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
