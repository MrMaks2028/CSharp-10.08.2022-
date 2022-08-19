using System;
using System.Collections.Generic;
using System.IO;

namespace C_Sharp_2._2;

class Program
{

    static void Main(string[] args)
    {
        FileInfo file = new FileInfo(@"C:\Users\З - 15\Documents\Бутаков Максим\saves\save.txt");

        List<Uchastniki> uchastniki = new List<Uchastniki>();

        int count = Uchastniki.Input_age("Введите кол-во участников: ");

        int i = 0;
        for ( ; i < count; i++)
        {
            uchastniki.Add(new Uchastniki(i + 1));
        }

        void Out()
        {
            Console.WriteLine("Все участники: ");
            foreach (var item in uchastniki)
            {
                Console.WriteLine($"{item.ToString()}");
            }
        }

        string s = "";
        while (s != "4")
        {
            Console.WriteLine("[1] Добавить участника, [2] Удалить участника, [3] Редактировать участника, [4] Выход из программы");

            s = Console.ReadLine();
           
            switch (s)
            {
                case "1":
                    {
                        uchastniki.Add(new Uchastniki(i + 1));
                        Out();
                        break;
                    }
                case "2":
                    {
                        Console.WriteLine("Введите ID участника: ");
                        uchastniki.RemoveAt(int.Parse(Console.ReadLine()) - 1);
                        Out();
                        break;
                    }
                case "3":
                    {
                        Console.WriteLine("Введите ID участника, которого хотите отредактировать: ");
                        int n = int.Parse(Console.ReadLine());
                        Console.Write("Введите новое ФИО участника: ");
                        uchastniki[n - 1].Name = Console.ReadLine();
                        Console.Write("Введите новый возраст участника: ");
                        uchastniki[n - 1].Age = int.Parse(Console.ReadLine());
                        Out();
                        break;
                    }
                case "4":
                    {
                        break;
                    }
                default:
                    {
                        break;
                    }

            }
            
        }
        using (StreamWriter writer = new(@"C:\Users\З - 15\Documents\Бутаков Максим\saves\save.txt", false))
        {
            foreach(var item in uchastniki) 
            {
                writer.WriteLine($"{item.Id} {item.Name} {item.Age}\n");
            }
            writer.Close();
        }

        List<string> strings = new List<string>();

        using (StreamReader reader = new(@"C:\Users\З - 15\Documents\Бутаков Максим\saves\save.txt"))
        {
            string line = "";
            while((line = reader.ReadLine()) != null)
            {
                strings.Add(line);
            }
            reader.Close();
        }

        List<Uchastniki> Uchastniki2 = new List<Uchastniki>();
        foreach(var item in strings)
        {
            string[] subs = item.Split('!');
            Uchastniki2.Add(new Uchastniki(int.Parse(subs[0]), subs[1], int.Parse(subs[2])));
        }

        return;
    }
}
