using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WillisTowersWatson
{
    public interface IPolicy
    {
        string PolicyName { get; set; }
        void createClaim(int origin, int year, float payment);
    }
}
