using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WillisTowersWatson
{
    class Program
    {
        static void Main(string[] args)
        {
            String companyName = "WillisTowersWatson";
            InsuranceCompany WillisTowersWatson = new InsuranceCompany(companyName);

            String fileName = "claims.txt";
            List<String> txt = WillisTowersWatson.readTxtFile(fileName);

            WillisTowersWatson.convertToPolicy(txt);
            WillisTowersWatson.calculateAccumulatedPayments();
            Console.ReadLine();
        }
    }
}
