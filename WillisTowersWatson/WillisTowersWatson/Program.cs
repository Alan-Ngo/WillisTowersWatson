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
            String outFileName = "claimsAcc.txt";
            WillisTowersWatson.outputAccumulatedPayments(fileName,outFileName);

            Console.ReadLine();
        }
    }
}
