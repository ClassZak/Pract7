using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Fill_F_File
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("This program fill F.dat binary file");
            FileStream fileStream = new FileStream("F.dat",FileMode.Create,FileAccess.ReadWrite);
            BinaryWriter binaryWriter = new BinaryWriter(fileStream);
            Random random = new Random();
            for (int i = 0; i != 12; ++i)
                binaryWriter.Write(-30+random.Next(60)+random.NextDouble());
            fileStream.Seek(0, SeekOrigin.Begin);


            BinaryReader binaryReader = new BinaryReader(fileStream);

            Console.WriteLine("F file:");
            for (int i = 0;i != 12; ++i)
                Console.Write("{0:f2}\t",binaryReader.ReadDouble());
            Console.WriteLine();
            binaryReader.Close();
            binaryWriter.Close();
        }
    }
}
