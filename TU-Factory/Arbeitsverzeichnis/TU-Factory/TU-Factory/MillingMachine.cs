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
        private double millingVolume;

        public MillingMachine(int ID, int errorProbability, double cuttingDepth, double cuttingWidth, double feedingSpeed, int xCoordinate, int yCoordinate) : base(ID, errorProbability, xCoordinate, yCoordinate)
        {
            this.cuttingDepth = cuttingDepth;
            this.cuttingWidth = cuttingWidth;
            this.feedingSpeed = feedingSpeed;
            metalRemovalRate = cuttingDepth * cuttingWidth * feedingSpeed;
            machineType = "Fräsmaschine";

        }

        public override double getCalcMachinTime()
        {
            return Math.Ceiling(millingVolume / metalRemovalRate);
        }

        public override void setMachineVolume()
        {
            millingVolume = currentPart.getNextMachiningVolume();
        }

        public override double getInfluenceOnQuality()
        {
            return wear / 50;
        }
    }
}