using System.IO;
using System.Drawing;

// https://acmp.ru/index.asp?main=task&id_task=768

namespace practical_task1
{
    class Program
    {
        // Чтение данных из файла
        static Point[] ReadData(string filePath)
        {
            using (StreamReader inputStream = new StreamReader(filePath))
            {
                // Создание массива для хранения координат
                Point[] result = new Point[int.Parse(inputStream.ReadLine())];
                
                // Массив для координат одной "звезды"
                string[] input;

                // Считывание координат
                for (int i = 0; i < result.Length; i++)
                {
                    input = inputStream.ReadLine().Split(' ');
                    result[i] = new Point(int.Parse(input[0]), int.Parse(input[1]));
                }

                return result;
            }
        }

        // Запись результата в файл
        static void WriteData(string filePath, int data)
        {
            using (StreamWriter sw = new StreamWriter(filePath)) sw.WriteLine(data);
        }

        static void Main(string[] args)
        {
            // Пременные с названиями входного и выходного файлов
            string inputFile = "INPUT.TXT", outputFile = "OUTPUT.TXT";

            // Переменная для записи результата (кол-ва "прямоугольников")
            int result = 0;

            // Создание массива с координатами всех "звезд"
            Point[] stars = ReadData(inputFile);

            // Переменная для текущей "звезды"
            Point currentStar;

            // Переменные для "звезд" с такими же координатами по Х или Y
            Point sameX, sameY;
            
            // Проход по всем звездам
            for (int i = 0; i < stars.Length; i++)
            {
                // Запоминаем текущую "звезду"
                currentStar = stars[i];                

                // Нахождение "звезд" с такой же координатой по Х
                for (int j = i + 1; j < stars.Length; j++)
                {
                    if (currentStar.X == stars[j].X)
                    {
                        // Запоминаем "звезду" с такой же координатой по Х
                        sameX = stars[j];

                        // Нахождение "звезд" с такой же координатой по Y
                        for (int k = i + 1; k < stars.Length; k++)
                        {
                            if (currentStar.Y == stars[k].Y)
                            {
                                // Запоминаем "звезду" с такой же координатой по Y
                                sameY = stars[k];

                                // Ищем последнюю вершину "прямоугольника"
                                for (int t = i + 1; t < stars.Length; t++)
                                {
                                    if (stars[t].X == sameY.X && stars[t].Y == sameX.Y)
                                    {
                                        // Если нашли, то увеличиваем результат на 1 и выходим их цикла
                                        result++;
                                        break;
                                    }
                                }
                            }
                        }
                    }
                }
            }

            // Запись результата в файл
            WriteData(outputFile, result);
        }
    }
}
