using System;
using System.Collections.Generic;
using System.Text;

namespace Army
{
    class Barbarian : Unit
    {
        public Unit_Armor HideArmor = new Unit_Armor(10, "Hide Armor");
        public Barbarian(int damage, int hp, string name) : base(damage, hp, name)
        {
        }
        public override void Display()
        {
            Console.WriteLine("///////////////");
            Console.WriteLine("Name: " + Name);
            Console.WriteLine("Hp: " + Hp);
            Console.WriteLine("NameArmor: " + HideArmor.Name);
            Console.WriteLine("Armor: " + HideArmor.Armor);
            Console.WriteLine("Damage: " + Damage);
        }

    }
}
