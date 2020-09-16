using System;
using System.Collections.Generic;
using System.Text;

namespace Army
{
    abstract class  Unit
    {
        public string Name { get; private set; }
        public int Damage { get; set; }
        public int Hp { get; set; }

        public Unit(int damage, int hp, string name)
        {
            Damage = damage;
            Hp = hp;
            Name = name;
        }
        // При нанесении урона, метод будет отнимать хп у юнита.
        public void Hpminus(int realdamage)
        {
            Hp -= realdamage;
        }
        // Абстрактный метод, который будет реализовываться у всех остальных дочерних классов по-разному.
        public abstract void Display();


    }
}
