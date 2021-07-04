using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WillisTowersWatson
{
    class InsurancePolicy
    {
        public String PolicyName { get; set; }
        public List<Claim> Claims { get; set; }
        public InsurancePolicy(String policyName)
        {
            this.Claims = new List<Claim>();
            this.PolicyName = policyName;
        }
        public void createClaim(int origin, int year, float payment)
        {
            this.Claims.Add(new Claim(origin, year, payment));
        }
    }
}
