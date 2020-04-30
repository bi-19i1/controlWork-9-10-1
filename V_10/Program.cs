using System;
using System.IO;

namespace V_10
{
    static class Program
    {
        public static void Main(string[] args)
        {
            ReadArray();
            Console.ReadLine();
        }
        static void ReadArray()
        {
            try
            {
                using (var sr = new StreamReader("array.txt"))
                {
                    string[] optArray = sr.ReadLine()?.Split();
                    if (optArray != null)
                    {
                        var lines = Convert.ToInt32(optArray[0]);
                        var columns = Convert.ToInt32(optArray[1]);
                        var array = new string[lines, columns];
                        var temp = 2;
                        for (int i = 0; i < lines; i++)
                        {
                            for (int j = 0; j < columns; j++)
                            {
                                array[i, j] = optArray[temp];
                                temp++;
                            }
                        }
                        ChangeElements(array);
                    }
                    else
                    {
                        Console.WriteLine("Файл \"array.txt\" пустой. Создайте файл и заполните в формате: \"{C} {L} {n1 n2 n3 ...}\"");
                    }
                }
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("Файла не существует. Создайте файл \"array.txt\" и заполните в формате: \"{C} {L} {n1 n2 n3 ...}\"");
                throw;
            }
            catch (IndexOutOfRangeException)
            {
                Console.WriteLine("Массив в файле задан неверно! Укажите в файле \"array.txt\" значения всех элементов массива и повторите попытку...");
                throw;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        static void ChangeElements(string[,] array)
        {
            string[] temp = new string [array.GetLength(0)];
            for (int i = 0; i < array.GetLength(0); i++)
            {
                temp[i] = array[i, 0];
                array[i, 0] = array[i, array.GetLength(1) - 1];
                array[i, array.GetLength(1) - 1] = temp[i];
            }
            WriteOnFile(array);
        }

        static void WriteOnFile(string[,] array)
        {
            try
            {
                using (var sw = new StreamWriter("newArray.txt"))
                {
                    for (int i = 0; i < array.GetLength(0); i++)
                    {
                        for (int j = 0; j < array.GetLength(1); j++)
                        {
                            sw.Write(array[i ,j]);
                        }
                        sw.WriteLine();
                    }
                }
                Console.WriteLine("Successfully V_10!");
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}