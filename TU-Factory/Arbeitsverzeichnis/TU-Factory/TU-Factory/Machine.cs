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
        private double endingTimeInUse = 0;
        private int errorProbability = 5;
        private bool inRepair = false;
        private bool inUse = false;
        private int machineID;
        protected string machineType;
        protected double metalRemovalRate;
        protected double wear;
        private int xCoordinate;
        private int yCoordinate;

        public Machine(int ID, int errorProbability, int xCoordinate, int yCoordinate)
        {
            this.machineID = ID;
            this.errorProbability = errorProbability;
            this.xCoordinate = xCoordinate;
            this.yCoordinate = yCoordinate;
        }

        public void addToEndingTime(int endTime)
        {
            endingTimeInUse += endTime;
        }

        public abstract double getCalcMachinTime();
       

        public Part getCurrentPart()
        {
            return currentPart;
        }

        public double getEndTime()
        {
            return endingTimeInUse;
        }

        public virtual double getInfluenceOnQuality()
        {
            return 0;
        }

        public bool getInRepair()
        {
            return inRepair;
        }

        public bool getInUse()
        {
            return inUse;
        }

        public string getMachineType()
        {
            return machineType;
        }

        public bool possibleError()
        {
            //Random rnd = new Random();
            //int zufallszahl = rnd.Next(1,100);
            //if (zufallszahl <= 5)
            //    return true;
            /*else*/  if (wear >= 0.75)
                return true;
            else
                return false;
        }

        public void repair()
        {
            wear = 0;
        }

        public void setCurrentPart(Part P)
        {
            currentPart = P;
        }

        public void setInRpair(bool b)
        {
            inRepair = b;
        }

        public void setInUse(bool B)
        {
            inUse = B;
        }

        public abstract void setMachineVolume();
        

        public void setTimeAndCalculateWear(double currentTime, double endTime)
        {
            beginningTimeInUse = currentTime;
            endingTimeInUse = endTime;
            wear = wear + (endTime - currentTime) / 20;
        }

        public override string ToString()
        {
            return $"Maschinentyp: {machineType},   ID: {machineID}";
        }
    }
}