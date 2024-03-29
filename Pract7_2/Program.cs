using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Pract7_2
{
    
    internal class Program
    {
        const string SOLUTION_NAME = "Pract7";

        static private string FindGeneralDirectory()
        {
            string general = Directory.GetCurrentDirectory();
            while (!general.EndsWith(SOLUTION_NAME))
                general=Directory.GetParent(general).FullName;
            return general;
        }
        static private void SaveDeviation(double[] array)
        {
            FileStream fileStream = new FileStream("G.dat", FileMode.Create, FileAccess.ReadWrite);
            BinaryWriter binaryWriter = new BinaryWriter(fileStream);
            for(int i = 0;i!=array.Length;++i)
                binaryWriter.Write(array[i]);
            binaryWriter.Close();
            fileStream.Close();
        }
        static private void ReadDeviation(uint numbersCount=1)
        {
            
            FileStream fileStream = new FileStream("G.dat", FileMode.Open, FileAccess.Read);
            BinaryReader binaryReader = new BinaryReader(fileStream);


            Console.ForegroundColor= ConsoleColor.Green;
            Console.WriteLine("Saved deviation:");
            Console.ResetColor();
            for (int i = 0; i != numbersCount; ++i)
                Console.WriteLine(binaryReader.ReadDouble());
            binaryReader.Close();
            fileStream.Close();
        }
        static void Main(string[] args)
        {
            try
            {
                if (File.Exists("F.dat"))
                    File.Delete("F.dat");
                File.Copy(Path.Combine(FindGeneralDirectory(), "Pract7_1\\bin\\Debug\\F.dat"), Path.Combine(Directory.GetCurrentDirectory(), "F.dat"));


                double averageTemperature=0;
                double [] temperature=new double[12];
                FileStream fileStream = File.OpenRead("F.dat");
                BinaryReader binReader = new BinaryReader(fileStream);



                Console.WriteLine("Temperature:");
                for(int i = 0;i!=12;++i)
                {
                    temperature[i] = binReader.ReadDouble();
                    Console.WriteLine((i+1).ToString().PadLeft(2,' ')+ " "+temperature[i]);
                    averageTemperature += temperature[i];
                }
                averageTemperature /= 12;
                Console.WriteLine("Average temperature:"+ averageTemperature);

                Console.WriteLine("Temperature deviation:");
                for (int i = 0; i != 12; ++i)
                {
                    temperature[i] -= averageTemperature;
                    Console.WriteLine(temperature[i]);
                }


                SaveDeviation(temperature);
                ReadDeviation(12);
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(ex.Message); 
                Console.ResetColor();
            }
            Console.ReadKey(false);
        }
    }
}
