using System;
using System.IO;
using System.Linq;
using System.Runtime.ExceptionServices;

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

        static public string askInput(string text)
        {
            Helper.colorText(text, ConsoleColor.Cyan);
            string name = Console.ReadLine();

            return name;
        }
    }

    class Data
    {
        static public string[] fillArray(bool isNameArray)
        {
            string[] tempArray = new string[50]; // временный массив, т.к. мы не знаем сколько у нас имен

            StreamReader stream;
            if (isNameArray)
                stream = new StreamReader("..\\..\\..\\names.txt");
            else
                stream = new StreamReader("..\\..\\..\\positions.txt");

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

            string[] resultArray = new string[i]; // конечный массив

            // заполняем конечный массив
            for (int j = 0; j < i; j++)
                if (tempArray[j] != "")
                    resultArray[j] = tempArray[j];

            return resultArray;
        }

        static public void addEntry(string newName, string newPosition)
        {
            string[] nameArray = Data.fillArray(true);
            string[] positionArray = Data.fillArray(false);

            StreamWriter nameStreamWriter = new StreamWriter("..\\..\\..\\names.txt", true);
            StreamWriter positionStreamWriter = new StreamWriter("..\\..\\..\\positions.txt", true);

            nameStreamWriter.WriteLine(newName);
            positionStreamWriter.WriteLine(newPosition);

            nameStreamWriter.Close();
            positionStreamWriter.Close();
        }

        static public void deleteEntry(string needed_name)
        {
            string[] nameArray = fillArray(true);
            string[] positionArray = fillArray(false);

            for (int i = 0; i < nameArray.Length; i++)
                if (nameArray[i] == needed_name)
                {
                    nameArray[i] = "";
                    positionArray[i] = "";
                }

            StreamWriter nameStreamWriter = new StreamWriter("..\\..\\..\\names.txt");
            StreamWriter positionStreamWriter = new StreamWriter("..\\..\\..\\positions.txt");

            for (int i = 0; i < nameArray.Length; i++)
                if ((nameArray[i] != "") && (positionArray[i] != ""))
                {
                    nameStreamWriter.WriteLine(nameArray[i]);
                    positionStreamWriter.WriteLine(positionArray[i]);
                }

            nameStreamWriter.Close();
            positionStreamWriter.Close();
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

            names = Data.fillArray(true);
            positions = Data.fillArray(false);

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
                string name;

                switch (input)
                {
                    case "1":
                        Data.printAll(names, positions);
                        break;
                    case "2":
                        name = Helper.askInput("Введите ФИО сотрудника: ");
                        Console.WriteLine(Data.findByName(name, names, positions));
                        break;
                    case "3":
                        name = Helper.askInput("Введите ФИО нового сотрудника: ");
                        string position = Helper.askInput("Введите должность нового сотрудника: ");

                        Data.addEntry(name, position);

                        // обновляем массивы с данными
                        names = Data.fillArray(true);
                        positions = Data.fillArray(false);

                        break;
                    case "4":
                        name = Helper.askInput("Введите ФИО сотрудника: ");
                        Data.deleteEntry(name);

                        names = Data.fillArray(true);
                        positions = Data.fillArray(false);

                        break;
                    case "0":
                        break;
                    default:
                        Helper.colorText("Введено неверное действие, попробуйте снова.", ConsoleColor.Red, true);
                        break;
                }
            }
        }
    }
}
