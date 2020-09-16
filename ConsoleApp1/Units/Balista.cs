using System;
using System.Collections.Generic;
using System.Text;

namespace Army
{
    class Balista : Unit
    {
        static Random rnd = new Random();
        public Balista_Ammo bul = new Balista_Ammo(rnd.Next(0, 4));
        public Balista(int damage, int hp, string name) : base(damage, hp, name)

        { // Проверка, которая сгенерирует Балисту без урона, если её боеприпас будет равен 0.
            if (bul.Ammo == 0) { Damage = 0; }
        }
        public override void Display()
        {
            Console.WriteLine("///////////////");
            Console.WriteLine("Name: " + Name);
            Console.WriteLine("Hp: " + Hp);
            Console.WriteLine("Damage: " + Damage);
            Console.WriteLine("Ammo:" + bul.Ammo);
        }


    }
}
