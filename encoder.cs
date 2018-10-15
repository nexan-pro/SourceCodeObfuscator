using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ConsoleApp2
{
    class Program
    {
        static void Main(string[] args)
        {
            Program pr = new Program();
            StreamWriter writer = new StreamWriter("text.txt");
            string str = "Lesha";  
            pr.Encryption(ref str);
            writer.Write("\\x" + str);
            pr.Decript(ref str);
            writer.Write("\n" + "\\x" + str);
            //Console.WriteLine(str);
            writer.Close();
            
            StreamReader reader = new StreamReader("text.txt");
            Console.WriteLine(reader.ReadLine());
            Console.WriteLine(reader.ReadLine());
            reader.Close();
            Console.ReadKey();
        }
        string Encryption(ref string str)
        {
            char a;
            string outStr = "";
            byte[] tmp = Encoding.UTF8.GetBytes(str);
            str = BitConverter.ToString(tmp).Replace("-", "\\x");
            for (int i = 0; i < str.Length; i++)
            {
                a = str[i];
                a <<= 1;
                outStr += a;
            }
            str = outStr;
            return str;
        }
        string Decript(ref string str)
        {
            char a;
            string outStr = "";
            for (int i = 0; i < str.Length; i++)
            {
                a = str[i];
                a >>= 1;
                outStr += a;
            }
            str = outStr;
            return str;
        }
    }
}
//lampw
/*
 * vagrant, worpress, linux, apache, mysql, php
 * */