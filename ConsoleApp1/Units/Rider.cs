using System;
using System.Collections.Generic;
using System.Text;

namespace Army
{
    class Rider : Unit
    {


        public Barbarian Barbarian = new Barbarian(15, 234, "Barbarian");
        public Camel Camel = new Camel(0, 11, "Camel", 26);

        public Rider(int damage, int hp, string name) : base(damage, hp, name)
        {  // Уже здесь мы как раз и подсчитываем хп и урон Наездника.
            Hp = Barbarian.Hp + Camel.Hp;
            Damage = Barbarian.Damage + Camel.Damage;
        }

        public override void Display()
        {

            Console.WriteLine("///////////////");
            Console.WriteLine("Name: " + Name);
            Console.WriteLine("Hp: " + Hp);
            Console.WriteLine("NameArmor: " + Barbarian.HideArmor.Name);
            Console.WriteLine("Armor: " + Barbarian.HideArmor.Armor);
            Console.WriteLine("Speed: " + Camel.Speed);
            Console.WriteLine("Damage: " + Damage);
            Console.WriteLine("Наездник: " + Barbarian.Name);
            Console.WriteLine("Животное: " + Camel.Name);

        }
    }
}
