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

        public TurningMachine(int ID, int errorProbability, double cuttingSpeed, double cuttingDepth, double feed, int xCoordinate, int yCoordinate): base(ID, errorProbability, xCoordinate, yCoordinate)
        {
            this.cuttingDepth = cuttingDepth;
            this.feed = feed;
            this.cuttingSpeed = cuttingSpeed;
            metalRemovalRate = cuttingSpeed * cuttingDepth * feed * 1000;
            machineType = "Drehmaschine";
        }

        public override double getCalcMachinTime()
        {
            return Math.Ceiling(turnedVolume / metalRemovalRate);
        }

        public override void setMachineVolume()
        {
            turnedVolume = currentPart.getNextMachiningVolume();
        }

        public override double getInfluenceOnQuality()
        {
            return wear / 45;
        }
    }
}