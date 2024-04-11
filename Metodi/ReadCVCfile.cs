using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Metodi
{
    public static class ReadCvc
    {
        public static void ReadToArr(ref double[,] array)
        {
            // Получаем путь к папке с приложением
            string folderPath = AppDomain.CurrentDomain.BaseDirectory;

            // Формируем полный путь к файлу
            string filePath = Path.Combine(folderPath, "data1.csv");

            string csvFilePath = filePath;

            // Чтение всех строк из CSV-файла
            string[] lines = File.ReadAllLines(csvFilePath);

            int n = 5; // Количество элементов для удаления из начала массива

            // Удаление первых N элементов из массива
            string[] data = lines.Skip(n).ToArray();

            // Создание двумерного массива
            string[,] twoDimensionalArray = new string[data.Length, data[0].Split(',').Length];

            // Заполнение двумерного массива
            for (int i = 0; i < data.Length; i++)
            {
                string[] splitData = data[i].Split(',');
                for (int j = 0; j < splitData.Length; j++)
                {
                    twoDimensionalArray[i, j] = splitData[j];
                }
            }
            Console.WriteLine();
            double[,] arr = new double[twoDimensionalArray.GetLength(0), twoDimensionalArray.GetLength(1)];

            // Вывод двумерного массива
            for (int i = 0; i < twoDimensionalArray.GetLength(0); i++)
            {
                for (int j = 0; j < twoDimensionalArray.GetLength(1); j++)
                {
                    //Console.Write(twoDimensionalArray[i, j] + "\t");
                    arr[i, j] = double.Parse(twoDimensionalArray[i, j], CultureInfo.InvariantCulture);

                }
                Console.WriteLine();
            }
            array = arr;
        }


        public static void ReadToArr2(ref double[,] array)
        {
            // Получаем путь к папке с приложением
            string folderPath = AppDomain.CurrentDomain.BaseDirectory;

            // Формируем полный путь к файлу
            string filePath = Path.Combine(folderPath, "data2.csv");

            string csvFilePath = filePath;

            // Чтение всех строк из CSV-файла
            string[] lines = File.ReadAllLines(csvFilePath);

            int n = 5; // Количество элементов для удаления из начала массива

            // Удаление первых N элементов из массива
            string[] data = lines.Skip(n).ToArray();

            // Создание двумерного массива
            string[,] twoDimensionalArray = new string[data.Length, data[0].Split(',').Length];

            // Заполнение двумерного массива
            for (int i = 0; i < data.Length; i++)
            {
                string[] splitData = data[i].Split(',');
                for (int j = 0; j < splitData.Length; j++)
                {
                    twoDimensionalArray[i, j] = splitData[j];
                }
            }
            Console.WriteLine();
            double[,] arr = new double[twoDimensionalArray.GetLength(0), twoDimensionalArray.GetLength(1)];

            // Вывод двумерного массива
            for (int i = 0; i < twoDimensionalArray.GetLength(0); i++)
            {
                for (int j = 0; j < twoDimensionalArray.GetLength(1); j++)
                {
                    //Console.Write(twoDimensionalArray[i, j] + "\t");
                    arr[i, j] = double.Parse(twoDimensionalArray[i, j], CultureInfo.InvariantCulture);

                }
                Console.WriteLine();
            }
            array = arr;
        }
    }
}
