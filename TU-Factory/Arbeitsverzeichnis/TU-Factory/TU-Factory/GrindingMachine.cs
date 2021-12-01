using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TU_Factory
{
    public class GrindingMachine : Machine
    {
        private double cuttingSpeed;
        private double grindingVolume;
        private double grindingWidth;
        private double infeed;
        private double speedRelation;

        public GrindingMachine(int ID, int errorProbability, double infeed, double grindingWidth, double cuttingSpeed, double speedRelation, int xCoordinate, int yCoordinate):base(ID, errorProbability, xCoordinate, yCoordinate)
        {
            this.cuttingSpeed = cuttingSpeed;
            this.grindingWidth = grindingWidth;
            this.grindingWidth = 50;
            this.speedRelation = speedRelation;
            this.infeed = infeed;
            metalRemovalRate = infeed * grindingWidth * cuttingSpeed / speedRelation;
            machineType = "Schleifmaschine";

        }

        public override double getCalcMachinTime()
        {
            return Math.Ceiling(grindingVolume / metalRemovalRate);
        }

        public override void setMachineVolume()
        {
            grindingVolume = currentPart.getNextMachiningVolume();
        }
    }
}