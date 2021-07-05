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

        public Dictionary<String, InsurancePolicy> Policies { get; set; }

        public InsuranceCompany(String name)
        {
            this.Policies = new Dictionary<string, InsurancePolicy>();
            this.CompanyName = name;
        }

        public void outputAccumulatedPayments(String fileName, String outFileName)
        {
            String workingDirectory = Environment.CurrentDirectory;
            String path = Directory.GetParent(workingDirectory).Parent.FullName + "./" + fileName;
            String outPath = Directory.GetParent(workingDirectory).Parent.FullName + "./" + outFileName;

            List<String> txt = this.readTxtFile(fileName,path);
            this.convertToPolicy(txt);

            String output = "";

            //Make first row
            int lowYeaer = this.getLowestYear(Policies);
            int claimsRange = this.getYearRange(Policies);
            output += lowYeaer + ", " + claimsRange + "\n";

            //Add data
            Dictionary <String, String> accumulatedData = this.calculateAccumulatedPayments();
            foreach (KeyValuePair<String, String> policy in accumulatedData)
            {
                output += policy.Key + "," + policy.Value + "\n";
            }
            
            Console.WriteLine(output);
            writeToFile(output, outPath);
        }

        private void convertToPolicy(List<String> txt)
        {
            foreach (String line in txt)
            {
                var lineSplit = line.Split(',');

                String policy = lineSplit[0];
                if (!Policies.ContainsKey(policy))
                {
                    Policies.Add(policy, new InsurancePolicy(policy));
                }

                int origin = int.Parse(lineSplit[1]);
                int year = int.Parse(lineSplit[2]);
                float payment = float.Parse(lineSplit[3]);

                Policies[policy].createClaim(origin, year, payment);
            }
        }

        //Read and write txt functions should be moved to its own class
        private List<String> readTxtFile(String fileName, String path)
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

        private void writeToFile(String txt, String path)
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

        private Dictionary<String, String> calculateAccumulatedPayments()
        {
            Dictionary<String, String> dReturn = new Dictionary<String,String>();

            foreach (KeyValuePair<string, InsurancePolicy> policy in Policies)
            {
                //Sort the claims
                policy.Value.Claims.OrderBy(a => a.OriginYear).ThenBy(a => a.DevelopmentYear);

                //Set up variables
                float value = 0;
                int year = policy.Value.Claims[0].OriginYear;
                int devYear = year;
                String outStr = "";

                foreach (Claim claim in policy.Value.Claims)
                {
                    if (claim.OriginYear != year)
                    {
                        value = 0;
                        year = claim.OriginYear;
                        devYear = year;
                    }
                    
                    //Loop until it reaches second to last dev year
                    int devDiff = (claim.DevelopmentYear - devYear) - 2;
                    for (int i = 0; i < devDiff; i++)
                    {
                        devYear += 1;
                        outStr += value + ",";
                    }

                    value += claim.Payment;
                    outStr += value + ",";
                }
                dReturn[policy.Key] = outStr;
            }
            return dReturn;
        }

        private int getLowestYear(Dictionary<string, InsurancePolicy> Policies)
        {
            int lowestYear = int.MaxValue;
            foreach (KeyValuePair<string, InsurancePolicy> policy in Policies)
            {
                foreach (Claim claim in policy.Value.Claims)
                {
                    //Get lowest year
                    if (claim.OriginYear < lowestYear)
                    {
                        lowestYear = claim.OriginYear;
                    }
                }
            }
            return lowestYear;
        }

        private int getYearRange(Dictionary<string, InsurancePolicy> Policies)
        {
            int rangeYear = 0;
            foreach (KeyValuePair<string, InsurancePolicy> policy in Policies)
            {
                foreach (Claim claim in policy.Value.Claims)
                {
                    //Get max diff between development year and origin
                    int diff = (claim.DevelopmentYear - claim.OriginYear) + 1;
                    if (diff > rangeYear)
                    {
                        rangeYear = diff;
                    }
                }
            }
            return rangeYear;
        }
    }
}
