using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WillisTowersWatson
{
    class InsurancePolicy
    {
        private String _Name { get; set; }
        private List<Claims> _Claims { get; }

        public void createClaim(int origin, int year, float payment)
        {
            _Claims.Add(new Claims(origin, year, payment));
        }
    }
}
