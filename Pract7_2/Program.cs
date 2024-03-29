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
        static void Main(string[] args)
        {
            if (!File.Exists("F.txt"))
            {
                Random random = new Random();
                StreamWriter streamWriter = new StreamWriter(new FileStream("F.txt", FileMode.Create, FileAccess.Write));
                for (int i = 0;i!=12;++i)
                    streamWriter.WriteLine((-15+(double)random.Next(50)+(double)random.Next(100)/100).ToString());
                streamWriter.Close();
            }
            if (!File.Exists("G.txt"))
            {
                FileStream fileStream=new FileStream("G.txt",FileMode.Create, FileAccess.Write);
                fileStream.Close();
            }

            StreamReader streamReader = new StreamReader("F.txt");
            Console.SetIn(streamReader);
            StreamWriter streamWriter1 = new StreamWriter("G.txt");
            Console.SetOut(streamWriter1);

            double[] arr = new double[12];
            try
            {
                for(int i = 0;i!=12;++i)
                    arr[i]=Convert.ToDouble(Console.ReadLine());
            }
            catch { }
            streamReader.Close();
            Console.SetIn(Console.In);

            double averageTemperature = 0;
            for(int i = 0;i!=12;++i)
                averageTemperature += arr[i];
            averageTemperature /= 12;
            for (int i = 0; i != 12; ++i)
            {
                if (averageTemperature < arr[i])
                    arr[i] -= averageTemperature;
                else
                    arr[i] =-(averageTemperature - arr[i]);

            }
                


            for(int i = 0;i!=12; ++i)
                Console.WriteLine(arr[i]);
            streamWriter1.Close();
            Console.SetOut(Console.Out);




        }
    }
}
