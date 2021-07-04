using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WillisTowersWatson
{
    class Claim 
    {
        public int OriginYear { get; set; }
        public int Year { get; set; }
        public float Payment { get; set; }

        public Claim(int origin, int year, float payment)
        {
            this.OriginYear = origin;
            this.Year = year;
            this.Payment = payment;
        }
    }
}
