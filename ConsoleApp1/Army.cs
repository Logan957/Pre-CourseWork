using Army;
using System;
using System.Collections.Generic;

namespace ConsoleApp1
// Задание  7
// 1.Создать виртуальную армию согласно условию.Каждый боец армии должен уметь рассказать о себе.
// Армия должна уметь выводить статистику о себе: Общий урон, Общая защита, Общие здоровье, Общая численность армии.
// Параметры армии:
// Мех: ballista Здор = 478 боеп= Bolt(Energetic Power Wall, урон = 17)
// Сол: Bard Здор = 104 урон= 5 броня= Glass Armor (доп.защита= 30)
// Сол: Barbarian Здор = 234 урон=15 броня=Hide Armor(доп.защита= 10)
// Сол: Wizard Здор = 51 урон=7 броня=Glass Armor(доп.защита= 30)
// Жив: Camel Здор = 11 урон=0 скор=26
// Жив: Horse Здор = 15 урон=0 скор=26
// Жив: Tiger Здор = 35 урон=20 скор=40
// Вса: 1. Наез=Barbarian Жив = Camel
//  Броня и патроны реализованы классами
// 2.Реализовать метод нанесения армии урона, по следующим правилам:
// 1)Урон наноситься поочередно каждому юниту.
// 2)Из урона атаки вычитается общая защита защищающийся армии, остаток урона вычитается из здоровья защищающийся армии
// по следующему принципу: из остатка урона вычитается здоровье каждого юнита,
// по очереди, до тех пор пока остаток не будет равен 0, при этом юнит погибает если его здоровье меньше остатка урона, то есть удаляется из армии.
// 3)После каждой атаки пересчитываться характеристики армии.
// 4)Бой заканчивается, когда погибнут все юниты в армии.
{
    class Unit_Army
    {   // Общие параметры армии.
        static int arm = 0;
        static int dam = 0;
        static int hepe = 0;
        // Хранилище всех юнитов.
        static List<Unit> Army = new List<Unit>();
       static void Main()
        {  
            Console.WriteLine("Нажмите любую клавишу , чтобы сгенерировать армию");
            Console.ReadKey();
            Console.Clear();
            AddUnit();
            Menu();
            int cmd = Convert.ToInt32(Console.ReadLine());
            while (cmd != 0)
            {
                Console.Clear();
                switch (cmd)
                {
                    case 1:
                        ArmyInfo();
                        break;
                    case 2:
                        InfoUnit();
                        break;
                    case 3:
                        GoDamage();
                        break;
                }
                if ( hepe == 0) { break; }
                Menu();
                cmd = Convert.ToInt32(Console.ReadLine());
            }
            Console.WriteLine("Армия мертва");
        }
       static void InfoUnit()
        {   
            // Выводит все характеристики каждого юнита.
            foreach (Unit X in Army)
            {
                X.Display();
            }
        }
        static void AddUnit()
        {  
            Random rnd = new Random();
            // Генерирует и сразу добавляет каждого юнита в случайном колличестве.
            for (int i = 1; i <= rnd.Next(1, 4); i++) { Army.Add(new Bard(5, 104, "Bard")); }
            for (int i = 1; i <= rnd.Next(1, 4); i++) { Army.Add(new Barbarian(15, 234, "Barbarian")); }
            for (int i = 1; i <= rnd.Next(1, 4); i++) { Army.Add(new Wizard(7, 51, "Wizard")); }
            for (int i = 1; i <= rnd.Next(1, 4); i++) { Army.Add(new Camel(0, 11, "Camel", 26)); }
            for (int i = 1; i <= rnd.Next(1, 4); i++) { Army.Add(new Horse(0, 15, "Horse", 26)); }
            for (int i = 1; i <= rnd.Next(1, 4); i++) { Army.Add(new Tiger(20, 35, "Tiger", 40)); }
            for (int i = 1; i <= rnd.Next(1, 4); i++) { Army.Add(new Balista(17, 478, "Balista")); }
            // Нам предется действовать так, потому что класс абстрактный, поэтому передаем 0,0,
            // а уже в конструкторе этого класса посчитаем ХП и Урон.
            for (int i = 1; i <= rnd.Next(1, 4); i++) { Army.Add(new Rider(0,0,"Rider")); }

            foreach (Unit X in Army)
            {
                // Здесь высчитывается статистика армии (урон, хп ,броня(С проверкой ,что она у юнита есть)).
                dam += X.Damage;
                if (X is Bard  ) { arm += ((Bard)X).GlassArmor.Armor; }
                if (X is Barbarian) { arm += ((Barbarian)X).HideArmor.Armor; }
                if (X is Wizard) { arm += ((Wizard)X).GlassArmor.Armor; }
                if (X is Rider) { arm += ((Rider)X).Barbarian.HideArmor.Armor; }
                hepe += X.Hp;

            }

        }

        static void Menu()
        {
            Console.WriteLine("Меню");
            Console.WriteLine("1- Узнать общие характеристики армии");
            Console.WriteLine("2- Узнать характериситики каждого юнита");
            Console.WriteLine("3- Нанести армии урон");
        }

        static void ArmyInfo()
        {

            Console.WriteLine("Общий урон армии: " + dam);
            Console.WriteLine("Общая защита армии: " + arm);
            Console.WriteLine("Общее количество Hp армии: " + hepe);
        }

        static void GoDamage()
        {
            Console.WriteLine("Введите урон , который хотите нанести армии");
            int damage = Convert.ToInt32(Console.ReadLine());
            while (damage <= 0)
            {
                Console.WriteLine("Введите положительное значение");
                damage = Convert.ToInt32(Console.ReadLine());
            }
            // От наносимого урона вычитаем броню.
            int realdamage = damage - arm;
            // Если реальный урон будет < 0 ,то урон не пройдет.
            realdamage = realdamage < 0 ? 0:realdamage;
            List<Unit> listremoved = new List<Unit> { };
            // Здесь наносим урон юниту и , если он "умирает", записываем его в лист на удаление.
            foreach (Unit X in Army)
            {
                if (X.Hp <= realdamage) { realdamage -= X.Hp; listremoved.Add(X); }
                else { X.Hpminus(realdamage); break; }

            }
            // Удаляем всех, кто не смог пережить нанесенный урон.
            foreach (Unit X in listremoved)
            {
                Army.Remove(X);
            }
            // Обнуляем показатели армии.
            dam = 0;
            arm = 0;
            hepe = 0;
            // И опять подсчитываем общую статистику.
            foreach (Unit X in Army)
            {

                dam += X.Damage;
                if (X is Bard) { arm += ((Bard)X).GlassArmor.Armor; }
                if (X is Barbarian) { arm += ((Barbarian)X).HideArmor.Armor; }
                if (X is Wizard) { arm += ((Wizard)X).GlassArmor.Armor; }
                if (X is Rider) { arm += ((Rider)X).Barbarian.HideArmor.Armor; }
                hepe += X.Hp;

            }
            Console.Clear();
        }
        
    }
}