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

        private Dictionary<string, InsurancePolicy> policies = new Dictionary<string, InsurancePolicy>();

        public List<InsurancePolicy> Policies { get; }

        public InsuranceCompany(String name)
        {
            this.CompanyName = name;
        }


        //Read and write functions can be moved to its own class
        public List<String> readTxtFile(String fileName)
        {
            List<String> txt = new List<string>();
            String workingDirectory = Environment.CurrentDirectory;
            String path = Directory.GetParent(workingDirectory).Parent.FullName + "./" + fileName;

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
                //close the file
                sr.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: " + e.Message);
            }

            return txt;
        }

        public void writeToFile()
        {

        }

        public void convertToPolicy(List<String> txt)
        {
            foreach (String line in txt)
            {
                var lineSplit = line.Split(',');

                String policy = lineSplit[0];
                if (!policies.ContainsKey(policy))
                {
                    policies.Add(policy, new InsurancePolicy(policy));
                }

                int origin = int.Parse(lineSplit[1]);
                int year = int.Parse(lineSplit[2]);
                float payment = float.Parse(lineSplit[3]);

                //Console.WriteLine(origin.ToString() + "-" + year.ToString() + "-" + payment.ToString());
                policies[policy].createClaim(origin,year,payment);
            }
        }

        public void calculateAccumulatedPayments()
        {
            //Get lowest year
            //get max diff

            //retrieve the imcremented values
            foreach (KeyValuePair<string, InsurancePolicy> policy in policies)
            {
                float value = 0;
                foreach (Claim claim in policy.Value.Claims)
                {
                    value += claim.Payment;
                }
                Console.WriteLine(policy.Key + " " + value);
            }
        }
    }
}
