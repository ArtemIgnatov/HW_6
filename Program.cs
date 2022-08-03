using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW_6
{

    internal class Program
    {
        private static void AddData() //метод по добавлению данных в файл
        {
            using (StreamWriter sw = new StreamWriter("artem.csv", true, Encoding.Unicode))
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
        }

        private static void ShowData() //метод по выводу данных
        {
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
        }

        private static void ShowChoose() //метод по выводу на экран стартового окна с выбором действий
        {
            Console.WriteLine(
                "Выерите вариант введя число:\n" +
                "1 - вывести данные\n" +
                "2 - добавить запись\n" +
                "3 - выход из програмы");
        }

        static void Main(string[] args)
        {
            while (true)
                {
                    ShowChoose();
                    var action  = Console.ReadLine();

                    switch (action)
                    {
                        case "1":
                            ShowData();
                            break;
                        case "2":
                            AddData();
                            break;
                        case"3":
                        goto end; //переходим на метку завершающую программу
                        default:
                            Console.WriteLine("Некорректный ввод действия, введите 1 или 2\n");
                            break;
                    }
                }
            end:; //наша метка
        }
    }
}
