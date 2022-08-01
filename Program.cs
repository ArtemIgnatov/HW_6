using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace HW_6
{
    internal class Program
    {
        static void Main(string[] args)
        {
            using(StreamWriter sw = new StreamWriter("artem.csv", true, Encoding.Unicode))
            {
                char key = 'д';
                int id = 0;

                do
                {
                    string note = string.Empty;

                    id++;
                    note += $"{id}#";

                    string now = DateTime.Now.ToString("dd.MM.yyyy HH:mm");
                    Console.Write($"Время заметки {now}");
                    note += $"{now}#";

                    Console.Write("\nВведите ФИО: ");
                    note += $"{Console.ReadLine()}#";

                    Console.Write("Введите возраст: ");
                    note += $"{Console.ReadLine()}#";

                    Console.Write("Введите рост: ");
                    note += $"{Console.ReadLine()}#";

                    Console.Write("Введите дату рождения: ");
                    note += $"{Console.ReadLine()}#";

                    Console.Write("Введите место рождения: ");
                    note += $"{Console.ReadLine()}#";

                    sw.WriteLine(note);
                    Console.WriteLine("Продолжить? н/д");
                    key = Console.ReadKey(true).KeyChar;
                } while (char.ToLower(key) == 'д');
            }

            using (StreamReader sr = new StreamReader("artem.csv", Encoding.Unicode))
            {
                string line;
                Console.WriteLine($"{"ID",-5} {"Время",-20} {"Ф.И.О.",-30} {"Возраст",-10} {"Рост",-7} {"Дата рождения",-15} {"Место рождения",-30}");

                while ((line = sr.ReadLine()) != null)
                {
                    string[] data = line.Split('#');
                    Console.WriteLine($"{data[0],-5} {data[1],-20} {data[2],-30} {data[3],-10} {data[4],-7} {data[5],-15} {data[6],-30}");
                }

            }
            Console.ReadKey();
        }
    }
}
