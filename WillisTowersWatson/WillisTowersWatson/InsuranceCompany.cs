using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WillisTowersWatson
{
    class InsuranceCompany
    {
        public String CompanyName { get; set; }
        public List<InsurancePolicy> Policies { get; }

        public InsuranceCompany(String name)
        {
            this.CompanyName = name;
        }

        public void readTxtFile(String fileName)
        {
            try
            {
                //Pass the file path and file name to the StreamReader constructor
                String workingDirectory = Environment.CurrentDirectory;
                String path = Directory.GetParent(workingDirectory).Parent.FullName + "./" + fileName;

                StreamReader sr = new StreamReader(path);
                //Read the first line of text
                String line = sr.ReadLine();
                //Continue to read until you reach end of file
                while (line != null)
                {
                    Console.WriteLine(line);
                    //Read the next line
                    line = sr.ReadLine();
                }
                //close the file
                sr.Close();
                Console.ReadLine();
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: " + e.Message);
            }

            Console.ReadLine();
        }


        public void calculateAccumulatedPayments()
        {

        }


    }
}
