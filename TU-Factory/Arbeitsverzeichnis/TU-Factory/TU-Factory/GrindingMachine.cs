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

        public GrindingMachine(int ID, int errorProbability, double infeed, double grindingWidth, double cuttingSpeed, double speedRelation, int xCoordinate, int yCoordinate)
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
    }
}