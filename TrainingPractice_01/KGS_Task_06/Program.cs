using System;
using System.IO;

namespace KGS_Task_06
{
    class Helper
    {
        static public void colorText(string text, ConsoleColor color, bool line = false)
        // Вспомогательная функция, которая меняет цвет для данного текста
        {
            Console.ForegroundColor = color;

            if (line)
                Console.WriteLine(text);
            else
                Console.Write(text);

            Console.ForegroundColor = ConsoleColor.White;
        }

        static public string askName()
        {
            Helper.colorText("Введите ФИО сотрудника: ", ConsoleColor.Cyan);
            string name = Console.ReadLine();

            return name;
        }
    }

    class Database
    {
        static public string[] fillArray(bool isNameArray)
        {
            string[] tempArray = new string[50]; // временный массив, т.к. мы не знаем сколько у нас имен

            FileStream file;
            if (isNameArray)
                file = new FileStream("..\\..\\..\\names.txt", FileMode.Open, FileAccess.Read);
            else
                file = new FileStream("..\\..\\..\\positions.txt", FileMode.Open, FileAccess.Read);

            StreamReader stream = new StreamReader(file);
            stream.BaseStream.Seek(0, SeekOrigin.Begin);

            // читаем ФИО из файла в временный массив
            string line = stream.ReadLine();
            int i;
            for (i = 0; line != null; i++)
            {
                tempArray[i] = line;
                line = stream.ReadLine();
            }

            stream.Close();
            file.Close();

            string[] resultArray = new string[i]; // конечный массив

            // заполняем конечный массив
            for (int j = 0; j < i; j++)
                if (tempArray[j] != "")
                    resultArray[j] = tempArray[j];

            return resultArray;
        }

        static public void printAll(string[] nameArray, string[] positionArray)
        {
            for (int i = 0; i < nameArray.Length; i++)
                Console.WriteLine($"{i + 1}. {nameArray[i]} - {positionArray[i]}");
        }

        static public string findByName(string name, string[] nameArray, string[] positionArray)
        {
            for (int i = 0; i < nameArray.Length; i++)
                if (nameArray[i] == name)
                    return $"{nameArray[i]} - {positionArray[i]}";
            return "Сотрудник не найден";
        }
    }

    class Program
    {

        static void Main(string[] args)
        {
            string[] names;
            string[] positions;

            names = Database.fillArray(true);
            positions = Database.fillArray(false);

            //Helper.printAll(names, positions);
            //Console.WriteLine($"\n{Helper.findByName("name3", names, positions)}");

            Console.WriteLine("Добро пожаловать в программу." +
                "\n1 - вывести все досье" +
                "\n2 - найти досье по ФИО" +
                "\n3 - добавить досье" +
                "\n4 - удалить досье" +
                "\n0 - выход.");

            string input = "";
            while (input != "0")
            {
                Helper.colorText("\nДействие: ", ConsoleColor.Blue);
                input = Console.ReadLine();

                switch (input)
                {
                    case "1":
                        Database.printAll(names, positions);
                        break;
                    case "2":
                        string name = Helper.askName();
                        Console.WriteLine(Database.findByName(name, names, positions));
                        break;
                    case "3":
                        // TODO
                        break;
                    case "4":
                        // TODO
                        break;
                }

            }
        }
    }
}
