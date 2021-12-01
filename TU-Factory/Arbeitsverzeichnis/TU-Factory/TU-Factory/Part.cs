using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TU_Factory
{
    public class Part
    {
        private Machine currentMachine;
        private int currentXPosition;
        private int currentYPosition;
        private int id;
        private int prio;
        private double quality;
        private int state;
        private static int staticID;
        private List<WorkingStep> workInstruction;

        public Part(List<WorkingStep> workInstrucions, int Prio)
        {
            throw new System.NotImplementedException();
        }

        public void deleteMachineStep()
        {
            throw new System.NotImplementedException();
        }

        public string getNextMachiningMachineType()
        {
            throw new System.NotImplementedException();
        }

        public double getNextMachiningVolume()
        {
            throw new System.NotImplementedException();
        }

        public int getNumberOfOpenOperations()
        {
            throw new System.NotImplementedException();
        }

        public double getQuality()
        {
            throw new System.NotImplementedException();
        }

        public void setCurrentMachine(Machine M)
        {
            throw new System.NotImplementedException();
        }

        public void setPartFree()
        {
            throw new System.NotImplementedException();
        }

        public void setQuality(double newQuality)
        {
            throw new System.NotImplementedException();
        }

        public void setState(int newState)
        {
            throw new System.NotImplementedException();
        }

        public override string ToString()
        {
            throw new System.NotImplementedException();
        }
    }
}