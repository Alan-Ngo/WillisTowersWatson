using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WillisTowersWatson
{
    class Claims 
    {
        private int _OriginYear { get; set; }
        private int _Year { get; set; }
        private float _Payment { get; set; }

        public Claims(int origin, int year, float payment)
        {
            this._OriginYear = origin;
            this._Year = year;
            this._Payment = payment;
        }
    }
}
