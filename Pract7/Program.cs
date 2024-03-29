using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
//task 1
namespace Pract7
{
    internal class Program
    {
        static void Main(string[] args)
        {
            {
                BinaryWriter binaryWriter = new BinaryWriter(new FileStream("Data.dat", FileMode.Create, FileAccess.Write));
                Console.WriteLine("Сохраняем числа:");

                {
                    Random random = new Random();
                    double[] arr = new double[10];
                    // For debug
                    for (int i = 0; i != 10; ++i)
                    {
                        arr[i] = (double)random.Next(100) + (double)random.Next(100) / 100.0;
                        binaryWriter.Write(arr[i]);
                    }
                }
                binaryWriter.Close();
            }



            
            {
                BinaryReader binaryReader;
                try
                {
                    binaryReader = new BinaryReader(new FileStream("Data.dat", FileMode.Open, FileAccess.Read));
                }
                catch (System.IO.FileNotFoundException)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Ошибка доступа к файлу \"Data.dat\"");
                    Console.ResetColor();
                    return;
                }

                try
                {
                    while (true)
                        Console.WriteLine(binaryReader.ReadDouble());
                }
                catch {binaryReader.Close(); }
            }
            





            double max=double.NegativeInfinity,min=double.PositiveInfinity;
            double difference;
            double[] array=new double[10];
            {
                BinaryReader binaryReader; 
                try
                {
                    binaryReader = new BinaryReader(new FileStream("Data.dat", FileMode.Open, FileAccess.Read));
                }
                catch (System.IO.FileNotFoundException)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Ошибка доступа к файлу \"Data.dat\"");
                    Console.ResetColor();
                    return;
                }
                
                
                try
                {
                
                    double curr;
                    
                    for (int i = 0;i!= 10; ++i)
                    {
                        curr = binaryReader.ReadDouble();
                        array[i] = curr;
                        if (curr > max)
                            max = curr;
                        if(curr < min)
                            min = curr;
                    }
                    binaryReader.Close();
                }
                catch { binaryReader.Close(); }
            }
            
            


            Console.ForegroundColor = ConsoleColor.Green;
            difference = max - min;
            Console.WriteLine($"max:{max}\tmin:{min}\tdifference:{difference}");
            Console.ResetColor();


            Console.WriteLine("Add difference:");

            {
                BinaryWriter binaryWriter;
                try
                {
                    binaryWriter = new BinaryWriter(new FileStream("Data.dat", FileMode.Open, FileAccess.Write));
                    binaryWriter.Seek(0, SeekOrigin.End);
                    binaryWriter.Write(difference);
                }
                catch (System.IO.FileNotFoundException)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Ошибка доступа к файлу \"Data.dat\"");
                    Console.ResetColor();
                    return;
                }catch (Exception ex){ Console.ForegroundColor = ConsoleColor.Red;Console.WriteLine(ex.Message);Console.ResetColor();return;}
                binaryWriter.Close();
            }
            
            


            Console.WriteLine("Data.dat:");

            
            {
                BinaryReader binaryReader;
                try
                {
                    binaryReader = new BinaryReader(new FileStream("Data.dat", FileMode.Open, FileAccess.Read));
                }
                catch (System.IO.FileNotFoundException)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Ошибка доступа к файлу \"Data.dat\"");
                    Console.ResetColor();
                    return;
                }
                try
                {
                    while(true) { Console.WriteLine(binaryReader.ReadDouble()); }
                }
                catch { binaryReader.Close(); }
            }

        }
    }
}
