using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WillisTowersWatson
{
    class IOFile
    {
        //Singleton should be implemented to control instances of class
        public static List<String> readTxtFile(String path)
        {
            List<String> txt = new List<string>();

            try
            {
                //Pass the file path and file name to the StreamReader constructor
                StreamReader sr = new StreamReader(path);
                //Read the first line of text
                String line = sr.ReadLine();
                line = sr.ReadLine();
                //Continue to read until you reach end of file
                while (line != null)
                {
                    txt.Add(line);
                    line = sr.ReadLine();
                }
                //Close the file
                sr.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: " + e.Message);
            }

            return txt;
        }

        public static void writeToFile(String txt, String path)
        {
            try
            {
                StreamWriter sw = new StreamWriter(path);
                sw.Write(txt);
                sw.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: " + e.Message);
            }
        }
    }
}
