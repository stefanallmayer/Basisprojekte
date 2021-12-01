using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TU_Factory
{
    public class WorkingStep
    {
        private string machineType;
        private double volume;

        public WorkingStep(string machineType, double volume)
        {
            this.machineType = machineType;
            this.volume = volume;
        }

        public string getMachineType()
        {
            return machineType;
        }

        public double getVolume()
        {
            return volume;
        }
    }
}