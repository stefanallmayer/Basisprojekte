using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TU_SkiSim
{
    public class Chairlift : Lift
    {
        private int seats;

        public Chairlift(int number, int velocity, int length,double ausfallswsl, int elements, int anzahl_sitze) : base(number, velocity, length, elements)
        {
            this.seats = anzahl_sitze;
        }

        public override int calcFlowRate()
        {
            return (int)(this.seats * this.velocity * ((double)this.elements / this.length));
        }
        public override string ToString()
        {
            return $"Lift {number}";
        }
    }
}
