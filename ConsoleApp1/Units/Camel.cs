using System;
using System.Collections.Generic;
using System.Text;

namespace Army
{
    class Camel : Unit
    {
        public int Speed { get; private set; }
        public Camel(int damage, int hp, string name, int speed) : base(damage, hp, name)

        {
            Speed = speed;
        }
        public override void Display()
        {
            Console.WriteLine("///////////////");
            Console.WriteLine("Name: " + Name);
            Console.WriteLine("Hp: " + Hp);
            Console.WriteLine("Speed: " + Speed);
            Console.WriteLine("Damage: " + Damage);
        }

    }
}
