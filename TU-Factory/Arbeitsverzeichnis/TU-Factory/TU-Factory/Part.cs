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
        private double quality=1;
        private state state= state.Halbzeug;
        private static int staticID = 1;
        private List<WorkingStep> workInstruction;

        public Part(List<WorkingStep> workInstrucions, int Prio)
        {
            this.workInstruction = workInstrucions;
            this.prio = Prio;
            this.id = staticID;
            staticID++;
        }

        public void deleteMachineStep()
        {
            workInstruction.Remove(workInstruction.FirstOrDefault());
        }

        public string getNextMachiningMachineType()
        {
            return workInstruction.FirstOrDefault().getMachineType();
        }

        public double getNextMachiningVolume()
        {
            return workInstruction.FirstOrDefault().getVolume();
        }

        public int getNumberOfOpenOperations()
        {
            return workInstruction.Count();
        }

        public double getQuality()
        {
            return quality;
        }

        public void setCurrentMachine(Machine M)
        {
            currentMachine = M;
        }

        public void setPartFree()
        {
            currentMachine = null;
        }

        public void setQuality(double newQuality)
        {
            quality = newQuality;
        }

        public void setState(state newState)
        {
            state = newState;
        }

        public override string ToString()
        {
            return $"Part: {id}, Status: {state}";
        }
    }

    public enum state:int
    {
        Halbzeug = 1,
        aktiveBearbeitung = 2, 
        FertigesTeil = 3,
        QualityGOOD = 4,
        QualityBAD = 5
    }
}