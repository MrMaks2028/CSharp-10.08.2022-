using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_Sharp_2._2
{
   internal class Uchastniki
    {
        public Uchastniki(int id, string name, int age)
        {
            Id = id;
            Name = name;
            Age = age;
        }

        public Uchastniki(int id)
        {
            Id = id;
            Console.WriteLine($"ID участника: {id}");
            Name = Input("Введите ФИО участника: ");
            Age = Input_age("Введите возраст участника: ");
        }
        string Input(string text)
        {
            Console.Write(text);
            return Console.ReadLine();
        }

       static public int Input_age(string text)
        {
            try
            {
                Console.Write(text);
                return int.Parse(Console.ReadLine());
            }
            catch (Exception)
            {
                Console.WriteLine("Вы ввели что то не то. Попробуйте заново");
                return Input_age(text);
            }
        }
        public int Id { get; set; }

        public string Name { get; set; }

        public int Age { get; set; }

        public override string ToString()
        {
            return $"ID Участника {Id} \nФИО Участника {Name} \nВозраст Участника {Age}";
        }
    }
}
