using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TU_Factory
{
    public class MillingMachine : Machine
    {
        private double cuttingDepth;
        private double cuttingWidth;
        private double feedingSpeed;
        private double mikkingVolume;

        public MillingMachine(int ID, int errorProbability, double cuttingDepth, double cuttingWidth, double feedingSpeed, int xCoordinate, int yCoordinate)
        {
            throw new System.NotImplementedException();
        }

        public override double getCalcMachinTime()
        {
            throw new NotImplementedException();
        }

        public override void setMachineVolume()
        {
            throw new NotImplementedException();
        }

        public double getInfluenceOnQuality()
        {
            throw new System.NotImplementedException();
        }
    }
}