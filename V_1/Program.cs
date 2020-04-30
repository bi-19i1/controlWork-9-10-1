using System;
using System.IO;

namespace V_1
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
                        CreateNewArray(array);
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

        static void CreateNewArray(string[,] array)
        {
            var countElements = 0;
            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    if ((i + 1) % 2 != 0 && (j + 1) % 2 == 0)
                    {
                        countElements++;
                    }
                }
            }
            var newArray = new string[countElements];
            var c = 0;
            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    if ((i + 1) % 2 != 0 && (j + 1) % 2 == 0)
                    {
                        newArray[c] = array[i, j];
                        c++;
                    }
                }
            }
            WriteOnFile(newArray);
        }

        static void WriteOnFile(string[] newArray)
        {
            try
            {
                using (var sw = new StreamWriter("newArray.txt"))
                {
                    for (int i = 0; i < newArray.GetLength(0); i++)
                    {
                        sw.Write(newArray[i]);
                    }
                }
                Console.WriteLine("Successfully V_1!");
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}