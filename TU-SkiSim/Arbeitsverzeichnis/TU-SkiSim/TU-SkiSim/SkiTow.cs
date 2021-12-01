using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TU_SkiSim
{
    public class SkiTow : Lift
    {
        private int numberOfLanes;

        public SkiTow(int number, int velocity, int length, double ausfallswsl, int elements, int anzahl_spuren) : base(number, velocity, length, elements)
        {
            this.numberOfLanes = anzahl_spuren;
        }

        public override int calcFlowRate()
        {
            return numberOfLanes * velocity * (elements / length);
        }
        public override string ToString()
        {
            return $"Lift {number}";
        }
    }
}