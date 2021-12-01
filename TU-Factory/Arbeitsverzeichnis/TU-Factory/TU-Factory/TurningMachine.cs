using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TU_Factory
{
    public class TurningMachine : Machine
    {
        private double cuttingDepth;
        private double cuttingSpeed;
        private double feed;
        private double turnedVolume;

        public TurningMachine(int ID, int errorProbability, double cuttingSpeed, double cuttingDepth, double feed, int xCoordinate, int yCoordinate)
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