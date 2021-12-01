using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TU_Factory
{
    public abstract class Machine
    {
        private double beginningTimeInUse;
        protected Part currentPart;
        private double endingTimeInUse;
        private int errorProbability;
        private bool inRepair;
        private bool inUse;
        private int machineID;
        protected string machineType;
        protected double metalRemovalRate;
        protected double wear;
        private int xCoordinate;
        private int yCoordinate;

        public Machine(int ID, int errorProbability, int xCoordinate, int yCoordinate)
        {
            throw new System.NotImplementedException();
        }

        public void addToEndingTime(int endTime)
        {
            throw new System.NotImplementedException();
        }

        public abstract double getCalcMachinTime();
       

        public Part getCurrentPart()
        {
            throw new System.NotImplementedException();
        }

        public double getEndTime()
        {
            throw new System.NotImplementedException();
        }

        public double getInfluenceOnQuality()
        {
            throw new System.NotImplementedException();
        }

        public bool getInRepair()
        {
            throw new System.NotImplementedException();
        }

        public bool getInUse()
        {
            throw new System.NotImplementedException();
        }

        public string getMachineType()
        {
            throw new System.NotImplementedException();
        }

        public bool possibleError()
        {
            throw new System.NotImplementedException();
        }

        public void repair()
        {
            throw new System.NotImplementedException();
        }

        public void setCurrentPart(Part P)
        {
            throw new System.NotImplementedException();
        }

        public void setInRpair(bool b)
        {
            throw new System.NotImplementedException();
        }

        public void setInUse(bool B)
        {
            throw new System.NotImplementedException();
        }

        public abstract void setMachineVolume();
        

        public void setTimeAndCalculateWear(double currentTime, double endTime)
        {
            throw new System.NotImplementedException();
        }

        public override string ToString()
        {
            throw new System.NotImplementedException();
        }
    }
}